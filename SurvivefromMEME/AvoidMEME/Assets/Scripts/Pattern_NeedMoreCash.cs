using System.Collections;
using UnityEngine;

public class Pattern_NeedMoreCash : MonoBehaviour
{
    [SerializeField]
    private GameObject warningImage; // ��� �̹���
    [SerializeField]
    private GameObject doctorKO; // ��ڻ� ������
    [SerializeField]
    private Vector3[] spawnPositions; // ������Ʈ ���� ��ġ
    [SerializeField]
    private float spawnCycle; // ���� �ֱ�
    [SerializeField]
    private int maxCount; // ���� Ƚ��

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

        // 
        yield return new WaitForSeconds(1);


        // ��� �̹��� 0.5�� ���� Ȱ�� �� ��Ȱ��ȭ
        warningImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImage.SetActive(false);

        // ��ڻ� ���� �� �̵�
        int count = 0;
        while (count < maxCount)
        {
            // 0 : ���ʿ��� ����������, 1 : �����ʿ��� ��������
            int spawnType = Random.Range(0, 2);

            // ������Ʈ ���� �� ��ġ ����
            GameObject clone = Instantiate(doctorKO, spawnPositions[spawnType], Quaternion.identity);
            // �̹��� ��/�� ����
            clone.GetComponent<SpriteRenderer>().flipX = spawnType == 0 ? false : true;
            // ������Ʈ �̵����� ����
            clone.GetComponent<MovementTransform2D>().MoveTo(spawnType == 0 ? Vector3.right : Vector3.left);

            count++;

            yield return new WaitForSeconds(spawnCycle);
        }
        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
