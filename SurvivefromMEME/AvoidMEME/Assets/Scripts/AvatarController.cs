using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvatarController : MonoBehaviour
{
    [SerializeField]
    private GameObject SkinPanel; // �ƹ�Ÿ ���� �г� ����
    [SerializeField]
    private PlayerShield playerShield; // �÷��̾� ���� ������ �ֱ� ����
    [SerializeField]
    private GameObject[] AvatarList; // �ƹ�Ÿ ��� 
    [SerializeField]
    private TextMeshProUGUI AvatarName; // �ƹ�Ÿ �̸�
    [SerializeField]
    private TextMeshProUGUI AvatarInfo; // �ƹ�Ÿ ���� �����ֱ�

    private int AvatarIndex = 0; // � �ƹ�Ÿ �����ϴ��� �ɷ����� ����

    private void Awake()
    {
        AvatarIndex = PlayerPrefs.GetInt("AvatarIndex");
    }

    public void AvatarOnButton()
    {
        SkinPanel.SetActive(true);
        AvatarList[AvatarIndex].SetActive(true);
        if (AvatarIndex == 0)
        {
            AvatarList[0].SetActive(true);
            AvatarName.text = "�⺻";
            AvatarInfo.text = "ü�� 5 / 5\n\n���� ��ų ����";
        }
        else if (AvatarIndex == 1)
        {
            AvatarList[1].SetActive(true);
            AvatarName.text = "Ŀ��";
            AvatarInfo.text = "ü�� 5 / 7\n\n���� ��� ����\n�Ϳ���";
        }
        else if (AvatarIndex == 2)
        {
            AvatarList[2].SetActive(true);
            AvatarName.text = "����";
            AvatarInfo.text = "ü�� 5 / 10\n\n���� ��� ����\n��ֹ� �ı�";
        }
        else if (AvatarIndex == 3)
        {
            AvatarList[3].SetActive(true);
            AvatarName.text = "����";
            AvatarInfo.text = "ü�� 3 / 4\n\n�̵��ӵ� ����\n���� 4ȸ ����";
        }
    }

    public void AvatarOffButton()
    {
        SkinPanel.SetActive(false);
        AvatarList[AvatarIndex].SetActive(false);
        PlayerPrefs.SetInt("AvatarIndex", AvatarIndex);
    }

    public void AvatarSelect(int input)
    {
        AvatarIndex = input;
        Debug.Log(AvatarIndex);
    }

    public int GetAvatar() // ���� ��Ʈ�ѷ����� �ƹ�Ÿ ���� �޾ƿ� �� ���
    {
        return AvatarIndex;
    }

    public void NextButton()
    {
        AvatarList[AvatarIndex].SetActive(false);
        if (AvatarIndex == AvatarList.Length-1)
        {
            AvatarIndex = 0;
            AvatarList[0].SetActive(true);
            AvatarName.text = "�⺻";
            AvatarInfo.text = "ü�� 5 / 5\n\n���� ��ų ����";
        }
        else
        {

            AvatarList[++AvatarIndex].SetActive(true);
            if (AvatarIndex == 1)
            {
                AvatarName.text = "Ŀ��";
                AvatarInfo.text = "ü�� 5 / 7\n\n���� ��� ����\n�Ϳ���";
            }
            else if (AvatarIndex == 2)
            {
                AvatarName.text = "����";
                AvatarInfo.text = "ü�� 5 / 10\n\n���� ��� ����\n��ֹ� �ı�";
            }
            else if (AvatarIndex == 3)
            {
                AvatarName.text = "����";
                AvatarInfo.text = "ü�� 3 / 4\n\n�̵��ӵ� ����\n���� 4ȸ ����";
            }
        }
    }
    public void PreviousButton()
    {
        AvatarList[AvatarIndex].SetActive(false);
        if (AvatarIndex == 0)
        {
            AvatarIndex = AvatarList.Length - 1;
            AvatarList[AvatarIndex].SetActive(true);
            AvatarName.text = "����";
            AvatarInfo.text = "ü�� 3 / 4\n\n�̵��ӵ� ����\n���� 4ȸ ����";
        }
        else
        {
            AvatarList[--AvatarIndex].SetActive(true);
            if (AvatarIndex == 0)
            {
                AvatarName.text = "�⺻";
                AvatarInfo.text = "ü�� 5 / 5\n\n���� ��ų ����";
            }
            else if (AvatarIndex == 1)
            {
                AvatarName.text = "Ŀ��";
                AvatarInfo.text = "ü�� 5 / 7\n\n���� ��� ����";
            }
            else if (AvatarIndex == 2)
            {
                AvatarName.text = "����";
                AvatarInfo.text = "ü�� 5 / 10\n\n���� ��� ����\n��ֹ� �ı�";
            }
        }


    }
}
