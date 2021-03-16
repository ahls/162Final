using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireplaceScript : MonoBehaviour
{
    bool inRange = false;
    bool toggled = true;
    [SerializeField] private GameObject [] woods = new GameObject[4];
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private GameObject ambientLight;
    [SerializeField] private Material burningFire;
    [SerializeField] private Material extinguFire;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            toggled = !toggled;
            if (Input.GetKeyDown(KeyCode.F))
            {
                interact();
            }
        }
    }

    void interact()
    {
        if (toggled)
        {
            foreach (GameObject wood in woods)
            {
                wood.GetComponent<MeshRenderer>().material = burningFire;
                
            }
            fireEffect.Play(true);
        }
        else
        {
            foreach (GameObject wood in woods)
            {
                wood.GetComponent<MeshRenderer>().material = extinguFire;

            }
            fireEffect.Stop(true);
        }

        ambientLight.SetActive(toggled);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            inRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            inRange = false;
    }
}
