using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    Animator anim;
    
    private float accumulator;

    public float Status { get { return status; } }
    private float status;

    private bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        status = 1;
        accumulator = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        status += accumulator;
        status = Mathf.Clamp01(status);
        anim.SetFloat("status", status);
    }


    public void Trigger_anim(int value)
    {
        accumulator = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ghost")
        {
            isTriggered = true;
            accumulator = 0.1f;
            //anim.SetFloat("Status", status);
        }
        if (other.name == "Player")
        {
            isTriggered = true;
            accumulator = -0.1f;
            //anim.SetFloat("Status", status);
        }

    }

}
