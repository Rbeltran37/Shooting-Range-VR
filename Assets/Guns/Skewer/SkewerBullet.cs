using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkewerBullet : MonoBehaviour
{
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
        if (other.tag == "Enemy")
        {
            other.transform.root.gameObject.GetComponent<MasterChief>().EnenmyHit();
        }

        else if (other.tag == "Untagged" && gameObject.name == "Skewer Bullet (shot)")
        {
            gameObject.SetActive(false);
        }
        
        else if(other.transform.name == "Easy Icon (Skewer)")
        {
            other.transform.GetComponent<EasyDifficultySkewer>().enabled = true;
        }

        else if(other.transform.name == "Normal Icon (Skewer)")
        {
            other.transform.GetComponent<NormalDifficultySkewer>().enabled = true;
        }

        else if(other.transform.name == "Hard Icon (Skewer)")
        {
            other.transform.GetComponent<HardDifficultySkewer>().enabled = true;
        }
    }
}
