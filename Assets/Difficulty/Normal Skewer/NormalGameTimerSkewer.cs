using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NormalGameTimerSkewer : MonoBehaviour
{
    public float gameTimer;
    public float gameTimerRestart;
    public float milliseconds;
    public NormalGameModeSkewer normalGameModeSkewerScript;
    public TMP_Text timerText;
    public NormalGameOverSkewer normalGameOverSkewerScript;
    public AudioSource battleMusic;
    public AudioSource fiveSecondsLeft;
    private bool enableFivesecondsLeft = true;

    void Awake()
    {
        gameTimerRestart = gameTimer;
    }
    void OnEnable()
    {
        gameTimer = gameTimerRestart;
        milliseconds = 0;
        enableFivesecondsLeft = true;
        battleMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer -= Time.deltaTime;
        milliseconds = (gameTimer % 1) * 100;
        timerText.text = string.Format ("{0:00}:{1:00}", gameTimer, milliseconds);

        if(gameTimer <= 4.5f && enableFivesecondsLeft)
        {
            enableFivesecondsLeft = false;
            fiveSecondsLeft.Play();
        }

        if(gameTimer <= 0 && milliseconds <=0)
        {
            timerText.text = ("00:00");
            enabled = false;
            normalGameModeSkewerScript.DisableScripts();
            normalGameModeSkewerScript.enabled = false;
            normalGameOverSkewerScript.enabled = true;
            battleMusic.Stop();
        }
    }
}
