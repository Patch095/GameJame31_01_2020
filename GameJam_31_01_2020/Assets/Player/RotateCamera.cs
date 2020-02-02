using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float SpeedR = 1;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Mouse X") * SpeedR;
        float Vertical = Input.GetAxis("Mouse Y") * SpeedR;

        //transform.RotateAround(transform.position, Vector3.up, Horizontal);
        //transform.RotateAround(transform.position, Vector3.left, Vertical);

        //transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        Quaternion newRotation = Quaternion.EulerRotation(new Vector3(Vertical, Horizontal, 0));

        Quaternion.RotateTowards(transform.rotation, newRotation, 120);
    }
}
