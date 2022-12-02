using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class AssaultRifle : MonoBehaviour
{
    public Transform shootPoint;
    public LineRenderer laser;
    private RaycastHit raycastHit;
    public Transform grabAttachTransform;
    public InputActionReference secondaryButtonReference;
    public InputActionReference primaryButtonReference;
    public bool triggerBeingHeld;
    public float shotPerSecond;
    private float nextTimeToFire;
    public float bullets;
    private float maxBullets;
    public AudioSource gunshot;
    public AudioSource dryfire;
    private bool gunHasMagazine = true;
    public TMP_Text ammoCountText;
    public ParticleSystem  muzzleflash;
    public Animator assaultRifleAnimator;
    public GameObject reloadCollider;
    public int emptyMagIndex;
    public GameObject[] emptyMag;
    public GameObject magazine;
    public XRGrabInteractable gunSlideXRGrabInteractable;
    public bool gunCocked = true;
    public AudioSource magInserted;
    public XRDirectInteractor primaryHand;
    public XRDirectInteractor secondaryHand;
    public TwoHandGrabInteractable twoHandGrabInteractable;
    
    // Start is called before the first frame update
    void Start()
    {
        maxBullets = bullets;
    }

    // Update is called once per frame
    void Update()
    {

        Raycast();
        Shoot();
    }

    public void Raycast()
    {
        laser.SetPosition(0, shootPoint.position);
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out raycastHit))
        {
            if (raycastHit.collider)
            {
                laser.SetPosition(1, raycastHit.point);
            }
        }
        else laser.SetPosition(1, shootPoint.forward*5000);
    }

    public void EnableControllerButtons()
    {
        secondaryButtonReference.action.started += TurnOffLaser;
        primaryButtonReference.action.started += ReleaseClip;
    }

    public void DisableControllerButtons()
    {
        secondaryButtonReference.action.started -= TurnOffLaser;
        primaryButtonReference.action.started -= ReleaseClip;
    }

    public void Shoot()
    {
        if(triggerBeingHeld && Time.time >= nextTimeToFire && twoHandGrabInteractable.bothHandsOnGun)
        {
            if(bullets > 0 && gunCocked)
            {
                primaryHand.SendHapticImpulse(0.7f, 0.05f);
                secondaryHand.SendHapticImpulse(0.7f, 0.05f);
                CheckIfEnemyShot();
                nextTimeToFire = Time.time + 1f/shotPerSecond;
                bullets--;
                ammoCountText.SetText(bullets.ToString());
                gunshot.Play();
                muzzleflash.Play();

                if(bullets <= 0)
                {
                    ammoCountText.color = Color.red;
                }
            }
        }
    }

    public void ReleaseClip(InputAction.CallbackContext context)
    {
        if (gunHasMagazine == true)
        {
            assaultRifleAnimator.Play("Release Mag");
            bullets = 0;
            ammoCountText.SetText(bullets.ToString());
            gunHasMagazine = false;
            reloadCollider.SetActive(true);
            gunCocked = false;
            ammoCountText.color = Color.red;
        }
    }

    public void DropEmptyMag()
    {
        if(emptyMagIndex == emptyMag.Length)
        {
            emptyMagIndex = 0;
        }
        emptyMag[emptyMagIndex].transform.position = magazine.transform.position;
        emptyMag[emptyMagIndex].transform.rotation = magazine.transform.rotation;
        emptyMag[emptyMagIndex].SetActive(true);
        emptyMagIndex++;
        magazine.SetActive(false);
        gunSlideXRGrabInteractable.enabled = false;
        magInserted.Play();
    }

    public void NewMagInserted()
    {
        assaultRifleAnimator.Play("Inserting Mag");
        bullets = maxBullets;
        ammoCountText.SetText(bullets.ToString());
        gunHasMagazine = true;
        gunSlideXRGrabInteractable.enabled = true;
        ammoCountText.color = Color.red;
        magInserted.Play();
    }

    public void GunCocked()
    {
        gunCocked = true;
        ammoCountText.color = Color.cyan;
    }

    public void TriggerPulled()
    {
        triggerBeingHeld = true;
    }

    public void TriggerLetGo()
    {
        triggerBeingHeld = false;
    }

    private void TurnOffLaser(InputAction.CallbackContext context)
    {
        laser.enabled = !laser.enabled;
    }

    public void ShootingWithNoBullet()
    {
        if (bullets <= 0)
        {
            dryfire.Play();
        }
    }

    public void Recoil()
    {
        grabAttachTransform.transform.Rotate(new Vector3(0.5f, 0, 0));
    }

    public void CheckIfEnemyShot()
    {
        if(raycastHit.collider != null)
        {
            if(raycastHit.transform.tag == "Enemy")
            {
                if(raycastHit.transform.name == "Head")
                {
                    raycastHit.collider.transform.root.gameObject.GetComponent<MasterChief>().headshot = true;
                }
                else
                {
                    raycastHit.collider.transform.root.gameObject.GetComponent<MasterChief>().headshot = false;
                }
                raycastHit.collider.transform.root.gameObject.GetComponent<MasterChief>().EnenmyHit();
            }

            else if(raycastHit.transform.name == "Easy Icon (AR)")
            {
                raycastHit.collider.transform.GetComponent<EasyDifficultyAR>().enabled = true;
            }

            else if(raycastHit.transform.name == "Normal Icon (AR)")
            {
                raycastHit.collider.transform.GetComponent<NormalDifficultyAR>().enabled = true;
            }

            else if(raycastHit.transform.name == "Hard Icon (AR)")
            {
                raycastHit.collider.transform.GetComponent<HardDifficultyAR>().enabled = true;
            }
        }
    }
}
