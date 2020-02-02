using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObj : MonoBehaviour
{
    public int Status;
    private bool IsTriggered;
    Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        IsTriggered = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Ghost")
        {
            IsTriggered = true;
            Change_Status(1);
            anim.SetInteger("Status", Status);
        }

    }
    public void Change_Status(int other_value)
    {
        Status = other_value;
    }
}
