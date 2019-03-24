using System.Collections;
using System.Collections.Generic;
using UnityEngine;//using System; (Note to self; don't use System and UnityEngine at the same time, function wise.)
using UnityEngine.Rendering;
//using UnityEngine.PostProcessing; //the module addition, so I don't have namespace hack hassle. :(


public class CameraCode : MonoBehaviour {
    // public PostProcessingProfile Camera_Profile;


    public bool mouseMove = false;
    //like the plane script, but without the rolling
    public float speed_Hori = 2f;
    public float speed_Vert = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

    //Insert Grain FX Manip
    //Intensity = 0.5 / 1 (Max)
    //Luminance Contril = 0 / 1 (Max)
    //Size = 0.3 - 1.5 (Inc.dec dep on Random?)

    /// <summary>
    /// Goal? Get Camera HUD to work on health.
    /// Luminance Contril = 1 (Max HP) / 0 (Zero HP)
    /// </summary>

    private float MaxHP = 5;
    public float HP;

    

    private void Start()
    {
        //Camera_Profile = this.gameObject.GetComponent<PostProcessingProfile>();

        HP = MaxHP;

    }


    public float camInt = 1;
    private bool camAdd = false;
    // Update is called once per frame
    void Update () {

        CameraGrainEffect();

        if (mouseMove)
        {
            yaw += speed_Hori * Input.GetAxis("Mouse X");
            pitch -= speed_Vert * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);//remember, no rolling.
        }
    }

//    private float newSize = Random.Range(0.3f, 1.0f);


    
    void CameraGrainEffect() {

        if (!camAdd) {
            camInt -= (Time.deltaTime + Random.Range(0.0f, 0.5f));
            if (camInt < 0)
                camInt = 0;
            //endif
        }
        else {
            camInt += (Time.deltaTime + Random.Range(0.0f, 0.5f));
            if (camInt > 1)
                camInt = 1;
            //endif
        }
        //endif

        if (camInt > 0.9F)
        {
            camAdd = false;
        } else if (camInt < 0.4F)
        {
            camAdd = true;
        }
        
        //effectsy



    }




}
