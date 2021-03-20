using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sitInteraction : MonoBehaviour
{
    Vector3 originalPosition;
    bool sitting;
    public Transform Player;
    public Transform camLoc;
    bool inRange = false;
    public string objectName;
    public cameraControl cam;
    [SerializeField] private Animator Anim;
    [SerializeField] private Text text;
    void Update()
    {
        if (sitting)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                up();
            }
        }
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                sit();
            }
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
            if (sitting) return;
            text.text = "";
        }
    }
    void sit()
    {
        sitting = true;
        originalPosition = Player.position;
        Player.position = transform.position;
        Player.GetComponent<playerControl>().isSitting = true;
        cam.isSitting = true;
        cam.transform.position = camLoc.position;
        Player.rotation = transform.rotation;
        Player.GetComponent<Animator>().SetTrigger("sit");

        text.text = "press 'F' to get up";
    }
    void up()
    {
        sitting = false;
        Player.position = originalPosition;
        Player.GetComponent<playerControl>().isSitting = false;
        cam.isSitting = false;
        Player.GetComponent<Animator>().SetTrigger("sit");
        text.text = "";

    }
}
