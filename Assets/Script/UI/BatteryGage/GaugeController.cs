using System.Collections;
using UnityEngine;

public class GaugeController : MonoBehaviour
    {
    [SerializeField] private GameObject _gauge;
    [SerializeField] private GameObject _graceGauge;
    [SerializeField] private int _maxHP;
    private int _currentHP;
    private float _HP1;
    private float _waitingTime = 1.5f;

    void Start()
        {
        RectTransform gaugeRect = _gauge.GetComponent<RectTransform>();
        RectTransform graceRect = _graceGauge.GetComponent<RectTransform>();

        // 上から減少するように設定
        gaugeRect.pivot = new Vector2(0.5f, 1f);
        graceRect.pivot = new Vector2(0.5f, 1f);

        _HP1 = gaugeRect.sizeDelta.y / _maxHP;
        _currentHP = _maxHP;
        }

    void Update()
        {
        if (Input.GetMouseButtonDown(1)) // 右クリックでゲージ減少
            {
            BeInjured(1);
            }
        if (Input.GetKeyDown(KeyCode.R)) // Rキーでゲージ回復
            {
            Recover(1);
            }
        }

    public void BeInjured(int attack)
        {
        if (_currentHP > 0)
            {
            _currentHP = Mathf.Max(_currentHP - attack, 0);
            float damage = _HP1 * attack;
            StartCoroutine(DamageCoroutine(damage));
            }
        }

    public void Recover(int heal)
        {
        if (_currentHP < _maxHP)
            {
            _currentHP = Mathf.Min(_currentHP + heal, _maxHP);
            float recoverHeight = _HP1 * heal;
            RectTransform gaugeRect = _gauge.GetComponent<RectTransform>();
            Vector2 newSize = gaugeRect.sizeDelta;
            newSize.y += recoverHeight;
            gaugeRect.sizeDelta = newSize;

            // グレースゲージの更新を遅延させる
            StartCoroutine(UpdateGraceGauge(newSize));
            }
        }

    IEnumerator DamageCoroutine(float damage)
        {
        RectTransform gaugeRect = _gauge.GetComponent<RectTransform>();
        Vector2 newSize = gaugeRect.sizeDelta;
        newSize.y -= damage;
        gaugeRect.sizeDelta = newSize;

        yield return new WaitForSeconds(_waitingTime);

        // スムーズなアニメーションで減少
        StartCoroutine(UpdateGraceGauge(newSize));
        }

    IEnumerator UpdateGraceGauge(Vector2 targetSize)
        {
        RectTransform graceRect = _graceGauge.GetComponent<RectTransform>();
        Vector2 startSize = graceRect.sizeDelta;
        float elapsedTime = 0f;
        float duration = 0.5f; // アニメーション時間

        while (elapsedTime < duration)
            {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            graceRect.sizeDelta = Vector2.Lerp(startSize, targetSize, t);
            yield return null;
            }

        graceRect.sizeDelta = targetSize;
        }

    public int GetCurrentHP()
        {
        return _currentHP;
        }

    }
