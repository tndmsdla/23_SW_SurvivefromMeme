using System.Collections;
using UnityEngine;

public class PatternBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImage; // 경고 이미지



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
        for (int i = 0; i < 2; i++) warningImage[i].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 2; i++) warningImage[i].SetActive(false);

        yield return new WaitForSeconds(1);



        // 패턴 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
