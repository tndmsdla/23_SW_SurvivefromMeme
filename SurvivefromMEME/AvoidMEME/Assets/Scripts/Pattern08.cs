using System.Collections;
using UnityEngine;



public class Pattern08 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImage; // 경고 이미지
    [SerializeField]
    private GameObject[] sojubeer;
    [SerializeField]
    private float spawnCycle; // 생성 주기

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        // 다음 사용을 위해 플레이어 오브젝트의 상태 초기화
        for (int i = 0; i < sojubeer.Length; i++)
        {
            sojubeer[i].SetActive(false);
            sojubeer[i].GetComponent<MovingEntity>().Reset();
        }

        StopCoroutine(nameof(Process));

    }


    private IEnumerator Process()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 6; i++)
        {
            warningImage[i].SetActive(true);

            yield return new WaitForSeconds(0.1f);

            sojubeer[i].SetActive(true);
            sojubeer[6-i].SetActive(true);
            sojubeer[i].GetComponent<MovementTransform2D>().MoveTo(Vector3.down);
            sojubeer[6 - i].GetComponent<MovementTransform2D>().MoveTo(Vector3.down);
            warningImage[i].SetActive(false);
        }

        // 패턴 종료 전 잠시 대기하는 시간
        yield return new WaitForSeconds(1);

        // 패턴 오브젝트 비활성화
        gameObject.SetActive(false);
    }




    private IEnumerator SpawnPlayer(int index)
    {
        // 경고 이미지 활성, 비활성화
        warningImage[index].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        warningImage[index].SetActive(false);

        // 플레이어 오브젝트 활성화
        sojubeer[index].SetActive(true);
    }
}
        
    

