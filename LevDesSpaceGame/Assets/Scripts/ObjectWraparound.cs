using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWraparound : MonoBehaviour
{
    private GameObject player;//player REF
    public float MaxDist;

    //reference values
    public float curX_Dist, curZ_Dist;          //distance by an X/Z axis
    private float selfX, selfZ, playX, playZ;   //self = this.object, play = player object
    
    // Start is called before the first frame update
    void Start() { player = GameObject.FindGameObjectWithTag("Player"); }
    
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
