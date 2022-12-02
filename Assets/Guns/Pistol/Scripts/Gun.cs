using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    public GameObject shotPoint;
    public AudioSource gunshot;
    public AudioSource dryfire;
    public AudioSource cocked;
    public AudioSource magInserted;
    public AudioSource magdropped;
    public float bullets;
    private float fullmag;
    public ParticleSystem  muzzleflash;
    public GameObject bulletShellSpawn;
    public Animator gunAnimator;
    public InputActionReference primaryButtonReference;
    public InputActionReference secondaryButtonReference;
    public GameObject magazine;
    public GameObject newMagTrigger;
    public GameObject[] emptyMag;
    private bool gunCocked = true;
    private bool gunHasMagazine = true;
    public XRGrabInteractable gunSlideXRGrabInteractable;
    //public Slide slide;
    public GameObject[] bulletshell;
    private int bulletshellindex;
    private int emptyMagIndex;
    public XRDirectInteractor leftController;
    public XRDirectInteractor rightController;
    public ActionBasedController[] controllerInUse;
    public int controllerInUseIndex;
    public RaycastHit hit;
    public LineRenderer laser;

    void Start()
    {
        fullmag = bullets;
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    public void GunShot()
    {
        if (bullets > 0 && gunCocked)
        {
            bullets--;
            gunAnimator.Play("shooting");
            muzzleflash.Play();
            gunshot.Play();
            controllerInUse[1].SendHapticImpulse(1f, 0.1f);
            ShootBulletShell();
            CheckIfEnemyShot();
        }
        else if (bullets <= 0 && gunCocked)
        {
            gunAnimator.Play("no ammo");
            dryfire.Play();
            gunCocked = false;
        }
        else
        {
            dryfire.Play();
        }
    }
    public void Raycast()
    {
        laser.SetPosition(0, shotPoint.transform.position);
        if (Physics.Raycast(shotPoint.transform.position, shotPoint.transform.forward, out hit))
        {
            if (hit.collider)
            {
                laser.SetPosition(1, hit.point);
            }
        }
        else laser.SetPosition(1, shotPoint.transform.forward*5000);
    }

    public void EnablePrimaryButton()
    {
        primaryButtonReference.action.started += ReleaseClip;
        secondaryButtonReference.action.started += TurnOffLaser;
    }

    public void DisablePrimaryButton()
    {
        primaryButtonReference.action.started -= ReleaseClip;
        secondaryButtonReference.action.started -= TurnOffLaser;
    }

    private void TurnOffLaser(InputAction.CallbackContext context)
    {
        laser.enabled = !laser.enabled;
    }

    public void ReleaseClip(InputAction.CallbackContext context)
    {
        if (gunHasMagazine == true)
        {
            if(bullets > 0 && gunCocked)
            {
                gunAnimator.Play("empty clip with ammo");
            }
            else
            {
                gunAnimator.Play("empty clip no ammo");
            }
            gunCocked = false;
            bullets = 0;
            newMagTrigger.SetActive(true);
            gunHasMagazine = false;
            gunSlideXRGrabInteractable.enabled = false;
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
        magdropped.Play();
    }

    public void NewMagInserted()
    {
        magazine.SetActive(true);
        gunAnimator.Play("Reload");
        bullets = fullmag;
        gunHasMagazine = true;
        gunSlideXRGrabInteractable.enabled = true;
        magInserted.Play();
    }

    public void GunCocked()
    {
        gunAnimator.Play("cock gun");
        cocked.Play();
        gunCocked = true;
    }

    public void ShootBulletShell()
    {
        bulletshell[bulletshellindex].SetActive(true);
        bulletshell[bulletshellindex].transform.position = bulletShellSpawn.transform.position;
        bulletshell[bulletshellindex].transform.rotation = bulletShellSpawn.transform.rotation;
        bulletshell[bulletshellindex].GetComponent<Rigidbody>().AddForce(bulletShellSpawn.transform.up * 75);
        if(bulletshellindex == bulletshell.Length - 1)
        {
            bulletshellindex = 0;
        }
        else
        {
            bulletshellindex++;
        }
    }

    public void CheckWhichHandsHoldingGun()
    {
        if(leftController.hasSelection == true)
        {
            if (leftController.selectTarget.name == "pistol")
            {
                controllerInUseIndex = 0;
            }
        }

        else if(rightController.hasSelection == true)
        {
            if (rightController.selectTarget.name == "pistol")
            {
                controllerInUseIndex = 1;
            }
        }
    }

    public void CheckIfEnemyShot()
    {
        if(hit.collider != null)
        {
            if(hit.transform.tag == "Enemy")
            {
                if(hit.transform.name == "Head")
                {
                    hit.collider.transform.root.gameObject.GetComponent<MasterChief>().headshot = true;
                }
                else
                {
                    hit.collider.transform.root.gameObject.GetComponent<MasterChief>().headshot = false;
                }
                hit.collider.transform.root.gameObject.GetComponent<MasterChief>().EnenmyHit();
            }

            else if(hit.transform.name == "Easy Icon")
            {
                hit.collider.transform.GetComponent<EasyDifficulty>().enabled = true;
            }

            else if(hit.transform.name == "Normal Icon")
            {
                hit.collider.transform.GetComponent<NormalDifficulty>().enabled = true;
            }

            else if(hit.transform.name == "Hard Icon")
            {
                hit.collider.transform.GetComponent<HardDifficulty>().enabled = true;
            }
        }
    }
}
