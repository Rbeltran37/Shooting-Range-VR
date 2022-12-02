using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterChiefCrouching : MonoBehaviour
{
    public Animator masterChiefAnimator;
    public MasterChief masterChiefScript;
    // Start is called before the first frame update
    void OnEnable()
    {
        masterChiefAnimator.Play("Crouch");
    }

    void Update()
    {
        if(masterChiefScript.enabled == false)
        {
            enabled = false;
        }
    }
}
