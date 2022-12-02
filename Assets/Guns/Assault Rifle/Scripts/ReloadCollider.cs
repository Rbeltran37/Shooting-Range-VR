using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReloadCollider : MonoBehaviour
{
    public AssaultRifle assaultRifleScript;
    public Transform assaultRifleMags;

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "new mag trigger")
        {
            other.transform.parent.GetComponent<XRGrabInteractable>().throwOnDetach = false;
            other.transform.parent.gameObject.SetActive(false);
            other.transform.parent.SetParent(assaultRifleMags);
            assaultRifleScript.NewMagInserted();
            gameObject.SetActive(false);
        }
    }
}
