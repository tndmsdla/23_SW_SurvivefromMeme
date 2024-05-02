using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShield : MonoBehaviour
{
    [Range(0, 20)]
    public float skillTime = 10.0f; // 스킬 지속 시간
    [Range(0, 20)]
    public float skillCoolTime = 10.0f; // 스킬 쿨타임
    [SerializeField]
    private AvatarController avatarController; // 아바타 컨트롤러 받아오기
    
    public Image skillFillAmount; // 쉴드 Mask이미지
    public TextMeshProUGUI skillCoolTimeText; // 쉴드 쿨타임 표시 TMP

    public GameObject Shield; //쉴드 이미지


    public bool ShieldCondition = false; // PlayerController에서 오브젝트 충돌 감시 변수
    public bool isUseSkill = true; // PlayerShield 내 스킬 사용 유무 판단 변수



    private void Awake()
    {
        //skillInformationText.text = "Skill OFF";
        //skillCoolTimeText.text = "Skill";
    }

    private void Update()
    {
        if (avatarController.GetAvatar() != 0)
            StartCoroutine(nameof(SkillUse));
    }

    IEnumerator SkillUse() //스킬 사용
    {
        if (isUseSkill && Input.GetKeyDown(KeyCode.Z))
        {
            isUseSkill = false;

            skillFillAmount.fillAmount = 0;
            Shield.SetActive(true); // 쉴드 이미지 보여주기
            ShieldCondition = true; // PlayerController 스크립트에서 충돌 무시 조건으로 사용됨.
            StartCoroutine(SkillCoroutine());
            yield return new WaitForSeconds(skillTime);
            Shield.SetActive(false);
            
        }
    }
    IEnumerator SkillCoroutine() // 스킬 사용중
    {
        StartCoroutine(CoolTimeCountCoroutine(skillTime, ShieldCondition));
        while (skillFillAmount.fillAmount < 1)
        {
            skillFillAmount.fillAmount += 1 * Time.smoothDeltaTime / skillTime;
            yield return null;
        }
        

        StartCoroutine(ResetSkillCoroutine());
        
        StartCoroutine(CoolTimeCountCoroutine(skillCoolTime, true));
        ShieldCondition = false;
        yield return new WaitForSeconds(1f); // 딜레이를 주지 않으면 쿨타임 텍스트에서 Z가 1초 동안 나오는 오류 발생
        
    }

    IEnumerator ResetSkillCoroutine() //스킬 쿨타임
    {
        
        while (skillFillAmount.fillAmount > 0)
        {
            skillFillAmount.fillAmount -= 1 * Time.smoothDeltaTime / skillCoolTime;

            yield return null;
        }

        isUseSkill = true;
    }
    
    IEnumerator CoolTimeCountCoroutine(float number, bool condition) //스킬 쿨타임 텍스트 표시
    {
        if (number > 0)
        {
            skillCoolTimeText.text = number.ToString();

            yield return new WaitForSeconds(1f);
            number -= 1;
            StartCoroutine(CoolTimeCountCoroutine(number, ShieldCondition));
        }
        else if(number <=0 && !condition) {
            skillCoolTimeText.text = "Z";
            yield break;
        }
    }
}