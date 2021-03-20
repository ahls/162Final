using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bedInteraction : MonoBehaviour
{
    static public bedInteraction BI;
    public int lightGoal, lightCurrent;
    public bool fire, door;
    public int curtainGoal, curtainCurrent;
    int endingTimer = 1000;
    bool startCountingDown = false;
    public Transform sleepSpot, camSpot, puppetTrans;
    public Transform Player;
    public cameraControl cam;
    bool completed = false;
    bool inRange = false;
    public Transform puppet;
    [SerializeField] private Text text;
    [SerializeField] private Text interactionDisplay;
    int displayCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        BI = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                conditionCheck();
                if(!completed)
                {//ending scene
                    Player.position = sleepSpot.position;
                    Player.rotation = sleepSpot.rotation;

                    cam.isSitting = true;
                    cam.transform.rotation = camSpot.rotation;
                    cam.transform.position = camSpot.position;
                    cam.enabled = false;
                    Player.GetComponent<Animator>().SetTrigger("sleep");
                    Player.GetComponent<playerControl>().isSitting = true;
                    startCountingDown = true;
                    puppet.GetComponent<puppetMovement>().enabled = false;
                    puppet.GetComponent<Rigidbody>().isKinematic = true;

                }
                else
                {//dispaly missing requirements
                    displayCounter = 100;
                    text.text = "I'm not ready to sleep yet. I stil need to :\n";
                    if(lightCurrent != lightGoal)
                    {
                        text.text += $"    -turn off lights ({lightCurrent}/{lightGoal})\n";
                        displayCounter += 25;
                    }
                    if(curtainCurrent != curtainGoal)
                    {
                        text.text += $"    -close the curtains ({curtainCurrent}/{curtainGoal})\n";
                        displayCounter += 25;
                    }
                    if(!fire)
                    {
                        text.text += "    -put out the fire\n";
                        displayCounter += 25;
                    }
                    if(!door)
                    {
                        text.text += "    -close the door";
                        displayCounter += 25;
                    }
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if(displayCounter > 0)
        {
            displayCounter--;
        }
        else if(displayCounter == 0)
        {
            text.text = "";
        }
        if(startCountingDown)
        {
            if(endingTimer > 0)
            {
                endingTimer--;
            }
            if(endingTimer == 500)
            {
                GetComponent<AudioSource>().Play();
                puppet.position = puppetTrans.position;
                puppet.rotation = puppetTrans.rotation;
                
            }
            else if(endingTimer < 150 )
            {
                puppet.position += Vector3.up * 0.002f;
            }
            if(endingTimer == 0)
            {
                SceneManager.LoadScene("victory Scene");
            }
        }
    }
    void conditionCheck()
    {
        if(fire  && door)
        {
            if(lightCurrent == lightGoal && curtainCurrent == curtainGoal)
            {
                completed = true;
            }
            else
            {
                completed = false;
            }
        }
        else
        {
            completed = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Player")
        {
            inRange = true;
            interactionDisplay.text = "press F to sleep";
        }

    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            inRange = false;
            interactionDisplay.text = "";
        }
    }

}
