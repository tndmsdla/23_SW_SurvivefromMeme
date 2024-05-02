using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField]
    private GameObject[] imageHp;
    private int currentHP;
    private int maxHP;

    [SerializeField]
    private float invincibilityDuration; // 무적 지속시간
    private bool isInvincibility = false; // 무적 여부

    private SoundController soundController;
    private SpriteRenderer spriteRenderer;

    private Color originColor;

    private void Awake()
    {
        soundController = GetComponentInChildren<SoundController>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        maxHP = imageHp.Length;
        if (maxHP == 4)
        {
            currentHP = 3;
        }
        else
        {
            currentHP = 5;
        }

        for (int i = 0; i < currentHP; i++)
        {
            imageHp[i].SetActive(true);
        }
        originColor = spriteRenderer.color;
        
        Debug.Log(currentHP);
    }

    public bool RecoveryHP()
    {
        if (currentHP == maxHP)
            return false;
        else if (currentHP < maxHP)
        {
            // 체력 포션 소리 추가 예정
            imageHp[currentHP++].SetActive(true);
            return true;
        }
        else
            return false;
    }

    public bool TakeDamage()
    {
        // 무적 상태일 때는 체력이 감소하지 않는다.
        if (isInvincibility == true) return false;

        if (currentHP > 1)
        {
            soundController.Play(0);
            StartCoroutine(nameof(OnInvincibility));

            imageHp[--currentHP].SetActive(false);
        }
        else
        {
            return true;
        }

        return false;
    }

    private IEnumerator OnInvincibility()
    {
        isInvincibility = true;

        float current = 0;
        float percent = 0;
        float colorSpeed = 10;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / invincibilityDuration;

            spriteRenderer.color = Color.Lerp(originColor, Color.red, Mathf.PingPong(Time.time * colorSpeed, 1));

            yield return null;
        }

        spriteRenderer.color = originColor;
        isInvincibility = false;
    }
}
