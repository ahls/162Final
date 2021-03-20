using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float height;
    public float distance;
    public float yaw = 0;
    public bool isSitting = false;
    float speed = 2.0f;
    float pitch = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSitting)
        {

        }
        else
        {
            Vector3 facing = player.forward * -distance;
            facing.y = height;
            transform.position = player.position + facing;
        }
        yaw += speed * Input.GetAxis("Mouse X");
        pitch -= speed * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90, 90);
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
    }
}
