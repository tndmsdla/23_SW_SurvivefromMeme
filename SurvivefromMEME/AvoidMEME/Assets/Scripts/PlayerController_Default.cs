using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_Default : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    private GameController gameController;

    [SerializeField]
    private GameObject HpPotion;

    private SpriteRenderer sprite;

    private MovementRigidbody2D_Default movement2D;
    private PlayerHP playerHP;
    //private float shield_cooldown = 60f; // 쉴드 쿨타임
    //private bool shield_access = true; // 쉴드 접근 가능 여부(쿨타임 지나면 true)

    private Animator animator;

    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D_Default>();
        sprite = GetComponent<SpriteRenderer>();
        playerHP = GetComponent<PlayerHP>();
    }
    private void Update()
    {
        if (gameController.IsGamePlay == false) return;
        UpdateMove();
        UpdateJump();
        // StartCoroutine(nameof(UpdateShield));
    }

    private void UpdateMove()
    {
        // left, a = -1 / none = 0 / right, d = +1
        float x = Input.GetAxisRaw("Horizontal");

        if (x == -1)
        {
            sprite.flipX = true;
        }
        else if (x == 1)
        {
            sprite.flipX = false;
        }
        // 좌우 이동
        movement2D.MoveTo(x);
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            movement2D.JumpTo();
        }
        else if (Input.GetKeyDown(jumpKey))
        {
            movement2D.IsLongJump = true;
        }
        else if (Input.GetKeyUp(jumpKey))
        {
            movement2D.IsLongJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            bool isDie = playerHP.TakeDamage();
            if (isDie == true)
            {
                GetComponent<Collider2D>().enabled = false;
                gameController.GameOver();
            }
        }

        else if (collision.CompareTag("Ground"))
        {
            animator.SetBool("isGrounded", true);
        }

        else if (collision.CompareTag("HpPotion"))
        {
            HpPotion.SetActive(false);
            if (playerHP.RecoveryHP())
                Debug.Log("체력 회복");
            else
                gameController.PlusScore(500f);

        }
    }
}
