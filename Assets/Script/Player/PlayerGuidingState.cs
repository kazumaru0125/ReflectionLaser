using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuidingState : IPlayerState
{
    private LineRenderer lineRenderer;
    private int maxReflections = 2; // 最大反射回数
    private Color[] reflectionColors = { Color.cyan, Color.green, Color.yellow, Color.red, Color.magenta };

    private Color reflectionColor = Color.cyan;

    public void EnterState(PlayerController player)
        {
        Debug.Log("Entered Guiding State");

        // LineRenderer の初期化
        lineRenderer = player.GetComponent<LineRenderer>();
        if (lineRenderer == null)
            {
            lineRenderer = player.gameObject.AddComponent<LineRenderer>();
            }

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        player.SetAnimBool("IsAiming", true);
        }

    public void UpdateState(PlayerController player)
    {
        // 発射方向の計算（Player の firePoint からマウス位置への方向）
        Vector3 targetPoint = GetMouseWorldPosition(player);
        Vector3 shootDirection = (targetPoint - player.firePoint.position).normalized;

        // プレイヤーの位置からラインを描く（反射も考慮）
        DrawLineWithReflections(player.firePoint.position, shootDirection);
    }

    public void ExitState(PlayerController player)
    {
        Debug.Log("Exiting Guiding State");

        // LineRenderer を非表示にする
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
        }
    }

    private Vector3 GetMouseWorldPosition(PlayerController player)
    {
        // カメラからマウス位置に向かう Ray を作成
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycast が地面やオブジェクトに当たった場合、その位置をターゲットにする
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        else
        {
            // 何もヒットしなかった場合、カメラ前方の適当な地点をターゲットにする
            return ray.GetPoint(100f);
        }
    }

    private void DrawLineWithReflections(Vector3 startPosition, Vector3 direction)
    {
        List<Vector3> positions = new List<Vector3> { startPosition };
        List<Color> colors = new List<Color>();

        Vector3 currentPosition = startPosition;
        Vector3 currentDirection = direction;
        int reflections = 0;

        // 最初の色（0回反射: 水色）
      //  colors.Add(reflectionColors[0]);

        colors.Add(reflectionColor);

        while (reflections < maxReflections - 1)
        {
            RaycastHit hit;
            if (Physics.Raycast(currentPosition, currentDirection, out hit, Mathf.Infinity))
            {
                currentPosition = hit.point;
                positions.Add(currentPosition);
              //  colors.Add(reflectionColors[Mathf.Min(reflections + 1, reflectionColors.Length - 1)]);

                colors.Add(reflectionColor);
                currentDirection = Vector3.Reflect(currentDirection, hit.normal);
                reflections++;
            }
            else
            {
                // 反射せずにまっすぐ進む場合
                positions.Add(currentPosition + currentDirection * 100f);
              //  colors.Add(reflectionColors[reflections]);

                colors.Add(reflectionColor);
                break;
            }
        }

        // LineRenderer の頂点と色を設定
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());

        // 各セグメントの色を設定
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[positions.Count];
        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[positions.Count];

        for (int i = 0; i < positions.Count; i++)
        {
            float time = (float)i / (positions.Count - 1);
            colorKeys[i] = new GradientColorKey(colors[i], time);
            alphaKeys[i] = new GradientAlphaKey(1.0f, time);
        }

        gradient.SetKeys(colorKeys, alphaKeys);
        lineRenderer.colorGradient = gradient;
    }
}
