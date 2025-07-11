using UnityEngine;
using System.Collections;

public class BeamShooter : MonoBehaviour
    {
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public float beamDuration = 0.05f;
    public float beamLength = 100f;

    void Start()
        {
        // 初期設定：ビーム非表示 & 光る素材にする
        lineRenderer.enabled = false;

        Material beamMat = new Material(Shader.Find("Unlit/Color"));
        beamMat.color = new Color(0.0f, 1.0f, 1.0f, 1.0f); // シアン系
        lineRenderer.material = beamMat;
        lineRenderer.widthMultiplier = 0.1f;
        }

    void Update()
        {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            ShootBeam();
            }
        }

    public void ShootBeam()
        {
        StopAllCoroutines();
        StartCoroutine(FireBeam());
        }

    private IEnumerator FireBeam()
        {
        Vector3 start = firePoint.position;
        Vector3 end = start + firePoint.forward * beamLength;

        // Raycastで何かに当たったら、そこに止める
        if (Physics.Raycast(start, firePoint.forward, out RaycastHit hit, beamLength))
            {
            end = hit.point;
            }

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
        lineRenderer.enabled = true;

        yield return new WaitForSeconds(beamDuration);

        lineRenderer.enabled = false;
        }
    }
