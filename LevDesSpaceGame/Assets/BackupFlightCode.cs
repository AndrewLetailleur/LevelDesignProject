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
    private float Timer, Speed;
    //


    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        Timer = Time.deltaTime * 10;

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
        
        Speed = (Timer * accel) * veloKey;
        //transform.Translate(0, 0, Speed);
        body.velocity = transform.forward * Speed;
        veloSpeed = Vector3.Distance(Vector3.zero, body.velocity);
    }


    void Turn() {
        //Pitch();
        pitchSpeed = ctrlKeyX * (pitch * Timer);
        transform.Rotate(-pitchSpeed, 0, 0);
        //Yaw();
        yawSpeed = ctrlKeyZ * (yaw * Timer);
        transform.Rotate(0, -yawSpeed, 0);
        //Roll();
        rollSpeed = ctrlKeyY * (roll * Timer);
        transform.Rotate(0, 0, -rollSpeed);


    } 

	

}
