using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupFlightCode : MonoBehaviour {

    public PlayerConditionCode playerCON;

    //RIGIDBODY
    public Rigidbody body;

    //pitch, yaw, roll
    public float pitchSpeed, yawSpeed, rollSpeed, veloSpeed; //testing valves
    private float ctrlKeyX, ctrlKeyY, ctrlKeyZ;
    public float veloKey; //key input

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
        playerCON = GameObject.FindGameObjectWithTag("Health").GetComponent<PlayerConditionCode>();
        body = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
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
        Move();

        if (veloKey == 0 && pitchSpeed == 0 && rollSpeed == 0 && yawSpeed == 0)
        { Momentum(); }
    }

    void Move() {

        if (Input.GetKey(KeyCode.V)) { veloKey = -1f;
        }
        else if (
            Input.GetKey(KeyCode.F)) { veloKey = 1f;
        }
        else {
            veloKey = 0f;
        }

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

    void Momentum() {
        //zeroes momentum, to ensure no bugs hassle wise?
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hazard") {
            playerCON.HP_Change(1);
            //Vector3 moveDirection = other.transform.position - this.gameObject.transform.position;
            //other.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * 500f);

        }//change according to damage
    }

    /*void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Hazard")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("Do something else here");
            playerCON.HP_Change(1);//change according to damage

        }
    }*/


}
