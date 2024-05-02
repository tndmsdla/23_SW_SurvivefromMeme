using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern_Slickback : MonoBehaviour
{
    [SerializeField]
    private GameObject warningImage; 
    [SerializeField]
    private GameObject slickback;
    [SerializeField]
    public AudioSource slickbackBGM;

  

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        slickbackBGM.Play();

        yield return new WaitForSeconds(1);

        warningImage.SetActive(true);
        yield return new WaitForSeconds(2.3f);
        warningImage.SetActive(false);

        slickback.SetActive(true);

        yield return new WaitForSeconds(9f);
        slickback.SetActive(false);
        gameObject.SetActive(false); // 게임 종료 구문.
    }

   
}