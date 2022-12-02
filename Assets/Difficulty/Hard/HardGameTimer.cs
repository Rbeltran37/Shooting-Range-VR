using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HardGameTimer : MonoBehaviour
{
    public float gameTimer;
    public float gameTimerRestart;
    public float milliseconds;
    public HardGameMode hardGameModeScript;
    public TMP_Text timerText;
    public HardGameOver hardGameOverScript;
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
            hardGameModeScript.DisableScripts();
            hardGameModeScript.enabled = false;
            hardGameOverScript.enabled = true;
            battleMusic.Stop();
        }
    }
}
