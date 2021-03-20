using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openInteraction : MonoBehaviour
{
    public bool isCurtain = false;
    bool closed = false;
    bool inRange = false;
    public string objectName;
    [SerializeField] private Animator Anim;
    [SerializeField] private Text text;
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
        closed = !closed;
        Anim.SetTrigger("interact");
        if(isCurtain && closed)
        {
            bedInteraction.BI.curtainCurrent++;
        }
        else if(isCurtain && !closed)
        {
            bedInteraction.BI.curtainCurrent--;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
            text.text = "press 'F' to interact with the "+objectName;
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
