using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterChiefRandomMovement : MonoBehaviour
{
    public float speed;
    public float runInDirectionTimer;
    public float runInDirectionTimerRestart;
    public int DirectionToRunIn;
    public Animator masterChiefAnimator;
    public MasterChief masterChiefScript;

    // Start is called before the first frame update
    void Start()
    {
        DirectionToRunIn = (Random.Range(0, 4));
        runInDirectionTimer = (Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(0,transform.position.y,0));
        runInDirectionTimer -= Time.deltaTime;
        MoveIntoPlayArea();

        if(masterChiefScript.enabled == false)
        {
            enabled = false;
        }

        if(runInDirectionTimer <= 0)
        {
            DirectionToRunIn = (Random.Range(0, 4));
            runInDirectionTimer = (Random.Range(0f, 2f));
        }
        
        if(DirectionToRunIn == 0)
        {
            MoveRight();
        }
        
        else if(DirectionToRunIn == 1)
        {
            MoveLeft();
        }
        
        else if(DirectionToRunIn == 2)
        {
            MoveForward();
        }
        
        else if(DirectionToRunIn == 3)
        {
            MoveBackward();
        }
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        masterChiefAnimator.Play("Run Right");
    }

    void MoveLeft()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
        masterChiefAnimator.Play("Run Left");
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        masterChiefAnimator.Play("Run Forward");
    }

    void MoveBackward()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        masterChiefAnimator.Play("Run Backwards");
    }

    void MoveIntoPlayArea()
    {
        if(transform.position.x <= -18)
        {
            DirectionToRunIn = 1;
            runInDirectionTimer = (Random.Range(0f, 2f));
        }

        if(transform.position.x >= 18)
        {
            DirectionToRunIn = 0;
            runInDirectionTimer = (Random.Range(0f, 2f));
        }

        if(transform.position.z <= 5)
        {
            DirectionToRunIn = 3;
            runInDirectionTimer = (Random.Range(0f, 2f));
        }

        if(transform.position.z >= 24)
        {
            DirectionToRunIn = 2;
            runInDirectionTimer = (Random.Range(0f, 2f));
        }
    }
}
