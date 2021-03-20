using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public GameObject center;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneName: "scene in progress", LoadSceneMode.Single);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(center.transform.position, Vector3.up, 5 * Time.deltaTime);
    }
}
