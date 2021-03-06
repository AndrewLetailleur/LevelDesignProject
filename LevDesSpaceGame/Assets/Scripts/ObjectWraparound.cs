﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWraparound : MonoBehaviour
{
    private GameObject player;//player REF

    public bool FollowFlag = false;
    public bool RotateFlag = false;     //determines if object should rotate
    public bool RandomTrig = false;

    //reference values
    public float MaxDist = 256f;        //final version should be dependant on camera aspect bounds
        //default is 256 for map level layout reasons

    //wraparound variables
    public float curX_Dist, curY_Dist;  //distance by an X/Z axis
    private float selfX, selfY;         //self = this.object, 
    private float playX, playY;         //play = player object

    //rotate velocity variables
    public float Velo_X, Velo_Y;        //determines velocity
    public float Min_RNG, Max_RNG;      //random values for velocity calculating


    // Start is called before the first frame update
    void Start() {

        player = GameObject.FindGameObjectWithTag("Player");

        ///

        if (RotateFlag) /*if yes, cue rotation code*/
        {
            if (RandomTrig)
            {
                Velo_X = Random.Range(Min_RNG, Max_RNG);
                Velo_Y = Random.Range(Min_RNG, Max_RNG);
            }
            Rigidbody rb = GetComponent<Rigidbody>();

            if (this.gameObject.GetComponent<Rigidbody>() != null)
            {
                rb.velocity = new Vector3(Velo_X, Velo_Y, 0);
            }
            else
            {
                Debug.Log("WARNING, no Rigidbody detected!");
            }
        }//end of rotate code
    }
    
    public void GetDistance()
    {
        //x
        selfX = this.transform.position.x;
        playX = player.transform.position.x;
        curX_Dist = selfX -= playX;
        //z
        selfY = this.transform.position.y;
        playY = player.transform.position.y;
        curY_Dist = selfY -= playY;
    }
    public void SetDistance() {
        //possitive transition
        if (curX_Dist >= MaxDist) {
            Vector3 newPosX = new Vector3((playX - (MaxDist)),
                                          this.transform.position.y,
                                          this.transform.position.z);
            this.transform.position = newPosX;
        }
        else if (curY_Dist >= MaxDist) {
            Vector3 newPosZ = new Vector3(this.transform.position.x,
                                          playY - (MaxDist),
                                          this.transform.position.z);
            this.transform.position = newPosZ;
        }

        //negative transition
        if (curX_Dist <= -MaxDist) {
            Vector3 newPosX = new Vector3((playX + (MaxDist)),
                                          this.transform.position.y,
                                          this.transform.position.z);
            this.transform.position = newPosX;
        }
        else if (curY_Dist <= -MaxDist) {
            Vector3 newPosZ = new Vector3(this.transform.position.x,
                                          playY + (MaxDist),
                                          this.transform.position.z);
            this.transform.position = newPosZ;
        }

        //sticks to player position, x/z axis wise
        if (FollowFlag)
        {
            Vector3 newPosF = new Vector3(playX, playY, this.transform.position.z);
            this.transform.position = newPosF;
        }

    }

    // Update is called once per frame
    void Update() {
         GetDistance();//get's the current distance of this object in an X/Z Axis, dependant on player location
         SetDistance();//sets object to be far before/behind the player, if past max distance.
        
    }
}
