using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioClip[] soundEffects;
    private AudioSource audioSource;
    public GameObject _particle;
    public GameObject _pencil;
    public int score;
    public UIGraphics uiGraphics;
    public Action levelEnded;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void AddScore(int value)
    {
        score += value;
        print("score " + score);
        uiGraphics.scoreText.text = "Score: " + score;
        EndGame();
    }
    public void PlayCorrectMetricSound(Vector3 objectPosition, GameObject metricPrefab)
    {
        print("sound played1");
        _particle.transform.position = objectPosition;
        _particle.SetActive(false);
        audioSource.PlayOneShot(soundEffects[0]);
        _particle.SetActive(true);
        metricPrefab.SetActive(false);
        uiGraphics.UpdateScoreText(score);
        //controller.SendHapticImpulse(strongVibrate, .2f);

    }
    public void PlayIncorrectMetricSound()
    {
        print("sound played2");
        audioSource.PlayOneShot(soundEffects[1]);
        _particle.SetActive(false);
    }

    public void EndGame()//it means the current scene has finished
    {
        //score =22;
        var metrics = FindObjectsOfType<MetricPicker>();
        print("This is Metric Length"+metrics.Length); 
        if (score >= metrics.Length)
        // if (score >=7)
        {
            levelEnded?.Invoke();
            if (uiGraphics._sceneOneNumber.activeInHierarchy )//it means the scene 1 object is active=true
            {
                uiGraphics._sceneOneNumber.SetActive(false);
                uiGraphics._wallLevelTwo.SetActive(true);
                uiGraphics._sceneTwoNumber.SetActive(true);
                print("Player goes to scene 2");
            }
            else if (uiGraphics._sceneTwoNumber.activeInHierarchy)
            {
                print("Player goes to scene 3");

                uiGraphics._sceneTwoNumber.SetActive(false);
                uiGraphics._wallLevelThree.SetActive(true);
                uiGraphics._sceneThreeNumber.SetActive(true);
            }
            else if (uiGraphics._sceneThreeNumber.activeInHierarchy)
            {
                print("Player finished the game");
                uiGraphics._sceneThreeNumber.SetActive(false);
                uiGraphics._wallEndOfGamePanel.SetActive(true);
            }
        }
    }


}
