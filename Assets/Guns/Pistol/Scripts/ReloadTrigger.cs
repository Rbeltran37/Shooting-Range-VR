using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReloadTrigger : MonoBehaviour
{
    public Gun Gun;
    public Transform mags;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.name == "new mag trigger")
        {
            other.transform.parent.GetComponent<XRGrabInteractable>().throwOnDetach = false;
            other.transform.parent.gameObject.SetActive(false);
            other.transform.parent.SetParent(mags);
            Gun.NewMagInserted();
            gameObject.SetActive(false);
        }
    }
}
