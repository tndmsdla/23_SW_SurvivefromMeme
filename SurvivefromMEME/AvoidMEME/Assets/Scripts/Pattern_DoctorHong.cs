using System.Collections;
using UnityEngine;

public class Pattern_DoctorHong : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImage; // ��� �̹���
    [SerializeField]
    private GameObject[] doctorHong; // ȫ�ڻ� �̹���(��, �� ���� 1����) 
    [SerializeField]
    private float spawnCycle; // ���� �ֱ�
    [SerializeField]
    private int maxCount; // ���� Ƚ��

    public AudioSource bgmHong; // ȫ�ڻ� ���

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));

        bgmHong.Play();
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }


    private IEnumerator Process()
    { 
        yield return new WaitForSeconds(3.9f);


        // ȫ�ڻ� ���� �� �̵�(1)
      
        for (int i = 0; i < 3; i++)
        {
            warningImage[i].SetActive(true);

            yield return new WaitForSeconds(0.1f);

            doctorHong[i].SetActive(true);
            doctorHong[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);

            warningImage[i].SetActive(false);
        }

        for (int i = 0; i < 3; i++)
        {
            doctorHong[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.down);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < doctorHong.Length; i++)
        {
            doctorHong[i].SetActive(false);
            doctorHong[i].GetComponent<MovingEntity>().Reset();
        }
        yield return new WaitForSeconds(0.2f);
        // ȫ�ڻ� ���� �� �̵�(2)

        for (int i = 0; i < 3; i++)
        {
            warningImage[i].SetActive(true);

            yield return new WaitForSeconds(0.1f);

            doctorHong[i].SetActive(true);
            doctorHong[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);

            warningImage[i].SetActive(false);
        }

        for (int i = 0; i < 3; i++)
        {
            doctorHong[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.down);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < doctorHong.Length; i++)
        {
            doctorHong[i].SetActive(false);
            doctorHong[i].GetComponent<MovingEntity>().Reset();
        }


        yield return new WaitForSeconds(0.2f);

        // ȫ�ڻ� ���� �� �̵�(3 - ȫȫ)

        // �÷��̾��� ���� ��ġ ��ġ�� �ʴ� ������ ��ġ�� ����
        int[] numbers = Utils.RandomNumbers(3, 2);


        for (int i = 0; i < 2; i++)
        {
            warningImage[numbers[i]].SetActive(true);

            yield return new WaitForSeconds(0.1f);

            doctorHong[numbers[i]].SetActive(true);
            doctorHong[numbers[i]].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);

            warningImage[numbers[i]].SetActive(false);
        }

        for (int i = 0; i < 2; i++)
        {
            doctorHong[numbers[i]].GetComponent<MovementTransform2D>().MoveTo(Vector3.down);
            yield return new WaitForSeconds(0.1f);
        }


        doctorHong[3].SetActive(true);
        doctorHong[3].GetComponent<MovementTransform2D>().MoveTo(Vector3.right);


        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 2; i++)
        {
            doctorHong[numbers[i]].SetActive(false);
            doctorHong[numbers[i]].GetComponent<MovingEntity>().Reset();
        }
        

        // 3�������� ���� �¾�.

        yield return new WaitForSeconds(2.3f);
        doctorHong[3].SetActive(false);
        doctorHong[3].GetComponent<MovingEntity>().Reset();

        // ȫ�ڻ� ���� �� �̵�(4)

        for (int i = 0; i < 3; i++)
        {
            warningImage[i].SetActive(true);

            yield return new WaitForSeconds(0.1f);

            doctorHong[i].SetActive(true);
            doctorHong[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);

            warningImage[i].SetActive(false);
        }

        for (int i = 0; i < 3; i++)
        {
            doctorHong[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.down);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < doctorHong.Length; i++)
        {
            doctorHong[i].SetActive(false);
            doctorHong[i].GetComponent<MovingEntity>().Reset();
        }

        yield return new WaitForSeconds(0.1f);
        // ȫ�ڻ� ���� �� �̵�(5)

        for (int i = 0; i < 3; i++)
        {
            warningImage[i].SetActive(true);

            yield return new WaitForSeconds(0.1f);

            doctorHong[i].SetActive(true);
            doctorHong[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);

            warningImage[i].SetActive(false);
        }

        for (int i = 0; i < 3; i++)
        {
            doctorHong[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.down);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < doctorHong.Length; i++)
        {
            doctorHong[i].SetActive(false);
            doctorHong[i].GetComponent<MovingEntity>().Reset();
        }
        yield return new WaitForSeconds(0.3f);


        // ȫ�ڻ� ���� �� �̵�(6 - ȫȫ)

        // �÷��̾��� ���� ��ġ ��ġ�� �ʴ� ������ ��ġ�� ����
        int[] numbers2 = Utils.RandomNumbers(3, 2);


        for (int i = 0; i < 2; i++)
        {
            warningImage[numbers2[i]].SetActive(true);

            yield return new WaitForSeconds(0.1f);

            doctorHong[numbers2[i]].SetActive(true);
            doctorHong[numbers2[i]].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);

            warningImage[numbers2[i]].SetActive(false);
        }

        for (int i = 0; i < 2; i++)
        {
            doctorHong[numbers2[i]].GetComponent<MovementTransform2D>().MoveTo(Vector3.down);
            yield return new WaitForSeconds(0.1f);
        }

        doctorHong[4].SetActive(true);
        doctorHong[4].GetComponent<MovementTransform2D>().MoveTo(Vector3.left);

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 2; i++)
        {
            doctorHong[numbers2[i]].SetActive(false);
            doctorHong[numbers2[i]].GetComponent<MovingEntity>().Reset();
        }
        
        yield return new WaitForSeconds(2f);

        doctorHong[4].SetActive(false);
        doctorHong[4].GetComponent<MovingEntity>().Reset();
        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
