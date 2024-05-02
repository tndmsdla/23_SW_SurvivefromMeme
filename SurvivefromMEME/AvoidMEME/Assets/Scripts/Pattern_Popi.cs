using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_Popi : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImages; // ��� �̹���
    [SerializeField]
    private GameObject[] playerObjects; // �÷��̾� ������Ʈ
    [SerializeField]
    //private float spawnCycle = 1; // ���� �ֱ�

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        // ���� ����� ���� �÷��̾� ������Ʈ�� ���� �ʱ�ȭ
        for (int i = 0; i < playerObjects.Length; i++)
        {
            playerObjects[i].SetActive(false);
            //playerObjects[i].GetComponent<MovingEntity>().Reset();
        }

        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        // ���� ���� �� ��� �ð�
        yield return new WaitForSeconds(1);

        // �÷��̾��� ���� ��ġ ��ġ�� �ʴ� ������ ��ġ�� ����
        int[] numbers = Utils.RandomNumbers(3, 3);

        int index = 0;
        while (index < numbers.Length)
        {
            StartCoroutine(nameof(SpawnPlayer), numbers[index]);

            index++;

            yield return new WaitForSeconds(2f);


        }



        // ���� ���� �� ��� ����ϴ� �ð�
        yield return new WaitForSeconds(1);

        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    private IEnumerator SpawnPlayer(int index)
    {
        // ��� �̹��� Ȱ��, ��Ȱ��ȭ
        warningImages[index].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImages[index].SetActive(false);

        // �÷��̾� ������Ʈ Ȱ��ȭ
        playerObjects[index].SetActive(true);
        StartCoroutine(nameof(Emphasis), index);
        yield return new WaitForSeconds(1.2f);
        playerObjects[index].SetActive(false);


    }
    private IEnumerator Emphasis(int index)
    {
        float increase = 0.1f;

        while (true)
        {
            while (playerObjects[index].GetComponent<Transform>().localScale.x > 1.3f)
            {
                playerObjects[index].transform.localScale = new Vector3(playerObjects[index].transform.localScale.x - increase
                                                                , playerObjects[index].transform.localScale.y - increase
                                                                , playerObjects[index].transform.localScale.z - increase);
                yield return new WaitForSeconds(0.02f); //크기가 바뀌는 속도
            }
            yield return new WaitForSeconds(0.05f); //중간에 멈추는 텀
            while (playerObjects[index].GetComponent<Transform>().localScale.x < 2f)
            {
                playerObjects[index].transform.localScale = new Vector3(playerObjects[index].transform.localScale.x + increase
                                                                , playerObjects[index].transform.localScale.y + increase
                                                                , playerObjects[index].transform.localScale.z + increase);
                yield return new WaitForSeconds(0.02f); //크기가 바뀌는 속도
            }
            yield return new WaitForSeconds(0.05f); //중간에 멈추는 텀
        }
    }
}
