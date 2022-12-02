using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SkewerAmmoBox : MonoBehaviour
{
    public GameObject[] bullets;
    private int bulletsIndex;
    public GameObject bulletInPouch;
    public Transform spawnTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "LeftHand Controller" && bulletInPouch.transform.position != spawnTransform.position)
        {
            if(bulletsIndex == bullets.Length)
            {
                bulletsIndex = 0;
            }

            bulletInPouch = bullets[bulletsIndex];
            bullets[bulletsIndex].name = "Skewer Bullet";
            bullets[bulletsIndex].transform.position = spawnTransform.position;
            bullets[bulletsIndex].transform.localRotation = Quaternion.Euler(90,0,-90);
            bullets[bulletsIndex].GetComponent<Rigidbody>().isKinematic = true;
            bullets[bulletsIndex].GetComponent<Rigidbody>().useGravity = false;
            bullets[bulletsIndex].GetComponent<XRGrabInteractable>().enabled = true;
            bullets[bulletsIndex].GetComponent<SkewerBullet>().enabled = false;
            bullets[bulletsIndex].SetActive(true);
            bulletsIndex++;
        }
    }
}
