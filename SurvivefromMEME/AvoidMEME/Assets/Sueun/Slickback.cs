using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slickback : MonoBehaviour

/* �ϴ� ������� �����̴� �� êGPT ������ �ڵ� ®�µ� �� ���� ���� �� ���� �������� �� �Ѿ��...
�����غôµ�
1. �����̶� ������Ʈ �� ���� ��ũ��Ʈ �־ �׷���? 
   �� �߿����� void start/Update�������� ������...

2. �׷��� slickback ��ũ��Ʈ�� �ִ� �ڵ����
   Pattern_Slickback�� �־���ϴµ� ��� �־������,,,

�� ������ �����غ� ���
1. Process Coroutine�� �� �����ڴ´� > �ȵʤ� (���� ���ϴ� �ɼ���)
2. ���ο� Coroutine�� ����� > ��Ƴ׿�... 
3. �׳� �� �� �� �� ����? ���� �����ôµ� > not all code paths return a value ��� ������ ����
   ��� �ߴ��� �ñ��Ͻø� �翬�ص帮�ڽ��ϴ� ����...
   ��� if�� return�� �����Ѵ�?�� �� ������ �� �־������,,,��
4. �߻��� ��ȯ���� ���� ���� ������Ʈ ��ũ��Ʈ�� �� �־��
   > ������ ���...

 ��� : slickback ��ũ��Ʈ�� �ִ� �ڵ���� Pattern_Slickback�� �ְ������
 void start�� Update�� �ִ� �ڵ���� ��� �Űܾ��� �� �𸣰ھ
*/
{
    [SerializeField]
    private GameObject warningImage; 
    [SerializeField]
    private GameObject slickback;
    [SerializeField]
    public AudioSource slickbackBGM;
    [SerializeField]
    private float startSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private Rigidbody2D objectRigidbody2d;
    [SerializeField]
    private float cooldownTime; // �浹 ��Ÿ��

    private bool canBounce = true;

    private Vector3 initialPosition;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }

    void Start()
    {
        float randomX, randomY;
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);

        Vector2 vector2 = new Vector2(randomX, randomY);
        vector2 = vector2.normalized;

       
        objectRigidbody2d.velocity = vector2 * startSpeed; // �ӵ��� 20���� ����
    }

    void Update()
    {
        Vector2 currentVelocity = objectRigidbody2d.velocity;

        // ���� �ӵ� ������ ũ�Ⱑ �ִ� �ӵ��� ���� �ʵ��� ����
        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
            objectRigidbody2d.velocity = currentVelocity;
        }

        Vector3 position = transform.position;

        float minX = -8f;
        float maxX = 8f;
        float minY = -2f;
        float maxY = 3f;

    
        if (canBounce)
        {
            if (position.x < minX || position.x > maxX || position.y < minY || position.y > maxY)
            {
                // ��迡 ����� ��
                // ������ ������ ƨ���
                float randomBounceAngle = Random.Range(30f, 150f);
                Vector2 newVelocity = Quaternion.Euler(0, 0, randomBounceAngle) * currentVelocity.normalized * maxSpeed;
                objectRigidbody2d.velocity = newVelocity;

                canBounce = false; // �浹 ���� ����
                StartCoroutine(Cooldown());
            }
        }
        else
        {
            // ��踦 ����� ���� ����
            float newX = Mathf.Clamp(position.x, minX, maxX);
            float newY = Mathf.Clamp(position.y, minY, maxY);
            transform.position = new Vector3(newX, newY, position.z);
        }
    }


    private IEnumerator Process()
    {
        objectRigidbody2d = GetComponent<Rigidbody2D>(); // Rigidbody2D ������Ʈ �ʱ�ȭ

        //slickbackBGM.Play();

        yield return new WaitForSeconds(1f);


        slickback.SetActive(true);

        yield return new WaitForSeconds(10f);

        gameObject.SetActive(false);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canBounce = true; // ���� �ð� �� �ٽ� �浹 ���� ���·� ����
    }

 
}