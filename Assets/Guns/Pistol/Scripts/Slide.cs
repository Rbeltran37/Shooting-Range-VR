using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Slide : MonoBehaviour
{
    public InputActionReference gribButton;
    public bool enableGunSlideTrigger;
    public Gun gun;

    public void EnableGripButton()
    {
        gribButton.action.started += ReleaseClip;
        enableGunSlideTrigger = false;
    }

    public void DisableGripButton()
    {
        gribButton.action.started -= ReleaseClip;
    }

    public void ReleaseClip(InputAction.CallbackContext context)
    {
        DisableGripButton();
        gun.GunCocked();
    }

    void OnTriggerEnter(Collider other)
    {
        if(enableGunSlideTrigger)
        {
            if(other.name == "LeftHand Controller")
            {
                EnableGripButton();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(enableGunSlideTrigger)
        {
            if(other.name == "LeftHand Controller")
            {
                DisableGripButton();
            }
        }
    }
}
