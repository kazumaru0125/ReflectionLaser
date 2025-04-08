using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
    {
    //PlayerのState関係
    private IPlayerState       currentState;


    public PlayerIdlingState   idleState      = new PlayerIdlingState();

    public PlayerMovingState   movingState    = new PlayerMovingState();
    public PlayerShootingState shootingState  = new PlayerShootingState();
    public PlayerGuidingState  guidingState   = new PlayerGuidingState();
    public PlayerDyingState    dyingState     = new PlayerDyingState();

    //外部Class
    private GaugeController gaugeController; // HP管理クラス

    private bool isClickDown = false; // 左クリックが押されているか

    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;

    private void Start()
        {
        // 状態を初期化する
        if (idleState != null)
            {
            currentState = idleState;
            currentState.EnterState(this);
            }
        else
            {
            Debug.LogError("Idle state is not assigned.");
            }


              gaugeController = FindObjectOfType<GaugeController>(); // HP管理クラスを取得
        if (gaugeController == null)
            {
            Debug.LogError("GaugeControllerが見つかりません！");
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
            //死亡警告状態に切り替え
             ChangeState(dyingState);
            }

        // 左クリックが押されている間、GuideState に遷移
        if (Input.GetMouseButtonDown(0))
            {
            isClickDown = true;
            if (guidingState != null)
                {
                ChangeState(guidingState); // Guiding 状態に変更
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
        //        ChangeState(idleState); // 左クリックを離したら Idle 状態に戻る
        //        }
        //    else
        //        {
        //        Debug.LogError("Idle state is not assigned.");
        //        }
        //    }


        if (Input.GetMouseButtonUp(0))
            {
            isClickDown = false;
            if (currentState != dyingState) // Dying状態ではないときのみIdleへ
                {
                if (idleState != null)
                    {
                    ChangeState(idleState); // 左クリックを離したら Idle 状態に戻る
                    }
                else
                    {
                    Debug.LogError("Idle state is not assigned.");
                    }
                }
            }


        // 右クリックが押された場合、かつ左クリックが押されている場合に Shooting 状態に遷移
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

        // 移動キーが押されている場合は Moving 状態に変更
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
