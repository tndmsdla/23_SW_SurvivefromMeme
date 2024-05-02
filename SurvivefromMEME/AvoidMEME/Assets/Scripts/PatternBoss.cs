using System.Collections;
using UnityEngine;

public class PatternBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImage; // ��� �̹���



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

        // ��� �̹��� 0.5�� ���� Ȱ�� �� ��Ȱ��ȭ
        for (int i = 0; i < 2; i++) warningImage[i].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 2; i++) warningImage[i].SetActive(false);

        yield return new WaitForSeconds(1);



        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
