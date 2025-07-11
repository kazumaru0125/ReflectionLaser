using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
    {
    private Animator animator;

    void Start()
        {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
        }

    void Update()
        {
        // 入力があれば移動中と判定（WASD対応）
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool isMoving = horizontal != 0 || vertical != 0;

        // アニメーションの切り替え（IsMovingはAnimatorで設定したパラメータ名）
        animator.SetBool("IsMoving", isMoving);
        }
    }
