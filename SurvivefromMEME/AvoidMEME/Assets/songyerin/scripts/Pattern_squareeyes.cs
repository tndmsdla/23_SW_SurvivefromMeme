using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_squareeyes : MonoBehaviour
{
    
    [SerializeField]
    private MovementTransform2D YW; //����

    [SerializeField]
    private GameObject[] eyesProjectile; // ���� �߻�ü

    [SerializeField]
    private GameObject[] eyes; // ���� �߻�ü

    [SerializeField]
    private GameObject[] warningImages; // ���� �߻�ü

    [SerializeField]
    private float attackRate = 1;
    [SerializeField]
    private int maxFireCount = 5;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }
    private void OnDisable()
    {
        eyes[0].GetComponent<MovingEntity>().Reset();
        eyes[1].GetComponent<MovingEntity>().Reset();
        eyes[2].GetComponent<MovingEntity>().Reset();
        YW.GetComponent<MovingEntity>().Reset();



        StopCoroutine(nameof(Process));
    }
    private IEnumerator Process()
    {
        // ���� ���� �� ��� �ð�
        yield return new WaitForSeconds(0.2f);

        // ����̹���
        warningImages[0].SetActive(true);

        yield return new WaitForSeconds(0.1f);
        warningImages[0].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        if (warningImages[0].activeSelf == false)
        {
            warningImages[1].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            warningImages[1].SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
        if (warningImages[1].activeSelf == false)
        {
            warningImages[2].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            warningImages[2].SetActive(false);
        }
        


        // �¿� �̵�
        yield return StartCoroutine(nameof(MoveLeftAndRight));
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(nameof(MoveLeftAndRight2));
        yield return new WaitForSeconds(0.1f);
        yield return StartCoroutine(nameof(MoveLeftAndRight3));
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(nameof(MoveLeftAndRight4));
        yield return new WaitForSeconds(1f);


       
        yield return new WaitForSeconds(1f);
        CircleFire();
        yield return new WaitForSeconds(2f);
        CircleFire();
        yield return StartCoroutine(nameof(SpawnProjectile));
        yield return new WaitForSeconds(1f);
        CircleFire();
        yield return new WaitForSeconds(2.7f);
        CircleFire();
        yield return StartCoroutine(nameof(SpawnProjectile2));
        yield return new WaitForSeconds(2f);
        CircleFire();
        yield return new WaitForSeconds(2f);
        CircleFire();
        yield return StartCoroutine(nameof(SpawnProjectile3));
        yield return new WaitForSeconds(2f);
        CircleFire();


        yield return new WaitForSeconds(2f);

        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    

    private IEnumerator MoveLeftAndRight()
    {
        eyes[0].SetActive(true);
        Vector3 direction = Random.Range(0, 2) == 0 ? Vector3.left : Vector3. right;
       
        eyes[0].GetComponent<MovementTransform2D>().MoveTo(Vector3.right);

        eyesProjectile[0].SetActive(true);

        int count = 5; // �߻�ü ���� ����
        float intervalAngle = 360 / count; // �߻�ü �þ��� ����

        // �� ���·� ����ϴ� �߻�ü ���� ( count ���� ��ŭ)
        for (int i = 0; i < count; i++)
        {
            // �߻�ü ����
            GameObject clone = Instantiate(eyesProjectile[0], eyes[0].transform.position, Quaternion.identity);


            // �߻�ü �̵� ����(����)
            float angle = intervalAngle * i;

            // �߻�ü �̵� ����(����)
            float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // cos(����), ���� ������ ���� ǥ���� ���� PI/180�� ������
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f); // sin(����)

            // �߻�ü �̵� ���� ����
            clone.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x, y));
        }
        while (true)
        {
            eyesProjectile[0].SetActive(false);
            if (eyes[0].transform.position.x < Constants.min.x ||
               eyes[0].transform.position.x > Constants.max.x )
            {
                eyes[0].gameObject.SetActive(false);
               
                yield break;
            }
            yield return null;
        }

        
    }

    private IEnumerator MoveLeftAndRight2()
    {
        eyes[1].SetActive(true);

        Vector3 direction = Random.Range(0, 2) == 0 ? Vector3.left : Vector3.right;

        eyes[1].GetComponent<MovementTransform2D>().MoveTo(Vector3.left);

        eyesProjectile[1].SetActive(true);

        int count = 5; // �߻�ü ���� ����
        float intervalAngle = 360 / count; // �߻�ü �þ��� ����

        // �� ���·� ����ϴ� �߻�ü ���� ( count ���� ��ŭ)
        for (int i = 0; i < count; i++)
        {
            // �߻�ü ����
            GameObject clone = Instantiate(eyesProjectile[1], eyes[1].transform.position, Quaternion.identity);


            // �߻�ü �̵� ����(����)
            float angle = intervalAngle * i;

            // �߻�ü �̵� ����(����)
            float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // cos(����), ���� ������ ���� ǥ���� ���� PI/180�� ������
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f); // sin(����)

            // �߻�ü �̵� ���� ����
            clone.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x, y));
        }
        while (true)
        {
            eyesProjectile[1].SetActive(false);
            if (eyes[1].transform.position.x < Constants.min.x ||
               eyes[1].transform.position.x > Constants.max.x)
            {
                eyes[1].gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }


    }

    private IEnumerator MoveLeftAndRight3()
    {
        eyes[2].SetActive(true);

        Vector3 direction = Random.Range(0, 2) == 0 ? Vector3.left : Vector3.right;

        eyes[2].GetComponent<MovementTransform2D>().MoveTo(Vector3.right);

        eyesProjectile[2].SetActive(true);

        int count = 5; // �߻�ü ���� ����
        float intervalAngle = 360 / count; // �߻�ü �þ��� ����

        // �� ���·� ����ϴ� �߻�ü ���� ( count ���� ��ŭ)
        for (int i = 0; i < count; i++)
        {
            // �߻�ü ����
            GameObject clone = Instantiate(eyesProjectile[2], eyes[2].transform.position, Quaternion.identity);


            // �߻�ü �̵� ����(����)
            float angle = intervalAngle * i;

            // �߻�ü �̵� ����(����)
            float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // cos(����), ���� ������ ���� ǥ���� ���� PI/180�� ������
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f); // sin(����)

            // �߻�ü �̵� ���� ����
            clone.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x, y));
        }
        while (true)
        {
            eyesProjectile[2].SetActive(false);
            if (eyes[2].transform.position.x < Constants.min.x ||
               eyes[2].transform.position.x > Constants.max.x)
            {
                eyes[2].gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }


    }
    private IEnumerator MoveLeftAndRight4()
    {
        YW.gameObject.SetActive(true);

        // ���� ������Ʈ�� �� �ٱ����� �̵����� �ʵ��� �ϴ� ����ġ ��
        float xWeight = 3;

        // ó�� �̵� ������ ���������� ����
        YW.MoveTo(Vector3.right);

        while (true)
        {
            eyesProjectile[3].SetActive(false);
            // ������ ��ġ�� ���� �ּ� ������ �Ѿ�� �̵� ������ ���������� ����
            if (YW.transform.position.x <= Constants.min.x + xWeight)
            {
                YW.MoveTo(Vector3.right);
            }

            // ������ ��ġ�� ������ �ִ� ������ �Ѿ�� �̵� ������ �������� ����
            if (YW.transform.position.x >= Constants.max.x - xWeight)
            {
                YW.MoveTo(Vector3.left);
            }

            yield return null;
        }
    }
    private void CircleFire()
    {
        eyesProjectile[3].SetActive(true);
       

        int count = 5; // �߻�ü ���� ����
        float intervalAngle = 360 / count; // �߻�ü �þ��� ����

        // �� ���·� ����ϴ� �߻�ü ���� ( count ���� ��ŭ)
        for (int i = 0; i < count; i++)
        {
            // �߻�ü ����
            GameObject clone = Instantiate(eyesProjectile[3],YW.transform.position, Quaternion.identity);
          
            // �߻�ü �̵� ����(����)
            float angle = intervalAngle *i;

            // �߻�ü �̵� ����(����)
            float x = Mathf.Cos(angle * Mathf.PI / 180.0f); // cos(����), ���� ������ ���� ǥ���� ���� PI/180�� ������
            float y = Mathf.Sin(angle * Mathf.PI / 180.0f); // sin(����)

            // �߻�ü �̵� ���� ����
            clone.GetComponent<MovementTransform2D>().MoveTo(new Vector2(x, y));
        }
    }
    private IEnumerator SpawnProjectile()
    {
        float minspeed = 13;
        float maxspeed = 20;


        int count = 0;
        while (count < 2)
        {

            eyesProjectile[4].SetActive(true);
            GameObject clone = Instantiate(eyesProjectile[4], YW.transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;
            yield return null;


        }


    }
    private IEnumerator SpawnProjectile2()
    {
        float minspeed = 13;
        float maxspeed = 20;


        int count = 0;
        while (count < 2)
        {

            eyesProjectile[5].SetActive(true);
            GameObject clone = Instantiate(eyesProjectile[5], YW.transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;
            yield return null;


        }


    }
    private IEnumerator SpawnProjectile3()
    {
        float minspeed = 13;
        float maxspeed = 20;


        int count = 0;
        while (count < 2)
        {

            eyesProjectile[6].SetActive(true);
            GameObject clone = Instantiate(eyesProjectile[6], YW.transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;
            yield return null;


        }


    }
}
