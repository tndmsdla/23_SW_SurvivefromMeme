using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;


    [Header("Main UI")]
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private TextMeshProUGUI textMainGrade;

    [Header("Game UI")]
    [SerializeField]
    private GameObject gamePanel;
    [SerializeField]
    private TextMeshProUGUI textScore;

    [Header("Result UI")]
    [SerializeField]
    private GameObject resultPanel;
    [SerializeField]
    private TextMeshProUGUI textResultScore;
    [SerializeField]
    private TextMeshProUGUI textResultGrade;
    //[SerializeField]
    //private TextMeshProUGUI textResultTalk;
    [SerializeField]
    private TextMeshProUGUI textResultHighScore;

    [Header("Result UI Animation")]
    // [SerializeField]
    // private ScaleEffect effectGameOver;
    [SerializeField]
    private CountingEffect effectResultScore;
    [SerializeField]
    private CountingEffect effectHighScore;
    [SerializeField]
    private FadeEffect effectResultGrade;

    private void Awake()
    {
        // 처음 씬이 시작되어 Main UI가 활성화 상태일 때 최고 등급 불러오기
        textMainGrade.text = PlayerPrefs.GetString("HIGHGRADE");
    }

    public void GameStart()
    {
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void GameOver()
    {
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");
        int currentScore = (int)gameController.CurrentScore;


        // 현재 등급 출력, 현재 등급에 해당하는 고박사의 대사 출력
        CalculateGradeAndTalk(currentScore);
        // 최고 점수 출력
        CalculateHighScore(currentScore);

        gamePanel.SetActive(false);
        resultPanel.SetActive(true);

        // "게임오버" 텍스트 크기 축소 애니메이션
        // effectGameOver.Play(500, 200);

        // 현재 점수를 0부터 카운팅하는 애니메이션
        // 카운팅 애니메이션 종료 후 등급 Fade In 애니메이션 재생
        effectHighScore.Play(0, highScore);
        effectResultScore.Play(0, currentScore, effectResultGrade.FadeIn);
       
    }

    public void GoToMainMenu()
    {
        // 플레이어 위치, 점수, 체력 등 초기화할 게 많기 때문에 그냥 현재씬을 다시 로드..
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToYoutube()
    {
        Application.OpenURL("https://www.youtube.com/curihuslab");
    }

    private void Update()
    {
        textScore.text = gameController.CurrentScore.ToString("F0");
    }


    private void CalculateGradeAndTalk(int score)
    {
        if (score < 1000)
        {
            textResultGrade.text = "F";
        }
        else if (score < 3000)
        {
            textResultGrade.text = "D";
        }
        else if (score < 5000)
        {
            textResultGrade.text = "C";
        }
        else if (score < 10000)
        {
            textResultGrade.text = "B";
        }
        else if (score < 20000)
        {
            textResultGrade.text = "A";
        }
        else
        {
            textResultGrade.text = "S";
        }
    }

    private void CalculateHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");

        // 최고 점수보다 높은 점수를 획득했을 때
        if (score > highScore)
        {
            // 최고 등급 갱신
            PlayerPrefs.SetString("HIGHGRADE", textResultGrade.text);
            // 최고 점수 갱신
            PlayerPrefs.SetInt("HIGHSCORE", score);

            textResultHighScore.text = score.ToString();
        }
        else
        {
            textResultHighScore.text = highScore.ToString();
        }
    }
}
