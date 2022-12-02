using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterChiefRunning : MonoBehaviour
{
    public Animator masterChiefAnimator;
    public float runSpeed;
    public float startingRunSpeed;
    public float runTime;
    public float StartingRunTime;
    private Transform startingPosition;
    public MasterChief masterChiefScript;

    void Awake()
    {

    }
    void OnEnable()
    {
        runSpeed = startingRunSpeed;
        runTime = StartingRunTime;
        masterChiefAnimator.Play("Run");
    }

    void OnDisable()
    {
        //transform.rotation = Quaternion.Euler(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        runTime -= Time.deltaTime;
        transform.Translate(Vector3.forward * runSpeed *Time.deltaTime);

        if(masterChiefScript.enabled == false)
        {
            enabled = false;
        }

        if(runTime <= 0)
        {
            runSpeed = 0;
            masterChiefAnimator.Play("Turn");

            if((masterChiefAnimator.GetCurrentAnimatorStateInfo(0).IsName("Turn") && masterChiefAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f))
            {
                transform.rotation *= Quaternion.Euler(0,180f,0);
                masterChiefAnimator.Play("Run");
                runTime = StartingRunTime;
                runSpeed = startingRunSpeed;
            }
        }
    }
}
