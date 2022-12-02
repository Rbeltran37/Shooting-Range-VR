using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterChief : MonoBehaviour
{
    public int health;
    public int StartHealth;
    public Animator masterChiefAnimator;
    public Animator shieldAnimator;
    public bool headshot;
    private bool shieldIsDown;
    private bool isDead;
    public EasyGameMode easyGameModeScript;
    public NormalGameMode normalGameModeScript;
    public HardGameMode hardGameModeScript;
    public EasyGameModeAR easyGameModeARScript;
    public NormalGameModeAR normalGameModeARScript;
    public HardGameModeAR hardGameModeARScript;
    public EasyGameModeSkewer easyGameModeSkewerScript;
    public NormalGameModeSkewer normalGameModeSkewerScript;
    public HardGameModeSkewer hardGameModeSkewerScript;
    public int healthAfterShieldDown;
    public AudioSource killed;
    // Start is called before the first frame update
    void Awake()
    {
        //StartHealth = health;
    }

    // Update is called once per frame
    void OnEnable()
    {
        //health = StartHealth;
        headshot = false;
        shieldIsDown = false;
        isDead = false;
    }

    void OnDisable()
    {
        if(!isDead)
        {
            masterChiefAnimator.CrossFade("Master Chief Idle", .1f);
        }
    }

    public void EnenmyHit()
    {
        health--;
        if (shieldIsDown && headshot)
        {
            health--;
            health--;
        }
        if (health > healthAfterShieldDown)
        {
            shieldAnimator.Play("Shield Hit", -1, 0f);
        }
        else if(health == healthAfterShieldDown)
        {
            shieldIsDown = true;
            shieldAnimator.Play("Shield Gone");
        }
        else if(health <= 0 && !isDead)
        {
            masterChiefAnimator.CrossFade("Dying", .1f);
            isDead = true;
            enabled = false;
            killed.Play();
            AddKillAndSpawnNewEnemy();
        }
    }

    public void DisableMasterChief()
    {
        gameObject.SetActive(false);
    }

    public void AddKillAndSpawnNewEnemy()
    {
        if(easyGameModeScript.enabled == true)
        {
            easyGameModeScript.EnemyKilled();
            easyGameModeScript.SpawnNewEnemy();
        }

        else if(normalGameModeScript.enabled == true)
        {
            normalGameModeScript.EnemyKilled();
            normalGameModeScript.SpawnNewEnemy();
        }

        else if(hardGameModeScript.enabled == true)
        {
            hardGameModeScript.EnemyKilled();
            hardGameModeScript.SpawnNewEnemy();
        }

        else if(easyGameModeARScript.enabled == true)
        {
            easyGameModeARScript.EnemyKilled();
            easyGameModeARScript.SpawnNewEnemy();
        }

        else if(normalGameModeARScript.enabled == true)
        {
            normalGameModeARScript.EnemyKilled();
            normalGameModeARScript.SpawnNewEnemy();
        }

        else if(hardGameModeARScript.enabled == true)
        {
            hardGameModeARScript.EnemyKilled();
            hardGameModeARScript.SpawnNewEnemy();
        }

        else if(easyGameModeSkewerScript.enabled == true)
        {
            easyGameModeSkewerScript.EnemyKilled();
            easyGameModeSkewerScript.SpawnNewEnemy();
        }

        else if(normalGameModeSkewerScript.enabled == true)
        {
            normalGameModeSkewerScript.EnemyKilled();
            normalGameModeSkewerScript.SpawnNewEnemy();
        }

        else if(hardGameModeSkewerScript.enabled == true)
        {
            hardGameModeSkewerScript.EnemyKilled();
            hardGameModeSkewerScript.SpawnNewEnemy();
        }
    }
}
