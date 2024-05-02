using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_Danaka : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //반짝이
    [SerializeField]
    private GameObject enemyPrefab2; //하트
    [SerializeField]
    private int maxEnemyCount; // �� ���� ����
    [SerializeField]
    private float spawnCycle; // �� ���� �ֱ�
    [SerializeField]
    private GameObject danaka1;
    [SerializeField]
    private GameObject danaka2;
    [SerializeField]
    private GameObject warningImage; //��� �̹��� 
    [SerializeField]
    private GameObject boomEffect; // ��ź �̺�Ʈ

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(nameof(SpawnEnemys));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(SpawnEnemys));
    }

    private IEnumerator SpawnEnemys()
    {
        danaka2.SetActive(false);

        // ���� ���� �� ��� ����ϴ� �ð�
        float waitTime = 1;
        yield return new WaitForSeconds(waitTime);

        danaka1.SetActive(true);


        int count = 0;
        //while (true)
        while (count < maxEnemyCount)
        {

            Vector3 position = new Vector3(Random.Range(Constants.min.x, Constants.max.x), Constants.max.y, 0);
            // 랜덤한 크기를 설정
            float randomScale = Random.Range(0.5f, 1f); // 크기 범위를 조절할 수 있음

            // Instantiate 시 크기 조절
            GameObject enemyInstance = Instantiate(enemyPrefab, position, Quaternion.identity);
            enemyInstance.transform.localScale = new Vector3(randomScale, randomScale, 1);
            //Instantiate(enemyPrefab, position, Quaternion.identity);

            yield return new WaitForSeconds(spawnCycle);

            count++;
        }

        danaka1.SetActive(false);
        danaka2.SetActive(true);

        yield return new WaitForSeconds(1f);

        // ��� �̹��� Ȱ�� �� ��Ȱ��ȭ
        warningImage.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningImage.SetActive(false);


        //        Instantiate(enemyPrefab2);
        enemyPrefab2.SetActive(true);

        float boomDestiantionY = -4; //��ǥ��ġ

        // ��ź �̺�Ʈ Ȱ�� �� ��Ȱ��ȭ

        while (true)
        {
            if (boomDestiantionY >= enemyPrefab2.transform.position.y)
            {

                boomEffect.SetActive(true);
                enemyPrefab2.SetActive(false);
                yield return new WaitForSeconds(1);
                boomEffect.SetActive(false);
                break;
            }
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        enemyPrefab2.GetComponent<MovingEntity>().Reset();

        // ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
