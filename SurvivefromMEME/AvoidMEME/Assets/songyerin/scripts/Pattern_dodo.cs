using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_dodo : MonoBehaviour
{
    [SerializeField]
    private GameObject[] warningImages; // 경고 이미지

    [SerializeField]
    private GameObject[] projectilePrefab;  // 발사체

    [SerializeField]
    private GameObject[] bg; // CW

    [SerializeField]
    private float spawnCycle;

    



    private void OnEnable()
    {
        StartCoroutine(nameof(Process));

    }
    private void OnDisable()
    {
        //bg[4].GetComponent<MovingEntity>().Reset();
        StopCoroutine(nameof(Process));
        
    }

    private IEnumerator Process()
    {

        yield return new WaitForSeconds(2.4f);



        // 경고이미지
        warningImages[0].SetActive(true);

        yield return new WaitForSeconds(0.2f);
        warningImages[0].SetActive(false);
        yield return new WaitForSeconds(0.2f);
        if (warningImages[0].activeSelf == false)
        {
            warningImages[1].SetActive(true);
            yield return new WaitForSeconds(0.2f);
            warningImages[1].SetActive(false);
        }
        yield return new WaitForSeconds(0.2f);
        if (warningImages[1].activeSelf == false)
        {
            warningImages[2].SetActive(true);
            yield return new WaitForSeconds(0.2f);
            warningImages[2].SetActive(false);
        }
        yield return new WaitForSeconds(0.2f);
        if (warningImages[2].activeSelf == false)
        {
            warningImages[3].SetActive(true);
            yield return new WaitForSeconds(0.2f);
            warningImages[3].SetActive(false);
        }


        yield return new WaitForSeconds(0.7f);
        yield return StartCoroutine(nameof(SpawnProjectile));
        yield return new WaitForSeconds(0.9f);
        yield return StartCoroutine(nameof(SpawnProjectile2));
        yield return new WaitForSeconds(0.8f);
        yield return StartCoroutine(nameof(SpawnProjectile3));
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(nameof(SpawnEnemys));
        yield return new WaitForSeconds(0.8f);
        yield return StartCoroutine(nameof(SpawnEnemys2));
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);


    }

    private IEnumerator SpawnProjectile()
    {
        float minspeed = 16;
        float maxspeed = 16;


        int count = 0;
        while (count < 10)
        {
            bg[0].SetActive(true);

            projectilePrefab[0].SetActive(true);
            GameObject clone = Instantiate(projectilePrefab[0], bg[0].transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;


            yield return new WaitForSeconds(spawnCycle);


        }


    }


    private IEnumerator SpawnProjectile2()
    {
        float minspeed = 13;
        float maxspeed = 14;


        int count = 0;
        while (count < 10)
        {
            bg[1].SetActive(true);

            projectilePrefab[1].SetActive(true);
            GameObject clone = Instantiate(projectilePrefab[1], bg[1].transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;


            yield return new WaitForSeconds(spawnCycle);


        }


    }
    private IEnumerator SpawnProjectile3()
    {
        float minspeed = 13;
        float maxspeed = 20;


        int count = 0;
        while (count < 10)
        {
            bg[2].SetActive(true);

            projectilePrefab[2].SetActive(true);
            GameObject clone = Instantiate(projectilePrefab[2], bg[2].transform.position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            movement2D.IsLongJump = Random.Range(0, 2) == 0 ? false : true;
            movement2D.JumpTo();

            count++;


            yield return new WaitForSeconds(spawnCycle);


        }


    }
    private IEnumerator SpawnEnemys()
    {
        projectilePrefab[3].SetActive(true);
        int count = 0;
        float minspeed = 4;
        float maxspeed = 12;

        //while (true)
        while (count < 10)
        {
           
            Vector3 position = new Vector3(Random.Range(Constants.min.x, Constants.max.x), Constants.max.y, 0);
           
            GameObject clone = Instantiate(projectilePrefab[3], position, Quaternion.identity);
            var movement2D = clone.GetComponent<MovementRigidbody2D_dodo>();
            movement2D.MoveSpeed = Random.Range(minspeed, maxspeed);
            movement2D.MoveTo(1 - 2 * Random.Range(0, 2));
            

            count++;


            yield return new WaitForSeconds(spawnCycle);


        }


       
    }
    private IEnumerator SpawnEnemys2()
    {
        

        float destinationY = -2.7f;
        bg[4].SetActive(true);
        

        while (true)
        {
            if ( bg[4].transform.position.y <= destinationY)
            {
                bg[3].SetActive(true);
                bg[4].GetComponent<MovementTransform2D>().MoveTo(Vector3.zero);
                yield break;
            }
            yield return null;

        }
        
        
        
    }

}



        

       
        
          

    
  


    



      