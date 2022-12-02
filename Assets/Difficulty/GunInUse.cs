using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInUse : MonoBehaviour
{
    public GameObject assaultRifleGameObjects;
    public bool assaultRifleGameInProgress;
    public bool assaultRifleInHand;
    public GameObject pistolGameObjects;
    public bool pistolGameInProgress;
    public bool pistolInHand;
    public GameObject skewerGameObjects;
    public bool skewerGameInProgress;
    public bool skewerInHand;
    public Transform hideGunsPosition;
    public GameObject assaultRifle;
    public Transform startingAssaultRiflePosition;
    public GameObject pistol;
    public Transform startingPistolPosition;
    public GameObject skewer;
    public Transform startingSkewerPosition;

    public void AssaultRiflePickedUp()
    {
        assaultRifleGameObjects.SetActive(true);
        assaultRifleInHand = true;
        pistol.transform.position = hideGunsPosition.position;
        skewer.transform.position = hideGunsPosition.position;
    }

    public void AssaultRifleDropped()
    {
        assaultRifleInHand = false;
        if (!assaultRifleGameInProgress)
        {
            assaultRifleGameObjects.SetActive(false);
            pistol.transform.position = startingPistolPosition.position;
            skewer.transform.position = startingSkewerPosition.position;
        }
    }

    public void AssaultRifleGameEnded()
    {
        if (!assaultRifleInHand)
        {
            assaultRifleGameObjects.SetActive(false);
            pistol.transform.position = startingPistolPosition.position;
            skewer.transform.position = startingSkewerPosition.position;
        }
    }

    public void PistolPickedUp()
    {
        pistolGameObjects.SetActive(true);
        pistolInHand = true;
        assaultRifle.transform.position = hideGunsPosition.position;
        skewer.transform.position = hideGunsPosition.position;
    }

    public void PistolDropped()
    {
        pistolInHand = false;
        if (!pistolGameInProgress)
        {
            pistolGameObjects.SetActive(false);
            assaultRifle.transform.position = startingAssaultRiflePosition.position;
            skewer.transform.position = startingSkewerPosition.position;
        }
    }

    public void PistolGameEnded()
    {
        if (!pistolInHand)
        {
            pistolGameObjects.SetActive(false);
            assaultRifle.transform.position = startingAssaultRiflePosition.position;
            skewer.transform.position = startingSkewerPosition.position;
        }
    }

    public void SkewerPickedUp()
    {
        skewerGameObjects.SetActive(true);
        skewerInHand = true;
        assaultRifle.transform.position = hideGunsPosition.position;
        pistol.transform.position = hideGunsPosition.position;
    }

    public void SkewerDropped()
    {
        skewerInHand = false;
        if (!skewerGameInProgress)
        {
            skewerGameObjects.SetActive(false);
            assaultRifle.transform.position = startingAssaultRiflePosition.position;
            pistol.transform.position = startingPistolPosition.position;
        }
    }

    public void SkewerGameEnded()
    {
        if (!skewerInHand)
        {
            skewerGameObjects.SetActive(false);
            assaultRifle.transform.position = startingAssaultRiflePosition.position;
            pistol.transform.position = startingPistolPosition.position;
        }
    }
}
