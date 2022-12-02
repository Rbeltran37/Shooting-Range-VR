using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SkewerReload : MonoBehaviour
{
    public Transform bulletInsertedTransform;
    public AudioSource bulletInserted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Skewer Bullet")
        {
            bulletInserted.Play();
            gameObject.SetActive(false);
            other.transform.GetComponent<XRGrabInteractable>().enabled = false;
            other.transform.SetParent(bulletInsertedTransform);
            other.transform.localRotation = Quaternion.Euler(0, 0, 0);
            other.transform.localPosition = new Vector3(-5.8f,0,0);
            other.transform.GetComponent<SkewerReloadAnimation>().enabled = true;
            other.transform.GetComponent<SkewerBullet>().enabled = true;
        }
    }
}
