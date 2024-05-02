using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slickback : MonoBehaviour

/* 일단 지맘대로 움직이는 건 챗GPT 굴려서 코드 짰는데 이 패턴 실행 후 다음 패턴으로 안 넘어가요...
생각해봤는데
1. 패턴이랑 오브젝트 두 개에 스크립트 넣어서 그런듯? 
   그 중에서도 void start/Update때문이지 않을까...

2. 그러면 slickback 스크립트에 있는 코드들을
   Pattern_Slickback에 넣어야하는데 어떻게 넣어야하지,,,

또 열심히 생각해본 결과
1. Process Coroutine에 다 때려박는다 > 안됨ㅠ (제가 못하는 걸수도)
2. 새로운 Coroutine을 만든다 > 어렵네요... 
3. 그냥 둘 다 쓸 수 없나? 대충 나눠봤는데 > not all code paths return a value 라는 오류가 떠요
   어떻게 했는지 궁금하시면 재연해드리겠습니다 ㅎㅎ...
   모든 if에 return이 들어가야한다?는 거 같은데 뭘 넣어야할지,,,ㅜ
4. 발상의 전환으로 패턴 말고 오브젝트 스크립트에 다 넣어본다
   > 지금의 결과...

 결론 : slickback 스크립트에 있는 코드들을 Pattern_Slickback에 넣고싶은데
 void start랑 Update에 있는 코드들을 어떻게 옮겨야할 지 모르겠어염
*/
{
    [SerializeField]
    private GameObject warningImage; 
    [SerializeField]
    private GameObject slickback;
    [SerializeField]
    public AudioSource slickbackBGM;
    [SerializeField]
    private float startSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private Rigidbody2D objectRigidbody2d;
    [SerializeField]
    private float cooldownTime; // 충돌 쿨타임

    private bool canBounce = true;

    private Vector3 initialPosition;

    private void OnEnable()
    {
        StartCoroutine(nameof(Process));
    }

    private void OnDisable()
    {
        StopCoroutine(nameof(Process));
    }

    void Start()
    {
        float randomX, randomY;
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);

        Vector2 vector2 = new Vector2(randomX, randomY);
        vector2 = vector2.normalized;

       
        objectRigidbody2d.velocity = vector2 * startSpeed; // 속도를 20으로 설정
    }

    void Update()
    {
        Vector2 currentVelocity = objectRigidbody2d.velocity;

        // 현재 속도 벡터의 크기가 최대 속도를 넘지 않도록 제한
        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
            objectRigidbody2d.velocity = currentVelocity;
        }

        Vector3 position = transform.position;

        float minX = -8f;
        float maxX = 8f;
        float minY = -2f;
        float maxY = 3f;

    
        if (canBounce)
        {
            if (position.x < minX || position.x > maxX || position.y < minY || position.y > maxY)
            {
                // 경계에 닿았을 때
                // 랜덤한 각도로 튕기기
                float randomBounceAngle = Random.Range(30f, 150f);
                Vector2 newVelocity = Quaternion.Euler(0, 0, randomBounceAngle) * currentVelocity.normalized * maxSpeed;
                objectRigidbody2d.velocity = newVelocity;

                canBounce = false; // 충돌 상태 설정
                StartCoroutine(Cooldown());
            }
        }
        else
        {
            // 경계를 벗어나는 것을 방지
            float newX = Mathf.Clamp(position.x, minX, maxX);
            float newY = Mathf.Clamp(position.y, minY, maxY);
            transform.position = new Vector3(newX, newY, position.z);
        }
    }


    private IEnumerator Process()
    {
        objectRigidbody2d = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트 초기화

        //slickbackBGM.Play();

        yield return new WaitForSeconds(1f);


        slickback.SetActive(true);

        yield return new WaitForSeconds(10f);

        gameObject.SetActive(false);
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canBounce = true; // 일정 시간 후 다시 충돌 가능 상태로 설정
    }

 
}