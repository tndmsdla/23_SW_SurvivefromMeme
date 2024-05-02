using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [Range(0, 20)]
    public float skillTime = 0.3f; // ��ų ���� �ð�
    [Range(0, 20)]
    public float skillCoolTime = 5f; // ��ų ��Ÿ��
    [SerializeField]
    private AvatarController avatarController; // �ƹ�Ÿ ��Ʈ�ѷ� �޾ƿ���

    public Image skillFillAmount; // ��ų Mask�̹���
    public TextMeshProUGUI skillCoolTimeText; // ��ų ��Ÿ�� ǥ�� TMP


    public bool AttackCondition = false; // PlayerController���� ��ų ��� ���� ����
    public bool isUseSkill = true; // PlayerAttack �� ��ų ��� ���� �Ǵ� ����



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

    IEnumerator Attack() //��ų ���
    {
        if (isUseSkill && Input.GetKeyDown(KeyCode.X))
        {
            isUseSkill = false;

            skillFillAmount.fillAmount = 0;
            AttackCondition = true; // PlayerController ��ũ��Ʈ���� �浹 ���� �������� ����.
            StartCoroutine(SkillCoroutine());
            yield return new WaitForSeconds(skillTime);

        }
    }
    IEnumerator SkillCoroutine() // ��ų �����
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
        yield return new WaitForSeconds(1f); // �����̸� ���� ������ ��Ÿ�� �ؽ�Ʈ���� Z�� 1�� ���� ������ ���� �߻�

    }

    IEnumerator ResetSkillCoroutine() //��ų ��Ÿ��
    {

        while (skillFillAmount.fillAmount > 0)
        {
            skillFillAmount.fillAmount -= 1 * Time.smoothDeltaTime / skillCoolTime;

            yield return null;
        }

        isUseSkill = true;
    }

    IEnumerator CoolTimeCountCoroutine(float number, bool condition) //��ų ��Ÿ�� �ؽ�Ʈ ǥ��
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