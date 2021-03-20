using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //public AudioClip deathsound;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 3.0f)
        {
            SceneManager.LoadScene(sceneName: "Title Screen", LoadSceneMode.Single);
        }
        else 
        {
            timer += Time.deltaTime;
        }
    }
}
