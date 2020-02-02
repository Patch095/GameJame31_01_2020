using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    public GameObject Player;
    public GameObject HandDropPoint;
    public Transform DropableItem;
    public float SpeedToTake = 2;
    public bool IsDropable = false;
    public bool IsOutPosition = true;
    public bool IsTake = false;
    public bool isRepos = false;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        HandDropPoint = GameObject.Find("HandDropPoint");
        Player = GameObject.Find("Player");
        rb = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);
        //Debug.Log(distanceToPlayer);

        if (IsOutPosition)
        {
            IsDropable = true;
            IsOutPosition = false;
        }

        if (distanceToPlayer <= 6f)
        {
            //Debug.Log("near to player");
            Player.GetComponent<PlayerPlayAnim>().canPick = true;

            if (IsDropable && !isRepos)
            {
                //Debug.Log("u can drop item");
                if (Input.GetMouseButton(0))
                {
                    IsTake = true;
                    transform.position = HandDropPoint.transform.position;
                    transform.rotation = HandDropPoint.transform.rotation;
                    transform.SetParent(HandDropPoint.transform);
                    Player.GetComponent<PlayerPlayAnim>().ItemToDrop = gameObject;
                }
            }
        }
        else
        {
            Player.GetComponent<PlayerPlayAnim>().canPick = false;
        }
        
    }
}
