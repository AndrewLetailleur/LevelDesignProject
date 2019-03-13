using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWraparound : MonoBehaviour
{
    private GameObject player;//player REF

    public bool RotateFlag = false;     //determines if object should rotate
    public bool RandomTrig = false;



    //reference values
    public float MaxDist;               //final version should be dependant on camera aspect bounds
    
    //wraparound variables
    public float curX_Dist, curZ_Dist;  //distance by an X/Z axis
    private float selfX, selfZ;         //self = this.object, 
    private float playX, playZ;         //play = player object

    //rotate velocity variables
    public float Velo_X, Velo_Z;        //determines velocity
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
                Velo_Z = Random.Range(Min_RNG, Max_RNG);
            }
            Rigidbody rb = GetComponent<Rigidbody>();

            if (this.gameObject.GetComponent<Rigidbody>() != null)
            {
                rb.velocity = new Vector3(Velo_X, 0, Velo_Z);
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
        selfZ = this.transform.position.z;
        playZ = player.transform.position.z;
        curZ_Dist = selfZ -= playZ;
    }
    public void SetDistance() {
        //possitive transition
        if (curX_Dist >= MaxDist) {
            Vector3 newPosX = new Vector3((playX - (MaxDist)),
                                          this.transform.position.y,
                                          this.transform.position.z);
            this.transform.position = newPosX;
        }
        else if (curZ_Dist >= MaxDist) {
            Vector3 newPosZ = new Vector3(this.transform.position.x,
                                          this.transform.position.y,
                                          playZ - (MaxDist));
            this.transform.position = newPosZ;
        }

        //negative transition
        if (curX_Dist <= -MaxDist) {
            Vector3 newPosX = new Vector3((playX + (MaxDist)),
                                          this.transform.position.y,
                                          this.transform.position.z);
            this.transform.position = newPosX;
        }
        else if (curZ_Dist <= -MaxDist) {
            Vector3 newPosZ = new Vector3(this.transform.position.x,
                                          this.transform.position.y,
                                          playZ + (MaxDist));
            this.transform.position = newPosZ;
        }
    }

    // Update is called once per frame
    void Update(){
        //get's the current distance of this object in an X/Z Axis, dependant on player location
        GetDistance();
        //sets object to be far before/behind the player, if past max distance.
        SetDistance();
    }
}
