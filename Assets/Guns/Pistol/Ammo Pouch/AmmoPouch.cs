using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class AmmoPouch : MonoBehaviour
{
    public GameObject[] mag;
    private int magIndex;
    public GameObject magInPouch;

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "LeftHand Controller" && magInPouch.transform.position != transform.position)
        {
            if(magIndex == mag.Length)
            {
                magIndex = 0;
            }
            magInPouch = mag[magIndex];
            mag[magIndex].GetComponent<XRGrabInteractable>().throwOnDetach = true;
            mag[magIndex].GetComponent<Rigidbody>().useGravity = false;
            mag[magIndex].transform.position = transform.position;
            mag[magIndex].transform.localRotation = Quaternion.identity;
            mag[magIndex].SetActive(true);
            magIndex++;
        }
    }
}