using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puppetMovement : MonoBehaviour
{
    public float speed = 5;
    public float stuckThreshold = 0.01f;
    public Transform player;
    public Transform[] spawnLocations = new Transform[4];
    Rigidbody RB;
    int stuckCounter;
    Vector3 lastPostion;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.LookRotation(player.position,transform.up);
        RB.MovePosition(Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
        Vector3 offsetFromLastPosition = lastPostion - transform.position;
        lastPostion = transform.position;
        if(offsetFromLastPosition.magnitude <= stuckThreshold)
        {
            stuckCounter++;
            if(stuckCounter == 50)
            {//respawn 
                relocate();
            }
        }
        else
        {
            stuckCounter = 0;
        }
    }

    void relocate()
    {
        float minDist=999;
        int bestIndex = 0;
        for (int i = 0; i < 4; i++)
        {
            float tempDist = (player.position - spawnLocations[i].position).magnitude;
            if (tempDist < minDist)
            {
                bestIndex = i;
            minDist = tempDist;
            }
        }

        transform.position = spawnLocations[bestIndex].position;
        
    }
}
