using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AssaultRifleAmmoBox : MonoBehaviour
{
    public GameObject[] mag;
    private int magIndex;
    public GameObject magInPouch;
    public Transform spawnTransform;

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "LeftHand Controller" && magInPouch.transform.position != spawnTransform.position)
        {
            if(magIndex == mag.Length)
            {
                magIndex = 0;
            }
            magInPouch = mag[magIndex];
            mag[magIndex].GetComponent<XRGrabInteractable>().throwOnDetach = true;
            mag[magIndex].GetComponent<Rigidbody>().useGravity = false;
            mag[magIndex].transform.position = spawnTransform.position;
            mag[magIndex].transform.localRotation = Quaternion.identity;
            mag[magIndex].SetActive(true);
            magIndex++;
        }
    }
}