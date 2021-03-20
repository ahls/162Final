using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchInteraction : MonoBehaviour
{

    bool inRange = false;
    public string objectName;
    bool lightOn = true;
    [SerializeField] private Animator Anim;
    [SerializeField] private Text text;
    public MeshRenderer targetLight;
    public GameObject lightSource;
    public Material OnMaterial;
    public Material OffMaterial;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                interact();
            }
        }
    }

    void interact()
    {
        lightOn = !lightOn;
        Anim.SetBool("state", lightOn);
        lightSource.SetActive(lightOn);
        if(lightOn)
        {
            targetLight.material = OnMaterial;
        }
        else
        {
            targetLight.material = OffMaterial;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            text.text = "press 'F' to interact with the " + objectName;
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