using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
    {
    public Transform player;        // �v���C���[��Transform
    public Transform enemy;         // �G��Transform

    public RectTransform playerIcon; // �~�j�}�b�v��̃v���C���[�A�C�R��
    public RectTransform enemyIcon;  // �~�j�}�b�v��̓G�A�C�R��

    public float minimapSize = 100f; // �~�j�}�b�v�̃T�C�Y�i�X�P�[�����O�p�j

    void Update()
        {
        // �v���C���[�A�G�̃��[���h���W��2D���W�ɕϊ�
        Vector2 playerPos = new Vector2(player.position.x, player.position.z);
        Vector2 enemyPos = new Vector2(enemy.position.x, enemy.position.z);

        // �~�j�}�b�v���ɍ��W���}�b�s���O�i�ʒu�̃X�P�[�����O�j
        playerIcon.anchoredPosition = playerPos * minimapSize;
        enemyIcon.anchoredPosition = enemyPos * minimapSize;

        // �A�C�R�����~�j�}�b�v�̋��E�𒴂��Ȃ��悤�ɐ���
        LimitIconPosition(playerIcon);
        LimitIconPosition(enemyIcon);
        }

    // �A�C�R�����~�j�}�b�v�̋��E�𒴂��Ȃ��悤�ɐ���
    private void LimitIconPosition(RectTransform icon)
        {
        Vector2 pos = icon.anchoredPosition;
        pos.x = Mathf.Clamp(pos.x, -minimapSize, minimapSize);
        pos.y = Mathf.Clamp(pos.y, -minimapSize, minimapSize);
        icon.anchoredPosition = pos;
        }
    }
