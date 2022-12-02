using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDifficultySkewer : MonoBehaviour
{
    public float timer;
    public float restartTimer;
    public HardPreGameTimerSkewer hardPreGameTimerSkewerScript;
    public Collider[] difficultyColliders;
    private bool disableColliders;
    public AudioSource selectSound;
    public AudioSource menuMusic;
    public GunInUse gunInUseScript;

    void Awake()
    {
        restartTimer = timer;
    }
    void OnEnable()
    {
        gunInUseScript.skewerGameInProgress = true;
        timer = restartTimer;
        disableColliders = true;
        selectSound.Play();
    }

    void OnDisable()
    {
        menuMusic.Stop();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        for (int i = 0; i < difficultyColliders.Length; i++)
        {
            difficultyColliders[i].enabled = true;
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(disableColliders)
        {
            for (int i = 0; i < difficultyColliders.Length; i++)
            {
                difficultyColliders[i].enabled = false;
            }
            disableColliders = false;
        }

        transform.Rotate(new Vector3(0, -406f * timer, 0) * Time.deltaTime);

        if(timer <= 0)
        {
            hardPreGameTimerSkewerScript.enabled = true;
            enabled = false;
        }
    }
}
