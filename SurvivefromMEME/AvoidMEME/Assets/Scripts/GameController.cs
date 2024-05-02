using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField]
    private UIController uIController;
    [SerializeField]
    // private GameObject pattern01; -> 패턴 1개일 때는 씀
    private PatternController patternController;
    [SerializeField]
    private AvatarController avatarController;
    [SerializeField]
    private GameObject[] player;
    [SerializeField]
    private PlayerShield playerShield;
    [SerializeField]
    private GameObject ShieldImage;
    [SerializeField]
    private GameObject SwordImage;

    private readonly float scoreScale = 20; // 점수 증가 계수 (읽기 전용)

    public int AvatarIndex = 0;

    // 플레이어 점수 (죽지 않고 버틴 시간)
    public float CurrentScore { private set; get; } = 0;

    public bool IsGamePlay { private set; get; } = false;

    public void PlusScore(float score)
    {
        CurrentScore += score;
    }

    public void GameStart()
    {

        uIController.GameStart();

        patternController.GameStart();
        //pattern01.SetActive(true);
        AvatarIndex = avatarController.GetAvatar();
        if (AvatarIndex == 0)
        {
            player[0].SetActive(true);
            IsGamePlay = true;
            ShieldImage.SetActive(false);
            SwordImage.SetActive(false);
        }
        else if (AvatarIndex == 1) // 커비
        {
            player[1].SetActive(true);
            IsGamePlay = true;
            ShieldImage.SetActive(true);
            SwordImage.SetActive(false);
        }
        else if (AvatarIndex == 2) // 전사
        {
            player[2].SetActive(true);
            IsGamePlay = true;
            ShieldImage.SetActive(true);
            SwordImage.SetActive(true);
        }
        else if (AvatarIndex == 3) // 닌자
        {
            player[3].SetActive(true);
            IsGamePlay = true;
            ShieldImage.SetActive(false);
            SwordImage.SetActive(false);
        }

        

    }

    public void GameExit()
    {
#if     UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void GameOver()
    {
        uIController.GameOver();

        patternController.GameOver();
        //pattern01.SetActive(false);

        IsGamePlay = false;
    }
    private void Update()
    {
        if (IsGamePlay == false) return;
        CurrentScore += Time.deltaTime * scoreScale;
    }
}
