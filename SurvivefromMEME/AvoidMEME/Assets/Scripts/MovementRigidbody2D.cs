using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MovementRigidbody2D : MonoBehaviour
{
    [Header("Move Horizontal")]
    [SerializeField]
    private float moveSpeed = 8; // �̵� �ӵ�

    [Header("Move Vertical (Jump)")]
    [SerializeField]
    private float jumpForce = 10; // ���� ��
    [SerializeField]
    private float lowGravity = 2; // ���� Ű�� ���� ������ ���� �� ����Ǵ� ���� �߷�
    [SerializeField]
    private float highGrvaity = 3; // �Ϲ������� ����Ǵ� ���� �߷� ���
    [SerializeField]
    private int maxJumpCount = 2; // �ִ� ���� Ƚ��
    private int currentJumpCount; // ���� �����ִ� ���� Ƚ��

    [Header("Collision")]
    [SerializeField]
    private LayerMask groundLayer; // �ٴ� �浹 üũ�� ���� ���̾�

    public bool isGrounded; // �ٴ� üũ (�ٴڿ� �÷��̾��� ���� ������� �� true)
    private Vector2 footPosition; // �ٴ� üũ�� ���� �÷��̾� �� ��ġ
    private Vector2 footArea; // �ٴ� üũ�� ���� �÷��̾� �� �ν� ����


    private Rigidbody2D rigid2D; // �ӷ� ��� ���� Rigidbody2D
    private new Collider2D collider2D; // ���� ������Ʈ�� �浹 ����

    public bool IsLongJump { set; get; } = false;

    private Animator animator;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();

        animator = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        float x = Mathf.Clamp(transform.position.x, Constants.min.x, Constants.max.x);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        // �÷��̾� ������Ʈ�� Collider2D min, center, max ��ġ ����
        Bounds bounds = collider2D.bounds;
        // �÷��̾��� �� ��ġ ����
        footPosition = new Vector2(bounds.center.x, bounds.min.y);
        // �÷��̾��� �� �ν� ���� ����
        footArea = new Vector2((bounds.max.x - bounds.min.x)*0.5f, 0.1f);
        // �÷��̾��� �� ��ġ�� �ڽ��� �����ϰ�, �ڽ��� �ٴڰ� ��������� isGrounded = true
        isGrounded = Physics2D.OverlapBox(footPosition, footArea, 0, groundLayer);

        // �÷��̾��� ���� ���� ��� �ְ�, y�� �ӷ��� 0�����̸� ���� Ƚ�� �ʱ�ȭ
        // y�� �ӷ��� + ���̸� ������ �ϴ� ��..
        if (isGrounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJump", false);
        }

        // ���� ����, ���� ���� ������ ���� �߷� ���(gravityScale) ���� (Jump Up�� ���� ����)
        // �߷� ����� ���� if ���� ���� ������ �ǰ�, �߷� ����� ���� else ���� ���� ������ �ȴ�.
        if (IsLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = lowGravity;
        }
        else
        {
            rigid2D.gravityScale = highGrvaity;
        }
    }
    ///<summary>
    /// x �̵� ���� ���� (�ܺ� Ŭ�������� ȣ��)
    /// </summary>

    public void MoveTo(float x)
    {
        rigid2D.velocity = new Vector2(x * moveSpeed, rigid2D.velocity.y);
    }

    public Vector2 GetFootPosition()
    {
        return footPosition;
    }

    /// <summary>
    /// ���� (�ܺ� Ŭ�������� ȣ��)
    /// </summary>
    
    public bool JumpTo()
    {
        if (currentJumpCount > 0) 
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpForce);
            currentJumpCount--;
            animator.SetBool("isJump", true);
            animator.SetBool("isGrounded", false);
//            animator.SetTrigger("Jump");
            return true;
        }
        return false;
    }
}
