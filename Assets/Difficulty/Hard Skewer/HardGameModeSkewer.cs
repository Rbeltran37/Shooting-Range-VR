using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardGameModeSkewer : MonoBehaviour
{
    public GameObject[] masterChief;
    public int masterChiefIndex;
    public GameObject stars;
    public Material earnedStarMaterial;
    public Material emptyStarMaterial;
    public int NumberOfEnemiesKilled;
    public Renderer firstStarRenderer;
    public Renderer secondStarRenderer;
    public Renderer thirdStarRenderer;
    public int starsEarned;
    public int killsForFirstStar;
    public int killsForSecondStar;
    public int killsForThirdStar;

    void OnEnable()
    {
        PositionEnemiesAndHealth();
        masterChiefIndex = 0;
        NumberOfEnemiesKilled = 0;
        SpawnNewEnemy();
        starsEarned = 0;
        firstStarRenderer.sharedMaterial = emptyStarMaterial;
        secondStarRenderer.sharedMaterial = emptyStarMaterial;
        thirdStarRenderer.sharedMaterial = emptyStarMaterial;
        //stars.SetActive(true);
    }

    public void PositionEnemiesAndHealth()
    {
        for (int i = 0; i < masterChief.Length; i++)
        {
            masterChief[i].transform.position = new Vector3((Random.Range(-17f, 17f)),0.1f,(Random.Range(7f, 23f)));
            masterChief[i].GetComponent<MasterChief>().health = 1;
            masterChief[i].GetComponent<MasterChief>().healthAfterShieldDown = 1;
        }
    }

    public void SpawnNewEnemy()
    {
        masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
        masterChief[masterChiefIndex].GetComponent<MasterChiefRandomMovement>().enabled = true;
        masterChief[masterChiefIndex].SetActive(true);
        masterChiefIndex++;
    }

    public void EnemyKilled()
    {
        NumberOfEnemiesKilled++;

        if(NumberOfEnemiesKilled == killsForFirstStar)
        {
            starsEarned = 1;
            firstStarRenderer.sharedMaterial = earnedStarMaterial;
        }

        if(NumberOfEnemiesKilled == killsForSecondStar)
        {
            starsEarned = 2;
            secondStarRenderer.sharedMaterial = earnedStarMaterial;
        }

        if(NumberOfEnemiesKilled == killsForThirdStar)
        {
            starsEarned = 3;
            thirdStarRenderer.sharedMaterial = earnedStarMaterial;
        }
    }

    public void disableEnemies()
    {
        for (int i = masterChiefIndex - 1; i > -1; i--)
        {
            masterChief[i].SetActive(false);
        }
    }

    public void DisableScripts()
    {
        for (int i = 0; i < masterChief.Length; i++)
        {
            masterChief[i].GetComponent<MasterChief>().enabled = false;
            masterChief[i].GetComponent<MasterChiefRunning>().enabled = false;
            masterChief[i].GetComponent<MasterChiefCrouching>().enabled = false;
            masterChief[i].GetComponent<MasterChiefRandomMovement>().enabled = false;
        }
    }
}
