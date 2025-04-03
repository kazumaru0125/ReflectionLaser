using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyController : MonoBehaviour
    {
    private ITutorialEnemy currentState;
    public int health;
    private Renderer enemyRenderer; // Renderer��ێ�

    // Start is called before the first frame update
    void Start()
        {
        enemyRenderer = GetComponent<Renderer>(); // Renderer���擾
        SetState(new Level1State()); // �ŏ���Level1�ɐݒ�
        }

    // Update is called once per frame
    void Update()
        {
        currentState.UpdateState(this);

        // �L�[���͂ɂ���ԑJ��
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
        // ���x���J�ڂ̍ۂɐF���ύX
        if (currentState is Level1State) SetState(new Level2State());
        else if (currentState is Level2State) SetState(new Level3State());
        else if (currentState is Level3State) SetState(new Level4State());
        else if (currentState is Level4State) SetState(new Level5State());
        }

    public void SetColor(Color color)
        {
        if (enemyRenderer != null)
            {
            enemyRenderer.material.color = color; // �F��ύX
            }
        }

    // Bullet�^�O�̃I�u�W�F�N�g���Փ˂����Ƃ��Ƀ_���[�W��^����
    void OnCollisionEnter(Collision collision)
        {
        if (collision.gameObject.CompareTag("Bullet"))
            {
            // Bullet����_���[�W���擾�i����Bullet�̃X�N���v�g��Damage�v���p�e�B������Ɖ���j
            BulletsScript bullet = collision.gameObject.GetComponent<BulletsScript>();
            if (bullet != null)
                {
                TakeDamage(bullet.currentDamage); // Bullet�̃_���[�W��G�ɓK�p
                }
            }
        }
    }