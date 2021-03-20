using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public static audiomanager AM;

    public bool isOutside = true;
    [SerializeField] private AudioSource snowSound;
    private float lowestVolume = 0.08f;
    private float lowerVolume = 0.2f;
    private float regularVolume = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        AM = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void updateSnowStorm(bool doorClosed)
    {
        if(isOutside)
        {//if the character is outside
            snowSound.volume = regularVolume;
        }
        else
        {
            if(doorClosed)
            {
                snowSound.volume = lowestVolume;
            }
            else
            {
                snowSound.volume = lowerVolume;

            }
        }
    }
}
