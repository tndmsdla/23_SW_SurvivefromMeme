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
    private float invincibilityDuration; // ���� ���ӽð�
    private bool isInvincibility = false; // ���� ����

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
            // ü�� ���� �Ҹ� �߰� ����
            imageHp[currentHP++].SetActive(true);
            return true;
        }
        else
            return false;
    }

    public bool TakeDamage()
    {
        // ���� ������ ���� ü���� �������� �ʴ´�.
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
