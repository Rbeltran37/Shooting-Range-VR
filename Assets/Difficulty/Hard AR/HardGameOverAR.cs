using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HardGameOverAR : MonoBehaviour
{
    public AudioSource airhorn;
    public float timerToResetGame;
    public float timerToResetGameReset;
    public HardGameModeAR hardGameModeARScript;
    public bool enemiesBeamed;
    public bool enemiesAndBeamsDisabled;
    public Material earnedStarMaterial;
    public Renderer[] menuStarRenderer;
    public int previousHighestStarsEarned;
    public GameObject[] enableMenuGameObjects;
    public GameObject stars;
    public TMP_Text timerText;
    public GameObject[] gameOverStars;
    public GameObject gameOverMasterChief;
    public Material gameOverEarnedStarMaterial;
    public Material gameOverEmptyStarMaterial;
    public Animator victoryPoses;
    private bool gameObjectsEnabled;
    public AudioSource menuMusic;
    public AudioSource[] starAudio;
    private int starAudioIndex;
    public GunInUse gunInUseScript;

    void Awake()
    {
        timerToResetGameReset = timerToResetGame;
    }
    void OnEnable()
    {
        timerToResetGame = timerToResetGameReset;
        enemiesBeamed = false;
        enemiesAndBeamsDisabled = false;
        gameObjectsEnabled = false;
        airhorn.Play();
        CheckHighScore();
        timerText.text = ("");
        stars.SetActive(false);
        hardGameModeARScript.disableEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        timerToResetGame -= Time.deltaTime;

        if(timerToResetGame <= 9 && !gameObjectsEnabled)
        {
            enableGameOverObjects();
            GameOverStarsEarned();
            gameObjectsEnabled = true;
        }

        if(timerToResetGame <= 7 && !enemiesBeamed)
        {
            enemiesBeamed = true;
            starAudio[starAudioIndex].Play();
        }

        if(timerToResetGame <= 0 && !enemiesAndBeamsDisabled)
        {
            UpdateNumberOfStarsEarned();
            EnableStartMenu();
            enemiesAndBeamsDisabled = true;
            enabled = false;
            menuMusic.Play();
            disableGameOverObjects();
            gunInUseScript.assaultRifleGameInProgress = false;
            gunInUseScript.AssaultRifleGameEnded();
        }
    }

    public void UpdateNumberOfStarsEarned()
    {
        if(previousHighestStarsEarned >= 1)
        {
            menuStarRenderer[0].sharedMaterial = earnedStarMaterial;
            menuStarRenderer[1].sharedMaterial = earnedStarMaterial;
        }
        if (previousHighestStarsEarned >= 2)
        {
            menuStarRenderer[2].sharedMaterial = earnedStarMaterial;
            menuStarRenderer[3].sharedMaterial = earnedStarMaterial;
        }
        if (previousHighestStarsEarned == 3)
        {
            menuStarRenderer[4].sharedMaterial = earnedStarMaterial;
            menuStarRenderer[5].sharedMaterial = earnedStarMaterial;
        }
    }
    
    public void CheckHighScore()
    {
        if(previousHighestStarsEarned < hardGameModeARScript.starsEarned)
        {
            previousHighestStarsEarned = hardGameModeARScript.starsEarned;
        }
    }

    public void EnableStartMenu()
    {
        for (int i = 0; i < enableMenuGameObjects.Length; i++)
        {
            enableMenuGameObjects[i].SetActive(true);
        }
    }

    public void enableGameOverObjects()
    {
        gameOverStars[0].SetActive(true);
        gameOverStars[1].SetActive(true);
        gameOverStars[2].SetActive(true);
        gameOverMasterChief.SetActive(true);
    }

    public void disableGameOverObjects()
    {
        gameOverStars[0].SetActive(false);
        gameOverStars[1].SetActive(false);
        gameOverStars[2].SetActive(false);
        gameOverMasterChief.SetActive(false);
    }

    public void GameOverStarsEarned()
    {
        if(hardGameModeARScript.starsEarned == 0)
        {
            gameOverStars[0].GetComponent<Renderer>().material = gameOverEmptyStarMaterial;
            gameOverStars[1].GetComponent<Renderer>().material = gameOverEmptyStarMaterial;
            gameOverStars[2].GetComponent<Renderer>().material = gameOverEmptyStarMaterial;
            victoryPoses.SetInteger("Stars", 0);
            starAudioIndex = 0;
        }
        else if(hardGameModeARScript.starsEarned == 1)
        {
            gameOverStars[0].GetComponent<Renderer>().material = gameOverEarnedStarMaterial;
            gameOverStars[1].GetComponent<Renderer>().material = gameOverEmptyStarMaterial;
            gameOverStars[2].GetComponent<Renderer>().material = gameOverEmptyStarMaterial;
            victoryPoses.SetInteger("Stars", 1);
            starAudioIndex = 1;
        }
        else if(hardGameModeARScript.starsEarned == 2)
        {
            gameOverStars[0].GetComponent<Renderer>().material = gameOverEarnedStarMaterial;
            gameOverStars[1].GetComponent<Renderer>().material = gameOverEarnedStarMaterial;
            gameOverStars[2].GetComponent<Renderer>().material = gameOverEmptyStarMaterial;
            victoryPoses.SetInteger("Stars", 2);
            starAudioIndex = 2;
        }
        else if(hardGameModeARScript.starsEarned == 3)
        {
            gameOverStars[0].GetComponent<Renderer>().material = gameOverEarnedStarMaterial;
            gameOverStars[1].GetComponent<Renderer>().material = gameOverEarnedStarMaterial;
            gameOverStars[2].GetComponent<Renderer>().material = gameOverEarnedStarMaterial;
            victoryPoses.SetInteger("Stars", 3);
            starAudioIndex = 3;
        }
    }
}
