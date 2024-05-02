using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pattern_GyeongYoung : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImages; // 경고 이미지

    [SerializeField]
    private GameObject[] playerObjects; // 플레이어 오브젝트

    [SerializeField]
    private GameObject[] bg; // 플레이어 오브젝트

    public AudioSource audioSource;


    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
        //audioSource.Play(); // 오류 생김
    }
    private void OnDisable()
    {
        /*playerObjects[0].GetComponent<MovingEntity>().Reset();
        playerObjects[1].GetComponent<MovingEntity>().Reset();
        playerObjects[2].GetComponent<MovingEntity>().Reset();
        playerObjects[3].GetComponent<MovingEntity>().Reset();
        playerObjects[4].GetComponent<MovingEntity>().Reset();*/
        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        yield return new WaitForSeconds(1f);

        // 영차
        bg[0].SetActive(true);
        yield return new WaitForSeconds(0.7f);
        bg[0].SetActive(false);
        if (bg[0].activeSelf == false)
        {
            bg[1].SetActive(true);
            yield return new WaitForSeconds(1f);
            bg[1].SetActive(false);
        }



        //경고이미지 123

        warningImages[0].SetActive(true);

        yield return new WaitForSeconds(0.2f);
        warningImages[0].SetActive(false);
        if (warningImages[0].activeSelf == false)
        {
            warningImages[1].SetActive(true);
            yield return new WaitForSeconds(0.2f);
            warningImages[1].SetActive(false);
            if (warningImages[1].activeSelf == false)
            {
                warningImages[2].SetActive(true);
                yield return new WaitForSeconds(0.2f);
                warningImages[2].SetActive(false);
            }

        }
        //맥주잔들 올라오고?

        yield return new WaitForSeconds(0.2f);
        playerObjects[0].SetActive(true);
        playerObjects[0].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);

        yield return new WaitForSeconds(0.4f);
        playerObjects[0].SetActive(false);
        if (playerObjects[0].activeSelf == false)
        {
            playerObjects[1].SetActive(true);
            playerObjects[1].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);
            yield return new WaitForSeconds(0.3f);
            playerObjects[1].SetActive(false);
            if (playerObjects[1].activeSelf == false)
            {
                playerObjects[2].SetActive(true);
                playerObjects[2].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);
                yield return new WaitForSeconds(0.3f);
                playerObjects[2].SetActive(false);
            }

        }
        //경고이미지 213


        warningImages[1].SetActive(true);
        yield return new WaitForSeconds(0.2f);
        warningImages[1].SetActive(false);
        if (warningImages[1].activeSelf == false)
        {
            warningImages[0].SetActive(true);
            yield return new WaitForSeconds(0.2f);
            warningImages[0].SetActive(false);
            if (warningImages[0].activeSelf == false)
            {
                warningImages[2].SetActive(true);
                yield return new WaitForSeconds(0.2f);
                warningImages[2].SetActive(false);
            }

        }
        playerObjects[0].GetComponent<MovingEntity>().Reset();
        playerObjects[1].GetComponent<MovingEntity>().Reset();
        playerObjects[2].GetComponent<MovingEntity>().Reset();

        //맥주잔들 올라오고?

        yield return new WaitForSeconds(0.2f);
        playerObjects[1].SetActive(true);
        playerObjects[1].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);

        yield return new WaitForSeconds(0.6f);
        playerObjects[1].SetActive(false);
        if (playerObjects[1].activeSelf == false)
        {
            playerObjects[0].SetActive(true);
            playerObjects[0].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);
            yield return new WaitForSeconds(0.6f);
            playerObjects[0].SetActive(false);
            if (playerObjects[0].activeSelf == false)
            {
                playerObjects[2].SetActive(true);
                playerObjects[2].GetComponent<MovementTransform2D>().MoveTo(Vector3.up);
                yield return new WaitForSeconds(0.3f);
                playerObjects[2].SetActive(false);
            }

        }
        //경고이미지 123

        warningImages[0].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        warningImages[0].SetActive(false);
        if (warningImages[0].activeSelf == false)
        {
            warningImages[1].SetActive(true);
            yield return new WaitForSeconds(0.3f);
            warningImages[1].SetActive(false);
            if (warningImages[1].activeSelf == false)
            {
                warningImages[2].SetActive(true);
                yield return new WaitForSeconds(0.3f);
                warningImages[2].SetActive(false);
            }

        }
        // 맥주 위에꺼 123

        yield return new WaitForSeconds(0.4f);
        yield return StartCoroutine(nameof(bubble));
        yield return new WaitForSeconds(0.6f);
        yield return StartCoroutine(nameof(bubble2));
        yield return new WaitForSeconds(0.6f);
        yield return StartCoroutine(nameof(bubble3));
        yield return new WaitForSeconds(0.7f);



        // 영차

        bg[2].SetActive(true);
        yield return new WaitForSeconds(1f);
        bg[2].SetActive(false);
        if (bg[2].activeSelf == false)
        {
            bg[3].SetActive(true);
            yield return new WaitForSeconds(0.5f);
            bg[3].SetActive(false);
        }

        // 경고 이미지 45

        warningImages[3].SetActive(true);
        yield return new WaitForSeconds(0.4f);
        warningImages[3].SetActive(false);
        if (warningImages[3].activeSelf == false)
        {
            warningImages[4].SetActive(true);
            yield return new WaitForSeconds(0.4f);
            warningImages[4].SetActive(false);

        }

        // 소주 날아감
        yield return new WaitForSeconds(0.4f);
        playerObjects[4].SetActive(true);
        playerObjects[4].GetComponent<MovementTransform2D>().MoveTo(Vector3.right);

        yield return new WaitForSeconds(0.6f);
        playerObjects[4].SetActive(false);
        if (playerObjects[4].activeSelf == false)
        {
            playerObjects[3].SetActive(true);
            playerObjects[3].GetComponent<MovementTransform2D>().MoveTo(Vector3.left);

            yield return new WaitForSeconds(0.6f);
            playerObjects[3].SetActive(false);
            yield return new WaitForSeconds(0.3f);

        }


        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }

    private IEnumerator bubble()
    {
        float minspeed = 13;
        float maxspeed = 20;
        playerObjects[5].SetActive(true);


        int count = 0;
        while (count < 20)
        {


            playerObjects[8].SetActive(true);
            GameObject clone = Instantiate(playerObjects[8], playerObjects[5].transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;


            yield return null;


        }


    }
    private IEnumerator bubble2()
    {
        float minspeed = 13;
        float maxspeed = 20;
        playerObjects[6].SetActive(true);


        int count = 0;
        while (count < 10)
        {


            playerObjects[9].SetActive(true);
            GameObject clone = Instantiate(playerObjects[9], playerObjects[6].transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;


            yield return null;


        }


    }
    private IEnumerator bubble3()
    {
        float minspeed = 13;
        float maxspeed = 20;
        playerObjects[7].SetActive(true);

        int count = 0;
        while (count < 10)
        {


            playerObjects[10].SetActive(true);
            GameObject clone = Instantiate(playerObjects[10], playerObjects[7].transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;


            yield return null;


        }


    }
}
