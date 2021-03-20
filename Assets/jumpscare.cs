using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public GameObject puppet;
    public GameObject lighting;
    //private float time = 0f;
    private float timer1;
    private float timer2 = 0.4f;
    private bool scare = false;
    // Start is called before the first frame update
    void Awake()
    {
        puppet.SetActive(false);
        lighting.SetActive(false);
        timer1 = Random.Range(3.0f, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timer1);
        if (timer1 <= 0.0f && !scare)
        {
            scare = true;
            puppet.SetActive(true);
            lighting.SetActive(true);
        }
        else
        {
            timer1 -= Time.deltaTime;
        }
        if (scare)
        {
            if (timer2 <= 0.0f)
            {
                scare = false;
                timer1 = Random.Range(3.0f, 8.0f);
                puppet.SetActive(false);
                lighting.SetActive(false);
                timer2 = 0.4f;
            }
            else
            {
                timer2 -= Time.deltaTime;
            }
        }
    }
}
