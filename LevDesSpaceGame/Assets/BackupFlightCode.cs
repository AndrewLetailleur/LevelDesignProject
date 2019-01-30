using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupFlightCode : MonoBehaviour {

    //RIGIDBODY
    private Rigidbody body;

    //pitch, yaw, roll
    public float pitchSpeed, yawSpeed, rollSpeed, veloSpeed; //testing valves
    private float ctrlKeyX, ctrlKeyY, ctrlKeyZ, veloKey; //key input

    //jnc multiplier, hack wise
    public float pitch = 1f;
    public float yaw = 1f;
    public float roll = 1f;
    public float accel = 1f;
    //


    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        ctrlKeyX = Input.GetAxis("Vertical"); 
        ctrlKeyY = Input.GetAxis("Horizontal");
        //z
        if (Input.GetKey(KeyCode.Q)) { ctrlKeyZ = 1f; }
        else if (Input.GetKey(KeyCode.E)) { ctrlKeyZ = -1f; }
        else { ctrlKeyZ = 0f; }
        
        Turn();

        if (Input.GetKey(KeyCode.V)) { veloKey = -1f; } 
        else if (Input.GetKey(KeyCode.F)) { veloKey = 1f; }
        else { veloKey = 0f; }

        Move();
        
    }

    void Move() {
        float Speed = veloKey * accel * Time.deltaTime;
        //transform.Translate(0, 0, Speed);
        body.velocity = transform.forward * Speed;
        veloSpeed = Vector3.Distance(Vector3.zero, body.velocity);
    }


    void Turn() {
        //Pitch();
        pitchSpeed = ctrlKeyX * pitch * Time.deltaTime;
        transform.Rotate(-pitchSpeed, 0, 0);
        //Yaw();
        yawSpeed = ctrlKeyZ * yaw * Time.deltaTime;
        transform.Rotate(0, -yawSpeed, 0);
        //Roll();
        rollSpeed = ctrlKeyY * roll * Time.deltaTime;
        transform.Rotate(0, 0, -rollSpeed);


    } 

	

}
