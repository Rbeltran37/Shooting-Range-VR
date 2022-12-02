using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Skewer : MonoBehaviour
{
    public GameObject bullet;
    public Transform skewerBulletTransform;
    public GameObject reloadTrigger;
    public TwoHandedGrabSkewer twoHandedGrabSkewerScript;
    public Renderer led;
    public Material red;
    public Material green;
    public Renderer crossairRenderer;
    public AudioSource skewerShot;
    public AudioSource shotReady;
    public XRDirectInteractor primaryHand;
    public XRDirectInteractor secondaryHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        if(bullet != null && twoHandedGrabSkewerScript.bothHandsOnGun)
        {
            primaryHand.SendHapticImpulse(1f, .2f);
            secondaryHand.SendHapticImpulse(1f, .2f);
            bullet.name = "Skewer Bullet (shot)";
            skewerShot.Play();
            bullet.GetComponent<Rigidbody>().useGravity = true;
            bullet.GetComponent<Rigidbody>().isKinematic = false;
            bullet.GetComponent<Rigidbody>().AddForce(-bullet.transform.right * 40f, ForceMode.Impulse);
            bullet.transform.SetParent(skewerBulletTransform);
            reloadTrigger.SetActive(true);
            bullet = null;
            NotReadyToShoot();
        }
    }

    public void ReadyToShoot()
    {
        shotReady.Play();
        led.material = green;
        crossairRenderer.material.color = Color.green;
    }

    public void NotReadyToShoot()
    {
        led.material = red;
        crossairRenderer.material.color = Color.red;
    }
}
