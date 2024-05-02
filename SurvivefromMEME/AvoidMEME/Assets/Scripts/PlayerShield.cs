using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShield : MonoBehaviour
{
    [Range(0, 20)]
    public float skillTime = 10.0f; // ��ų ���� �ð�
    [Range(0, 20)]
    public float skillCoolTime = 10.0f; // ��ų ��Ÿ��
    [SerializeField]
    private AvatarController avatarController; // �ƹ�Ÿ ��Ʈ�ѷ� �޾ƿ���
    
    public Image skillFillAmount; // ���� Mask�̹���
    public TextMeshProUGUI skillCoolTimeText; // ���� ��Ÿ�� ǥ�� TMP

    public GameObject Shield; //���� �̹���


    public bool ShieldCondition = false; // PlayerController���� ������Ʈ �浹 ���� ����
    public bool isUseSkill = true; // PlayerShield �� ��ų ��� ���� �Ǵ� ����



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

    IEnumerator SkillUse() //��ų ���
    {
        if (isUseSkill && Input.GetKeyDown(KeyCode.Z))
        {
            isUseSkill = false;

            skillFillAmount.fillAmount = 0;
            Shield.SetActive(true); // ���� �̹��� �����ֱ�
            ShieldCondition = true; // PlayerController ��ũ��Ʈ���� �浹 ���� �������� ����.
            StartCoroutine(SkillCoroutine());
            yield return new WaitForSeconds(skillTime);
            Shield.SetActive(false);
            
        }
    }
    IEnumerator SkillCoroutine() // ��ų �����
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
            StartCoroutine(CoolTimeCountCoroutine(number, ShieldCondition));
        }
        else if(number <=0 && !condition) {
            skillCoolTimeText.text = "Z";
            yield break;
        }
    }
}