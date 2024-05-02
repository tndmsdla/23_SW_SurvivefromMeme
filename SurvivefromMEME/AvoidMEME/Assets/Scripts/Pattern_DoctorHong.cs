using System.Collections;
using UnityEngine;

public class Pattern_DoctorHong : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImage; // 경고 이미지
    [SerializeField]
    private GameObject[] doctorHong; // 홍박사 이미지(좌, 우 반전 1개씩) 
    [SerializeField]
    private float spawnCycle; // 생성 주기
    [SerializeField]
    private int maxCount; // 등장 횟수

    public AudioSource bgmHong; // 홍박사 브금

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


        // 홍박사 등장 및 이동(1)
      
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
        // 홍박사 등장 및 이동(2)

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

        // 홍박사 등장 및 이동(3 - 홍홍)

        // 플레이어의 등장 위치 겹치지 않는 임의의 위치로 설정
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
        

        // 3번까지는 박자 맞아.

        yield return new WaitForSeconds(2.3f);
        doctorHong[3].SetActive(false);
        doctorHong[3].GetComponent<MovingEntity>().Reset();

        // 홍박사 등장 및 이동(4)

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
        // 홍박사 등장 및 이동(5)

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


        // 홍박사 등장 및 이동(6 - 홍홍)

        // 플레이어의 등장 위치 겹치지 않는 임의의 위치로 설정
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
        // 패턴 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
