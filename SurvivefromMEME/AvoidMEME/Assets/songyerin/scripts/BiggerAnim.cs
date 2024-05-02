using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiggerAnim : MonoBehaviour
{
    float time;

    // Update is called once per frame
    void Update()
    {
        
        transform.localScale = Vector3.one * (1+time);
        time += Time.deltaTime;
        if (time > 1f)
        {
            gameObject.SetActive(false);
        }
    }

    public void resetAnim()
    {
        time = 0;
        transform.localScale = Vector3.one;
    }
}
