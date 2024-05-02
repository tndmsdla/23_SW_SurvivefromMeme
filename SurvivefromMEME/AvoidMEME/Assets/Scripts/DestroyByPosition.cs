using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPosition : MonoBehaviour
{
    // 화면 밖 일정 범위를 벗어났을 때 삭제하기 위한 가중치 값
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
                else // 왼쪽 보고 있을 때
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
