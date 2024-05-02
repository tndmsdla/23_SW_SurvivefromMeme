using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    [SerializeField]
    private GameObject warningImage; // 경고 이미지
    [SerializeField]
    private Transform boom;
    [SerializeField]
    private GameObject boomEffect; // 폭탄 이벤트

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        boom.GetComponent<MovingEntity>().Reset();

        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        // 패턴 시작 전 대기 시간
        yield return new WaitForSeconds(1);

        // 경고 이미지 활성 후 비활성화

        warningImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImage.SetActive(false);

        // 폭탄 오브젝트 활성화 & 이동

        yield return StartCoroutine(nameof(MoveUp));

        // 폭탄 이벤트 활성 후 비활성화
        boomEffect.SetActive(true);
        yield return new WaitForSeconds(1);
        boomEffect.SetActive(false);

        // 패턴 오브젝트 비활성화
        gameObject.SetActive(false);
    }

    private IEnumerator MoveUp()
    {
        // 목표 위치
        float boomDestiantionY = 0;

        // 폭탄 오브젝트 활성화
        boom.gameObject.SetActive(true);

        // 폭탄이 목표까지 이동했는지 확인
        while (true)
        {
            if (boom.transform.position.y >= boomDestiantionY)
            {
                // 폭탄 오브젝트 비활성화
                boom.gameObject.SetActive(false);

                yield break;
            }
            yield return null;
        }
    }
}
