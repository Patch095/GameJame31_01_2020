using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject[] GO;
    GameObject Player;
    Vector3 offset, offsetPos;
    public float Speed;
    public float Fraction;
    private float lastTime;

    private int RandIndex;
    private bool objAttached;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(1, 0, 1);
        offsetPos = new Vector3(4, 0, 4);
        Player = GameObject.Find("Player");

        RandIndex = Random.Range(0, GO.Length);
    }
    

    // Update is called once per frame
    void Update()
    {


        float distance = Vector3.Distance(transform.position, GO[RandIndex].transform.position);
        Vector3 dirToObj = GO[RandIndex].transform.position - transform.position;
        float angle = Vector3.Angle(dirToObj, transform.forward);

        if (distance >= 0.5f)
        {
            //GO[RandIndex].transform.position = Vector3.Lerp(transform.position, GO[RandIndex].position, Fraction * Time.deltaTime);
            //GO[RandIndex].position = transform.position + new Vector3(0, 0.1f, 0);
            if(GO[RandIndex].GetComponent<InteractObj>().Status==1)
            {
                Debug.Log("ok");
                RandIndex = Random.Range(0, GO.Length);
                transform.gameObject.SetActive(false);
                transform.gameObject.SetActive(true);

            }
            else if (GO[RandIndex].GetComponent<InteractObj>().Status == 0)
            {
                if(GO[RandIndex].transform.position.x == transform.position.x)
                {
                    return;
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, GO[RandIndex].transform.position + offset, Fraction * Time.deltaTime);
                    transform.Rotate(Vector3.right, Space.Self);
                    transform.LookAt(GO[RandIndex].transform);
                }
                
            }
            
            
        }
        else if (objAttached == false)
        {
            RandIndex = Random.Range(0, GO.Length);
        }

    }
}
