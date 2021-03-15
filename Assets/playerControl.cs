using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    [SerializeField] Camera Cam;
    Transform CamTransform;
    public Transform groundCheck;
    CharacterController CC;
    Animator Anim;
    public float speed;
    public float groundDistance = 0.01f;
    public LayerMask groundMask;
    public float gravity = 9.8f;
    public Vector3 yVelo = Vector3.zero;
    bool isMoving;
    bool onGround;
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
        onGround = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        if (!onGround)
        {
            yVelo.y -= gravity;
        }
        else
        {
            Debug.Log("floor hit");
            yVelo = Vector3.zero;
        }

    }
    private void FixedUpdate()
    {
        
        float vertAxis = Input.GetAxis("Vertical");
        float horAxis = Input.GetAxis("Horizontal");

        CC.Move(transform.forward*vertAxis*Time.deltaTime*speed);
        CC.Move(transform.right * horAxis * Time.deltaTime*speed);
        CC.Move(yVelo*Time.deltaTime);
        isMoving = (vertAxis  != 0 || horAxis != 0);

        Anim.SetBool("moving", isMoving);
    }
}
