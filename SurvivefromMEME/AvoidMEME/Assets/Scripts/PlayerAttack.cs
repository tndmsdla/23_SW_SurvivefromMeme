using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [Range(0, 20)]
    public float skillTime = 0.3f; // 스킬 지속 시간
    [Range(0, 20)]
    public float skillCoolTime = 5f; // 스킬 쿨타임
    [SerializeField]
    private AvatarController avatarController; // 아바타 컨트롤러 받아오기

    public Image skillFillAmount; // 스킬 Mask이미지
    public TextMeshProUGUI skillCoolTimeText; // 스킬 쿨타임 표시 TMP


    public bool AttackCondition = false; // PlayerController에서 스킬 사용 가능 여부
    public bool isUseSkill = true; // PlayerAttack 내 스킬 사용 유무 판단 변수



    private void Awake()
    {
        //skillInformationText.text = "Skill OFF";
        //skillCoolTimeText.text = "Skill";
    }

    private void Update()
    {
        if (avatarController.GetAvatar() == 2)
            StartCoroutine(nameof(Attack));
    }

    IEnumerator Attack() //스킬 사용
    {
        if (isUseSkill && Input.GetKeyDown(KeyCode.X))
        {
            isUseSkill = false;

            skillFillAmount.fillAmount = 0;
            AttackCondition = true; // PlayerController 스크립트에서 충돌 무시 조건으로 사용됨.
            StartCoroutine(SkillCoroutine());
            yield return new WaitForSeconds(skillTime);

        }
    }
    IEnumerator SkillCoroutine() // 스킬 사용중
    {
        StartCoroutine(CoolTimeCountCoroutine(skillTime, AttackCondition));
        while (skillFillAmount.fillAmount < 1)
        {
            skillFillAmount.fillAmount += 1 * Time.smoothDeltaTime / skillTime;
            yield return null;
        }


        StartCoroutine(ResetSkillCoroutine());

        StartCoroutine(CoolTimeCountCoroutine(skillCoolTime, true));
        AttackCondition = false;
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
            StartCoroutine(CoolTimeCountCoroutine(number, AttackCondition));
        }
        else if (number <= 0 && !condition)
        {
            skillCoolTimeText.text = "X";
            yield break;
        }
    }
}