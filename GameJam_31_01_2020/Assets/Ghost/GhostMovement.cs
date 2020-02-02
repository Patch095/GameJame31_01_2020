using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    //public int VelX;
    //public int VelZ;
    public float MaxVel;

    GameObject WallX, WallZ;

    Transform player;
    Transform objInteractive;
    
    Vector3 offset;
    
    float fraction;
    float xMin;
    float zMin;
    float xMax;
    float zMax;

    private string objName;

    private float x;
    private float z;
    private float time;
    private float angle;

    private bool isThrowed;

    // Start is called before the first frame update
    void Start()
    {
        WallX = GameObject.Find("MaxX");
        WallZ = GameObject.Find("MaxZ");

        xMin = -Vector3.Distance(transform.position, WallX.transform.position) * 0.5f;
        zMin = -Vector3.Distance(transform.position, WallZ.transform.position) * 0.5f;

        x = Random.Range(-MaxVel, MaxVel);
        z = Random.Range(-MaxVel, MaxVel);

        angle = Mathf.Atan2(x, z) * (180 / Mathf.PI) + 90;

        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }

    private void OnTriggerEnter(Collider other)
    {        
        Vector3 Offset = new Vector3(0, 1, 0);
        if (other.name == "Player")
            return;
        else
        {
            Vector3 dist = other.transform.position - transform.position;
            transform.position = Vector3.Lerp(transform.position, dist, fraction * Time.deltaTime);
            objInteractive = other.transform;
            objName = other.name;
            ThrowObj();
        }

    }
    // Update is called once per frame
    void Update()
    {
        Move();
        ThrowObj();
    }

    private void Move()
    {
        xMax = Vector3.Distance(transform.position, WallX.transform.position + offset);
        zMax = Vector3.Distance(transform.position, WallZ.transform.position + offset);

        time += Time.deltaTime;

        if (transform.localPosition.x > xMax)
        {
            x = Random.Range(-MaxVel, 0.0f);
            angle = Mathf.Atan2(x, z) * (180 / Mathf.PI) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            transform.LookAt(transform.forward);
            time = 0.0f;
        }

        if (transform.localPosition.x < xMin)
        {
            x = Random.Range(0.0f, MaxVel);
            angle = Mathf.Atan2(x, z) * (180 / Mathf.PI) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            transform.LookAt(transform.forward);
            time = 0.0f;
        }

        if (transform.localPosition.z > zMax)
        {
            z = Random.Range(-MaxVel, 0.0f);
            angle = Mathf.Atan2(x, z) * (180 / Mathf.PI) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            transform.LookAt(transform.forward);
            time = 0.0f;
        }

        if (transform.localPosition.z < zMin)
        {
            z = Random.Range(0.0f, MaxVel);
            angle = Mathf.Atan2(x, z) * (180 / Mathf.PI) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            transform.LookAt(transform.forward);
            time = 0.0f;
        }

        if (time > 1.0f)
        {
            x = Random.Range(-MaxVel, MaxVel);
            z = Random.Range(-MaxVel, MaxVel);
            angle = Mathf.Atan2(x, z) * (180 / Mathf.PI) - 90;
            transform.localRotation = Quaternion.Euler(0, angle, 0);
            time = 0.0f;
        }
        transform.localPosition += new Vector3(x, 0, z);
    }

    private void ThrowObj()
    {
        player = transform.Find("Player");
        //Vector3 distToPlayer = Player.position - transform.position;
 
        isThrowed = true;
        //transform.position = Vector3.Lerp(transform.position, distToPlayer, Fraction * Time.deltaTime);
    }
}

