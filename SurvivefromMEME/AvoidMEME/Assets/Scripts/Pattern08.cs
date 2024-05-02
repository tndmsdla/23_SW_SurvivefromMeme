using System.Collections;
using UnityEngine;



public class Pattern08 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImage; // ��� �̹���
    [SerializeField]
    private GameObject[] sojubeer;
    [SerializeField]
    private float spawnCycle; // ���� �ֱ�

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        // ���� ����� ���� �÷��̾� ������Ʈ�� ���� �ʱ�ȭ
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

        // ���� ���� �� ��� ����ϴ� �ð�
        yield return new WaitForSeconds(1);

        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }




    private IEnumerator SpawnPlayer(int index)
    {
        // ��� �̹��� Ȱ��, ��Ȱ��ȭ
        warningImage[index].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        warningImage[index].SetActive(false);

        // �÷��̾� ������Ʈ Ȱ��ȭ
        sojubeer[index].SetActive(true);
    }
}
        
    

