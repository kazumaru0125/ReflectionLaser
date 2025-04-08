using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
    {
    //Player��State�֌W
    private IPlayerState       currentState;


    public PlayerIdlingState   idleState      = new PlayerIdlingState();

    public PlayerMovingState   movingState    = new PlayerMovingState();
    public PlayerShootingState shootingState  = new PlayerShootingState();
    public PlayerGuidingState  guidingState   = new PlayerGuidingState();
    public PlayerDyingState    dyingState     = new PlayerDyingState();

    //�O��Class
    private GaugeController gaugeController; // HP�Ǘ��N���X

    private bool isClickDown = false; // ���N���b�N��������Ă��邩

    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
        {
        // ��Ԃ�����������
        if (idleState != null)
            {
            currentState = idleState;
            currentState.EnterState(this);
            }
        else
            {
            Debug.LogError("Idle state is not assigned.");
            }


              gaugeController = FindObjectOfType<GaugeController>(); // HP�Ǘ��N���X���擾
        if (gaugeController == null)
            {
            Debug.LogError("GaugeController��������܂���I");
            return;
            }

        }

    private void Update()
        {
        if (currentState != null)
            {
            currentState.UpdateState(this);
            }
        else
            {
            Debug.LogError("Current state is null!");
            return;
            }

        if (gaugeController.GetCurrentHP() <= 0)
            {
            //���S�x����Ԃɐ؂�ւ�
             ChangeState(dyingState);
            }

        // ���N���b�N��������Ă���ԁAGuideState �ɑJ��
        if (Input.GetMouseButtonDown(0))
            {
            isClickDown = true;
            if (guidingState != null)
                {
                ChangeState(guidingState); // Guiding ��ԂɕύX
                }
            else
                {
                Debug.LogError("Guiding state is not assigned.");
                }
            }
        //if (Input.GetMouseButtonUp(0))
        //    {
        //    isClickDown = false;
        //    if (idleState != null)
        //        {
        //        ChangeState(idleState); // ���N���b�N�𗣂����� Idle ��Ԃɖ߂�
        //        }
        //    else
        //        {
        //        Debug.LogError("Idle state is not assigned.");
        //        }
        //    }


        if (Input.GetMouseButtonUp(0))
            {
            isClickDown = false;
            if (currentState != dyingState) // Dying��Ԃł͂Ȃ��Ƃ��̂�Idle��
                {
                if (idleState != null)
                    {
                    ChangeState(idleState); // ���N���b�N�𗣂����� Idle ��Ԃɖ߂�
                    }
                else
                    {
                    Debug.LogError("Idle state is not assigned.");
                    }
                }
            }


        // �E�N���b�N�������ꂽ�ꍇ�A�����N���b�N��������Ă���ꍇ�� Shooting ��ԂɑJ��
        if (isClickDown && Input.GetMouseButtonDown(1))
            {
            if (shootingState != null)
                {
                ChangeState(shootingState);
                }
            else
                {
                Debug.LogError("Shooting state is not assigned.");
                }
            }

        // �ړ��L�[��������Ă���ꍇ�� Moving ��ԂɕύX
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
            if (movingState != null)
                {
                ChangeState(movingState);
                }
            else
                {
                Debug.LogError("Moving state is not assigned.");
                }
            }
        }

    public void ChangeState(IPlayerState newState)
        {
        if (newState != null && currentState != newState)
            {
            currentState?.ExitState(this);
            currentState = newState;
            currentState.EnterState(this);
            }
        else
            {
            Debug.LogWarning("New state is the same as the current state or is null.");
            }
        }
    }
