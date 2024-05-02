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
        // ó�� ���� ���۵Ǿ� Main UI�� Ȱ��ȭ ������ �� �ְ� ��� �ҷ�����
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


        // ���� ��� ���, ���� ��޿� �ش��ϴ� ��ڻ��� ��� ���
        CalculateGradeAndTalk(currentScore);
        // �ְ� ���� ���
        CalculateHighScore(currentScore);

        gamePanel.SetActive(false);
        resultPanel.SetActive(true);

        // "���ӿ���" �ؽ�Ʈ ũ�� ��� �ִϸ��̼�
        // effectGameOver.Play(500, 200);

        // ���� ������ 0���� ī�����ϴ� �ִϸ��̼�
        // ī���� �ִϸ��̼� ���� �� ��� Fade In �ִϸ��̼� ���
        effectHighScore.Play(0, highScore);
        effectResultScore.Play(0, currentScore, effectResultGrade.FadeIn);
       
    }

    public void GoToMainMenu()
    {
        // �÷��̾� ��ġ, ����, ü�� �� �ʱ�ȭ�� �� ���� ������ �׳� ������� �ٽ� �ε�..
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

        // �ְ� �������� ���� ������ ȹ������ ��
        if (score > highScore)
        {
            // �ְ� ��� ����
            PlayerPrefs.SetString("HIGHGRADE", textResultGrade.text);
            // �ְ� ���� ����
            PlayerPrefs.SetInt("HIGHSCORE", score);

            textResultHighScore.text = score.ToString();
        }
        else
        {
            textResultHighScore.text = highScore.ToString();
        }
    }
}
