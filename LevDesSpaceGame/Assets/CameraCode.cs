using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCode : MonoBehaviour {
    //like the plane script, but without the rolling
    public float speed_Hori = 2f;
    public float speed_Vert = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

	// Update is called once per frame
	void Update () {
        yaw += speed_Hori * Input.GetAxis("Mouse X");
        pitch -= speed_Vert * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);//remember, no rolling.
    }
}
