using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjOutOfPosition : MonoBehaviour
{
    public string ObjName;
    public bool ObjOutPos = true;

    GameObject objToRepos;
    bool objIsTake;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        objToRepos = GameObject.Find(ObjName);
    }

    // Update is called once per frame
    void Update()
    {
        float distToObj = Vector3.Distance(transform.position, objToRepos.transform.position);

        objIsTake = objToRepos.GetComponent<DropObject>().IsTake;

        if (!ObjOutPos)
        {
            anim.SetBool("ObjOutPos", false);
            GetComponent<ReposObject>().reposObject = false;
        }
        else
        {
            anim.SetBool("ObjOutPos", true);
        }

        if(distToObj <= 0.2f)
        {
            ObjOutPos = false;
        }
        else
        {
            ObjOutPos = true;
        }
    }
}
