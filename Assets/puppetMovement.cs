using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puppetMovement : MonoBehaviour
{
    public float speed = 5;
    public float stuckThreshold = 0.01f;
    public Transform player;
    public Transform[] spawnLocations = new Transform[4];
    Rigidbody RB;
    int stuckCounter;
    bool gameOver = false;
    Vector3 lastPostion;
    public AudioSource deathSound;
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
        if (!gameOver)
        {
            transform.rotation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);
            RB.MovePosition(Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime));
            gameOverCheck();
            Vector3 offsetFromLastPosition = lastPostion - transform.position;
            lastPostion = transform.position;
            if (offsetFromLastPosition.magnitude <= stuckThreshold)
            {
                stuckCounter++;
                if (stuckCounter == 50)
                {//respawn 
                    relocate();
                }
            }
            else
            {
                stuckCounter = 0;
            }

        }
    }

    void relocate()
    {
        float minDist = 999;
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
    void gameOverCheck()
    {
        if ((transform.position - player.position).magnitude <= 0.05f)
        {
            gameOver = true;
            //deathSound.Play();
            SceneManager.LoadScene(sceneName: "Game Over", LoadSceneMode.Single);

        }
    }
}
