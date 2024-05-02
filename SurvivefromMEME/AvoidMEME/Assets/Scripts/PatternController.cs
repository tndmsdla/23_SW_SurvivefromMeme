using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private GameObject[] patterns; // �����ϰ� �ִ� ��� ����
    private GameObject currentPattern; // ���� ������� ����
    [SerializeField]
    private GameObject HpPotion; // �������� ���� ü�� ����
    private int[] patternIndexs; // ��ġ�� �ʴ� patterns.Legenth ������ ����
    private int current = 0; // patternIndexs �迭�� ����

    private void Awake()
    {
        // �����ϰ� �ִ� ���� ������ �����ϰ� �޸� �Ҵ�
        patternIndexs = new int[patterns.Length];

        for (int i=0; i < patternIndexs.Length; i++)
        {
            patternIndexs[i] = i;
        }
    }

    private void Update()
    {
        if (gameController.IsGamePlay == false) return;

        //���� ������� ������ ����Ǿ� ������Ʈ�� ��Ȱ��ȭ�Ǹ�
        if (currentPattern.activeSelf == false)
        {
            HpPotion.SetActive(true);
            // ���� ���� ����
            ChangePattern();
        }
    }

    public void GameStart()
    {
        ChangePattern();
    }

    public void GameOver()
    {
        // ���� ������� ���ϸ� ��Ȱ��ȭ
        currentPattern.SetActive(false);
    }

    public void ChangePattern()
    {
        //���� ���� ����
        currentPattern = patterns[patternIndexs[current]];

        // ���� ���� Ȱ��ȭ
        currentPattern.SetActive(true);

        //if (current == 0) Pattern06BGM.Play();

        current++;

        // ������ �ѹ��� ��� �����ߴٸ� ���� ������ ��ġ�� �ʴ� ������ ���ڷ� ����
        // �ش� ����� ������ �����̱� ��
        if (current >= patternIndexs.Length)
        {
            patternIndexs = Utils.RandomNumbers(patternIndexs.Length, patternIndexs.Length);
            current = 0;
        }
    }
}
