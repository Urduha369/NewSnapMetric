using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGraphics : MonoBehaviour
{
    [SerializeField]
    private GameObject endScreen;

    public TMP_Text scoreText;
    public GameObject _wallWelcomePanel;
    public GameObject _wallTutorialPanel;
    public GameObject _sceneOneNumber;
    public GameObject _wallLevelTwo;
    public GameObject _sceneTwoNumber;
    public GameObject _wallLevelThree;
    public GameObject _sceneThreeNumber;
    public GameObject _wallEndOfGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        _wallWelcomePanel.SetActive(true);
        GameManager.instance.levelEnded += EndGame;
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = $"Score Is {score}";
    }
}

