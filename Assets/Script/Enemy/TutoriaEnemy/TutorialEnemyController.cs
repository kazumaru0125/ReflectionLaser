using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyController : MonoBehaviour
    {
    private ITutorialEnemy currentState;
    public int health;
    private Renderer enemyRenderer; // Rendererを保持

    // Start is called before the first frame update
    void Start()
        {
        enemyRenderer = GetComponent<Renderer>(); // Rendererを取得
        SetState(new Level1State()); // 最初にLevel1に設定
        }

    // Update is called once per frame
    void Update()
        {
        currentState.UpdateState(this);

        // キー入力による状態遷移
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetState(new Level1State());
        else if (Input.GetKeyDown(KeyCode.Alpha2)) SetState(new Level2State());
        else if (Input.GetKeyDown(KeyCode.Alpha3)) SetState(new Level3State());
        else if (Input.GetKeyDown(KeyCode.Alpha4)) SetState(new Level4State());
        else if (Input.GetKeyDown(KeyCode.Alpha5)) SetState(new Level5State());
        }

    public void SetState(ITutorialEnemy state)
        {
        if (currentState != null)
            {
            currentState.ExitState(this);
            }

        currentState = state;
        currentState.EnterState(this);
        }

    public void TakeDamage(int damage)
        {
        health -= damage;
        if (health <= 0)
            {
            TransitionToNextLevel();
            }
        }

    private void TransitionToNextLevel()
        {
        // レベル遷移の際に色も変更
        if (currentState is Level1State) SetState(new Level2State());
        else if (currentState is Level2State) SetState(new Level3State());
        else if (currentState is Level3State) SetState(new Level4State());
        else if (currentState is Level4State) SetState(new Level5State());
        }

    public void SetColor(Color color)
        {
        if (enemyRenderer != null)
            {
            enemyRenderer.material.color = color; // 色を変更
            }
        }

    // Bulletタグのオブジェクトが衝突したときにダメージを与える
    void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("Bullet"))
            {
            // Bulletからダメージを取得（仮にBulletのスクリプトにDamageプロパティがあると仮定）
            BulletsScript bullet = collision.gameObject.GetComponent<BulletsScript>();
            if (bullet != null)
                {
                TakeDamage(bullet.currentDamage); // Bulletのダメージを敵に適用
                }
            }
        }
    }