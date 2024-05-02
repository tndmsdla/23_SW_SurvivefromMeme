using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject HpPotion;


    public SpriteRenderer sprite;

    private PlayerShield playershield;
    private MovementRigidbody2D movement2D;
    private PlayerHP playerHP;
    public GameObject shield;

    public int PlayerCode = 0; // 플레이어 코드 0: 디폴트 1: 커비 2: 전사 3: 도적
    //private float shield_cooldown = 60f; // 쉴드 쿨타임
    //private bool shield_access = true; // 쉴드 접근 가능 여부(쿨타임 지나면 true)

    private Animator animator;

    public Vector2 Attack1 = new Vector2(0,0);
    public Vector2 Attack2 = new Vector2(0, 0);
    public bool attackState = false;
    private bool attackPossible = true;
    [SerializeField]
    public float attackCooldown = 30f;

    private float coefficient = 3f; // 전사 스킬 범위 계수 -> 에 따라서 prefab 삭제 범위 달라짐

    private void Awake()
    {
        movement2D = GetComponent<MovementRigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerHP = GetComponent<PlayerHP>();
        playershield = GetComponent<PlayerShield>();
    }
    private void Update()
    {
        if (gameController.IsGamePlay == false) return;
        PlayerCode = gameController.AvatarIndex; // 플레이어 아바타 코드를 받아온다.
        UpdateMove();
        UpdateJump();
        // StartCoroutine(nameof(UpdateShield));
        if (Input.GetKeyDown(KeyCode.X))
        {
            UpdateAttack();
        }
    }

    // PlayerShield처럼 Attack도 따로 구현해줄 예정

    private void UpdateAttack()
    {
        if (PlayerCode == 2)
        {
            PlayerAttack Instance = GameObject.Find("Player_HeroKnight").GetComponent<PlayerAttack>();
            if (attackPossible == true)
            {
                float x;
                if (sprite.flipX == true) x = -1;
                else x = 1;
                Attack1.x = transform.position.x + coefficient * x;
                Attack1.y = transform.position.y + coefficient * 1;
                Attack2 = movement2D.GetFootPosition();
                attackState = true;
                attackPossible = false;
                StartCoroutine(nameof(attackMotion));
            }
        }
    }

    IEnumerator attackMotion()
    {
        Debug.Log("공격 모션");
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(1f);
        attackState = false;
        animator.SetBool("isAttack", false);
        yield return new WaitForSeconds(20f);
        attackPossible = true;    
    }

    private void UpdateMove()
    {
        
        // left, a = -1 / none = 0 / right, d = +1
        float x = Input.GetAxisRaw("Horizontal");

        if (x == -1)
        {
            sprite.flipX = true;
            animator.SetBool("isRun", true);
            //animator.SetTrigger("Run");
        }
        else if (x == 1)
        {
            sprite.flipX = false;
            animator.SetBool("isRun", true);
            //animator.SetTrigger("Run");
        }
        else
        {
            animator.SetBool("isRun", false);
        }

        // 좌우 이동
        movement2D.MoveTo(x);
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            animator.SetBool("isAttack", false);
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

    // edge collider 2D는 못 받아들임 이유는 모르게음
    // 그래서 전사도 box collider2D로 변경
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("충돌 감지");
        if (collision.CompareTag("Obstacle") && !playershield.ShieldCondition)
        {
            Debug.Log("가능");
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
                Debug.Log("풀피");

        }
    }
}
