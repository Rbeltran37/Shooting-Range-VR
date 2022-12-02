using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewerReloadAnimation : MonoBehaviour
{
    public float speed;
    public Skewer skewerScript;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        if(transform.localPosition.x >= 0)
        {
            transform.localPosition = new Vector3(0,0,0);
            skewerScript.bullet = gameObject;
            skewerScript.ReadyToShoot();
            enabled = false;
        }
    }
}
