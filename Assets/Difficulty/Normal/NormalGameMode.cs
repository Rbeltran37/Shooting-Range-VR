using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGameMode : MonoBehaviour
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
        masterChief[0].transform.position = new Vector3(10, 0.1f, 5.85f);
        masterChief[0].transform.eulerAngles = new Vector3(-180,0,-180);
        masterChief[0].GetComponent<MasterChiefCrouching>().enabled = true;
        masterChief[1].transform.position = new Vector3(12, 0.1f, 19);
        masterChief[1].transform.eulerAngles = new Vector3(-180,90,-180);
        masterChief[1].GetComponent<MasterChiefRunning>().startingRunSpeed = 6;
        masterChief[1].GetComponent<MasterChiefRunning>().StartingRunTime = 4;
        masterChief[1].GetComponent<MasterChiefRunning>().enabled = true;
        masterChief[2].transform.position = new Vector3(-10, 0.1f, 5.85f);
        masterChief[2].transform.eulerAngles = new Vector3(-180,0,-180);
        masterChief[2].GetComponent<MasterChiefCrouching>().enabled = true;
        masterChief[3].transform.position = new Vector3(-12, 0.1f, 9);
        masterChief[3].transform.eulerAngles = new Vector3(-180,270,-180);
        masterChief[3].GetComponent<MasterChiefRunning>().startingRunSpeed = 6;
        masterChief[3].GetComponent<MasterChiefRunning>().StartingRunTime = 4;
        masterChief[3].GetComponent<MasterChiefRunning>().enabled = true;
        masterChief[4].transform.position = new Vector3(-7, 0.1f, 5.85f);
        masterChief[4].transform.eulerAngles = new Vector3(-180,180,-180);
        masterChief[4].GetComponent<MasterChiefRunning>().startingRunSpeed = 6;
        masterChief[4].GetComponent<MasterChiefRunning>().StartingRunTime = 2.5f;
        masterChief[4].GetComponent<MasterChiefRunning>().enabled = true;
        masterChief[5].transform.position = new Vector3(7, 0.1f, 21f);
        masterChief[5].transform.eulerAngles = new Vector3(-180,0,-180);
        masterChief[5].GetComponent<MasterChiefRunning>().startingRunSpeed = 6;
        masterChief[5].GetComponent<MasterChiefRunning>().StartingRunTime = 2.5f;
        masterChief[5].GetComponent<MasterChiefRunning>().enabled = true;
        masterChief[6].transform.position = new Vector3(0, 0.1f, 5.85f);
        masterChief[6].transform.eulerAngles = new Vector3(-180,0,-180);
        masterChief[6].GetComponent<MasterChiefCrouching>().enabled = true;
        masterChief[7].transform.position = new Vector3(10, 0.1f, 5.85f);
        masterChief[7].transform.eulerAngles = new Vector3(-180,0,-180);
        masterChief[7].GetComponent<MasterChiefCrouching>().enabled = true;
        masterChief[8].transform.position = new Vector3(12, 0.1f, 19);
        masterChief[8].transform.eulerAngles = new Vector3(-180,90,-180);
        masterChief[8].GetComponent<MasterChiefRunning>().startingRunSpeed = 6;
        masterChief[8].GetComponent<MasterChiefRunning>().StartingRunTime = 4;
        masterChief[8].GetComponent<MasterChiefRunning>().enabled = true;
        masterChief[9].transform.position = new Vector3(-10, 0.1f, 5.85f);
        masterChief[9].transform.eulerAngles = new Vector3(-180,0,-180);
        masterChief[9].GetComponent<MasterChiefCrouching>().enabled = true;
        masterChief[10].transform.position = new Vector3(-12, 0.1f, 9);
        masterChief[10].transform.eulerAngles = new Vector3(-180,270,-180);
        masterChief[10].GetComponent<MasterChiefRunning>().startingRunSpeed = 6;
        masterChief[10].GetComponent<MasterChiefRunning>().StartingRunTime = 4;
        masterChief[10].GetComponent<MasterChiefRunning>().enabled = true;
        masterChief[11].transform.position = new Vector3(-7, 0.1f, 5.85f);
        masterChief[11].transform.eulerAngles = new Vector3(-180,180,-180);
        masterChief[11].GetComponent<MasterChiefRunning>().startingRunSpeed = 6;
        masterChief[11].GetComponent<MasterChiefRunning>().StartingRunTime = 2.5f;
        masterChief[11].GetComponent<MasterChiefRunning>().enabled = true;
        masterChief[12].transform.position = new Vector3(7, 0.1f, 21f);
        masterChief[12].transform.eulerAngles = new Vector3(-180,0,-180);
        masterChief[12].GetComponent<MasterChiefRunning>().startingRunSpeed = 6;
        masterChief[12].GetComponent<MasterChiefRunning>().StartingRunTime = 2.5f;
        masterChief[12].GetComponent<MasterChiefRunning>().enabled = true;
        masterChief[13].transform.position = new Vector3(0, 0.1f, 5.85f);
        masterChief[13].transform.eulerAngles = new Vector3(-180,0,-180);
        masterChief[13].GetComponent<MasterChiefCrouching>().enabled = true;
        for (int i = 0; i < masterChief.Length; i++)
        {
            masterChief[i].GetComponent<MasterChief>().health = 9;
            masterChief[i].GetComponent<MasterChief>().healthAfterShieldDown = 3;
        }
    }

    public void SpawnNewEnemy()
    {
        if(NumberOfEnemiesKilled == 0 || NumberOfEnemiesKilled == 7)
        {
            masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
            masterChief[masterChiefIndex].SetActive(true);
            masterChiefIndex++;
            masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
            masterChief[masterChiefIndex].SetActive(true);
            masterChiefIndex++;
            masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
            masterChief[masterChiefIndex].SetActive(true);
            masterChiefIndex++;
            masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
            masterChief[masterChiefIndex].SetActive(true);
            masterChiefIndex++;
        }

        else if(NumberOfEnemiesKilled == 4 || NumberOfEnemiesKilled == 11)
        {
            masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
            masterChief[masterChiefIndex].SetActive(true);
            masterChiefIndex++;
            masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
            masterChief[masterChiefIndex].SetActive(true);
            masterChiefIndex++;
            masterChief[masterChiefIndex].GetComponent<MasterChief>().enabled = true;
            masterChief[masterChiefIndex].SetActive(true);
            masterChiefIndex++;
        }
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
        }
    }
}
