using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern03 : MonoBehaviour
{
    [SerializeField]
    private GameObject warningImage; // ��� �̹���
    [SerializeField]
    private Transform boom;
    [SerializeField]
    private GameObject boomEffect; // ��ź �̺�Ʈ

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
        // ���� ���� �� ��� �ð�
        yield return new WaitForSeconds(1);

        // ��� �̹��� Ȱ�� �� ��Ȱ��ȭ

        warningImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImage.SetActive(false);

        // ��ź ������Ʈ Ȱ��ȭ & �̵�

        yield return StartCoroutine(nameof(MoveUp));

        // ��ź �̺�Ʈ Ȱ�� �� ��Ȱ��ȭ
        boomEffect.SetActive(true);
        yield return new WaitForSeconds(1);
        boomEffect.SetActive(false);

        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    private IEnumerator MoveUp()
    {
        // ��ǥ ��ġ
        float boomDestiantionY = 0;

        // ��ź ������Ʈ Ȱ��ȭ
        boom.gameObject.SetActive(true);

        // ��ź�� ��ǥ���� �̵��ߴ��� Ȯ��
        while (true)
        {
            if (boom.transform.position.y >= boomDestiantionY)
            {
                // ��ź ������Ʈ ��Ȱ��ȭ
                boom.gameObject.SetActive(false);

                yield break;
            }
            yield return null;
        }
    }
}
