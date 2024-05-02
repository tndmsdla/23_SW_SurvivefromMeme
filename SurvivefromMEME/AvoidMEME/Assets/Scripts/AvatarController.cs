using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvatarController : MonoBehaviour
{
    [SerializeField]
    private GameObject SkinPanel; // 아바타 적용 패널 열기
    [SerializeField]
    private PlayerShield playerShield; // 플레이어 쉴드 사용권한 주기 위함
    [SerializeField]
    private GameObject[] AvatarList; // 아바타 목록 
    [SerializeField]
    private TextMeshProUGUI AvatarName; // 아바타 이름
    [SerializeField]
    private TextMeshProUGUI AvatarInfo; // 아바타 정보 보여주기

    private int AvatarIndex = 0; // 어떤 아바타 선택하는지 걸러내기 위함

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
            AvatarName.text = "기본";
            AvatarInfo.text = "체력 5 / 5\n\n보유 스킬 없음";
        }
        else if (AvatarIndex == 1)
        {
            AvatarList[1].SetActive(true);
            AvatarName.text = "커비";
            AvatarInfo.text = "체력 5 / 7\n\n쉴드 사용 가능\n귀여움";
        }
        else if (AvatarIndex == 2)
        {
            AvatarList[2].SetActive(true);
            AvatarName.text = "전사";
            AvatarInfo.text = "체력 5 / 10\n\n쉴드 사용 가능\n장애물 파괴";
        }
        else if (AvatarIndex == 3)
        {
            AvatarList[3].SetActive(true);
            AvatarName.text = "도적";
            AvatarInfo.text = "체력 3 / 4\n\n이동속도 빠름\n점프 4회 가능";
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

    public int GetAvatar() // 게임 컨트롤러에서 아바타 정보 받아올 때 사용
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
            AvatarName.text = "기본";
            AvatarInfo.text = "체력 5 / 5\n\n보유 스킬 없음";
        }
        else
        {

            AvatarList[++AvatarIndex].SetActive(true);
            if (AvatarIndex == 1)
            {
                AvatarName.text = "커비";
                AvatarInfo.text = "체력 5 / 7\n\n쉴드 사용 가능\n귀여움";
            }
            else if (AvatarIndex == 2)
            {
                AvatarName.text = "전사";
                AvatarInfo.text = "체력 5 / 10\n\n쉴드 사용 가능\n장애물 파괴";
            }
            else if (AvatarIndex == 3)
            {
                AvatarName.text = "도적";
                AvatarInfo.text = "체력 3 / 4\n\n이동속도 빠름\n점프 4회 가능";
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
            AvatarName.text = "도적";
            AvatarInfo.text = "체력 3 / 4\n\n이동속도 빠름\n점프 4회 가능";
        }
        else
        {
            AvatarList[--AvatarIndex].SetActive(true);
            if (AvatarIndex == 0)
            {
                AvatarName.text = "기본";
                AvatarInfo.text = "체력 5 / 5\n\n보유 스킬 없음";
            }
            else if (AvatarIndex == 1)
            {
                AvatarName.text = "커비";
                AvatarInfo.text = "체력 5 / 7\n\n쉴드 사용 가능";
            }
            else if (AvatarIndex == 2)
            {
                AvatarName.text = "전사";
                AvatarInfo.text = "체력 5 / 10\n\n쉴드 사용 가능\n장애물 파괴";
            }
        }


    }
}
