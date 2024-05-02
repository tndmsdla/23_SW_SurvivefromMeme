using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPosition : MonoBehaviour
{
    // ȭ�� �� ���� ������ ����� �� �����ϱ� ���� ����ġ ��
    private float destroyWeight = 500;

    private void LateUpdate()
    {
        if (transform.position.x < Constants.min.x - destroyWeight ||
            transform.position.x > Constants.max.x + destroyWeight ||
            transform.position.y < Constants.min.y - destroyWeight ||
            transform.position.y > Constants.max.y + destroyWeight)
        {
            Destroy(gameObject);
        }
        GameController Instance = GameObject.Find("GameController").GetComponent<GameController>();
        

        if (Instance.AvatarIndex == 2){
            PlayerController playerController = GameObject.Find("Player_HeroKnight").GetComponent<PlayerController>();
            MovementRigidbody2D movement2D = GameObject.Find("Player_HeroKnight").GetComponent<MovementRigidbody2D>();
            if (playerController.attackState)
            {
                if (playerController.sprite.flipX == false)
                {
                    if (playerController.Attack1.x >= transform.position.x &&
                        movement2D.GetFootPosition().x <= transform.position.x &&
                        playerController.Attack1.y >= transform.position.y &&
                        movement2D.GetFootPosition().y <= transform.position.y)
                    {
                        Destroy(gameObject);
                    }
                }
                else // ���� ���� ���� ��
                {
                    if (playerController.Attack1.x <= transform.position.x &&
                        movement2D.GetFootPosition().x >= transform.position.x &&
                        playerController.Attack1.y >= transform.position.y &&
                        movement2D.GetFootPosition().y <= transform.position.y)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
