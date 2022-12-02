using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGameModeAR : MonoBehaviour
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
    private int randomSpawnPoint;
    private int[] yPositions = new int[] {-17,17};

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
            randomSpawnPoint = (Random.Range(0,2));
            if (randomSpawnPoint == 0)
            {
                masterChief[i].transform.position = new Vector3(-17, 0.1f, (Random.Range(7f, 25f)));
                masterChief[i].transform.rotation = Quaternion.Euler(-180, 270, -180);
            }
            else
            {
                masterChief[i].transform.position = new Vector3(17, 0.1f, (Random.Range(7f, 25f)));
                masterChief[i].transform.rotation = Quaternion.Euler(-180, 90, -180);
            }
            masterChief[i].GetComponent<MasterChiefRunning>().enabled = true;
            masterChief[i].GetComponent<MasterChiefRunning>().startingRunSpeed = 7;
            masterChief[i].GetComponent<MasterChiefRunning>().StartingRunTime = 4.85f;
            masterChief[i].GetComponent<MasterChief>().health = 17;
            masterChief[i].GetComponent<MasterChief>().healthAfterShieldDown = 5;
        }
    }

    public void SpawnNewEnemy()
    {
        masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
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
        }
    }
}
