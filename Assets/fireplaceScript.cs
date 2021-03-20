using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fireplaceScript : MonoBehaviour
{
    bool inRange = false;
    bool toggled = true;
    [SerializeField] private GameObject [] woods = new GameObject[4];
    [SerializeField] private ParticleSystem fireEffect;
    [SerializeField] private GameObject ambientLight;
    [SerializeField] private Material burningFire;
    [SerializeField] private Material extinguFire;
    [SerializeField] private Text text;
    [SerializeField] private AudioSource fireSound;
    // Start is called before the first frame update

    
    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                bedInteraction.BI.fire = toggled; // inversed.
                toggled = !toggled;
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
                fireSound.Play();
            }
            fireEffect.Play(true);
        }
        else
        {
            foreach (GameObject wood in woods)
            {
                wood.GetComponent<MeshRenderer>().material = extinguFire;
                fireSound.Stop();
            }
            fireEffect.Stop(true);
        }

        ambientLight.SetActive(toggled);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            text.text = "press 'F' to interact with the FIREPLACE";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
            text.text = "";
        }
    }
}
