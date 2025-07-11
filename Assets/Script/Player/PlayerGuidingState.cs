using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGuidingState : IPlayerState
{
    private LineRenderer lineRenderer;
    private int maxReflections = 2; // �ő唽�ˉ�
    private Color[] reflectionColors = { Color.cyan, Color.green, Color.yellow, Color.red, Color.magenta };

    private Color reflectionColor = Color.cyan;

    public void EnterState(PlayerController player)
        {
        Debug.Log("Entered Guiding State");

        // LineRenderer �̏�����
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
        // ���˕����̌v�Z�iPlayer �� firePoint ����}�E�X�ʒu�ւ̕����j
        Vector3 targetPoint = GetMouseWorldPosition(player);
        Vector3 shootDirection = (targetPoint - player.firePoint.position).normalized;

        // �v���C���[�̈ʒu���烉�C����`���i���˂��l���j
        DrawLineWithReflections(player.firePoint.position, shootDirection);
    }

    public void ExitState(PlayerController player)
    {
        Debug.Log("Exiting Guiding State");

        // LineRenderer ���\���ɂ���
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 0;
        }
    }

    private Vector3 GetMouseWorldPosition(PlayerController player)
    {
        // �J��������}�E�X�ʒu�Ɍ����� Ray ���쐬
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Raycast ���n�ʂ�I�u�W�F�N�g�ɓ��������ꍇ�A���̈ʒu���^�[�Q�b�g�ɂ���
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        else
        {
            // �����q�b�g���Ȃ������ꍇ�A�J�����O���̓K���Ȓn�_���^�[�Q�b�g�ɂ���
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

        // �ŏ��̐F�i0�񔽎�: ���F�j
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
                // ���˂����ɂ܂������i�ޏꍇ
                positions.Add(currentPosition + currentDirection * 100f);
              //  colors.Add(reflectionColors[reflections]);

                colors.Add(reflectionColor);
                break;
            }
        }

        // LineRenderer �̒��_�ƐF��ݒ�
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());

        // �e�Z�O�����g�̐F��ݒ�
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
