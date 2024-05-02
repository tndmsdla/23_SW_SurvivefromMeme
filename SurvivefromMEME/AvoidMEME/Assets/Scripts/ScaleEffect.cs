using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScaleEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float effectTime; // 크기 확대/축소 되는 시간

    private TextMeshProUGUI effectText; // 크기 확대/축소 효과에 사용되는 텍스트
    
    private void Awake()
    {
        effectText = GetComponent<TextMeshProUGUI>();
    }


    // 폰트 크기를 start에서 end로 effectTime 시간 동안 변화시키는 애니메이션을 재생할 때 호출
    public void Play(float start, float end)
    {
        StartCoroutine(Process(start, end));
    }

    private IEnumerator Process(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / effectTime;

            effectText.fontSize = Mathf.Lerp(start, end, percent);

            yield return null;
        }
    }

}
