using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] Camera Cam;
    Transform CamTransform;
    CharacterController CC;
    public float speed;
    Animator Anim;
    bool isMoving;
    // Start is called before the first frame update
    void Start()
    {
        CC = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
        CamTransform = Cam.transform;
    }

    // Update is called once per frame
    void Update()
    {

        transform.eulerAngles = new Vector3(0, Cam.GetComponent<cameraControl>().yaw, 0);
    }
    private void FixedUpdate()
    {
        CC.Move(transform.forward*Input.GetAxis("Vertical")*Time.deltaTime*speed);
        CC.Move(transform.right * Input.GetAxis("Horizontal") * Time.deltaTime);
        isMoving = (Input.GetAxis("Vertical") + Input.GetAxis("Horizontal") != 0);

        Anim.SetBool("moving", isMoving);
    }
}
