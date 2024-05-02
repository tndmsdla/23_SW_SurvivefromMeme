using System.Collections;
using UnityEngine;

public class Pattern_EyeBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImage; // 경고 이미지
    [SerializeField]
    private GameObject ground; // 추가 블럭 지형
    [SerializeField]
    private GameObject eyeboss; // 맑눈광
    [SerializeField]
    private GameObject laser; // 맑눈광 눈 위치 레이저
    [SerializeField]
    private Collider2D[] laserCollider2D; // 레이저의 충돌 감지 Collider2D
    [SerializeField]
    private float rotateTime; // 회전 시간
    [SerializeField]
    private int anglePerSeconds; // 초당 회전 각도

    public AudioSource cleareye; // 맑눈광 등장 음악
    public AudioSource lasersound; // 레이저 효과음

    [SerializeField]
    private GameObject[] ps;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }


    private IEnumerator Process()
    {

        // 경고 이미지 0.5초 동안 활성 후 비활성화
        for (int i = 0; i < 2; i++)  warningImage[i].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        for (int i=0; i<2; i++)  warningImage[i].SetActive(false);

        yield return new WaitForSeconds(1);

        // 발판, 맑눈광, 레이저 활성화
        ground.SetActive(true);
        eyeboss.SetActive(true);
        laser.SetActive(true);

        for (int i=0; i<ps.Length; i++)
        {
            ps[i].SetActive(true);
        }

        cleareye.Play();
        lasersound.Play();

        // 레이저가 등장하자마자 플레이어와 충돌하지 않도록 Collider2D를 잠시 비활성화
        for (int i = 0; i < laserCollider2D.Length; ++i)
        {
            laserCollider2D[i].enabled = false;
        }

        // 레이저가 등장하고 잠시 대기하는 시간
        yield return new WaitForSeconds(0.5f);

        // 레이저의 Collider2D 활성화
        for (int i = 0; i < laserCollider2D.Length; ++i)
        {
            laserCollider2D[i].enabled = true;
        }

        // 레이저 회전 (시간)
        float time = 0;
        while (time < rotateTime)
        {
            laser.transform.Rotate(Vector3.forward * anglePerSeconds * Time.deltaTime);

            time += Time.deltaTime;

            yield return null;
        }

        time = 0;

        while (time < rotateTime)
        {
            laser.transform.Rotate(Vector3.back * anglePerSeconds * Time.deltaTime);

            time += Time.deltaTime;

            yield return null;
        }

        // 종료 시 레이저, 맑눈광, 발판 비활성화
        cleareye.Stop();
        ground.SetActive(false);
        eyeboss.SetActive(false);
        laser.SetActive(false);
        for (int i = 0; i < ps.Length; i++)
        {
            ps[i].SetActive(false);
        }


        // 패턴 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
