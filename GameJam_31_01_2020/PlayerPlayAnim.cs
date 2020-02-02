using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerPlayAnim : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Camera camera3;
    public Transform cameraPerspective;
    public float SpeedChangePerspective = 1;
    public GameObject ItemToDrop;
    public Transform RightPosForRepos;
    public float speed = 1;

    public bool canPick = false;
    public bool picked = false;
    public bool isRepositioning = false;

    Animator anim;
    AnimatorStateInfo animInfo;
    GameObject FirstPersonCtrl;

    bool isPicking = false;

    Quaternion defaultPlayerRot;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        cameraPerspective = GameObject.Find("Perspective").transform;
        FirstPersonCtrl = GameObject.Find("FPSController");
        defaultPlayerRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float wx = Input.GetAxis("Horizontal") * speed;
        float wy = Input.GetAxis("Vertical") * speed;
        float rx = Input.GetAxis("Mouse X");

        anim.SetFloat("X", wx);
        anim.SetFloat("Y", wy);

        if(rx >= 0.5f && anim.GetFloat("X") <= 0 && anim.GetFloat("Y") <= 0)
        {
            anim.SetBool("TurnR", true);
        }
        else
        {
            anim.SetBool("TurnR", false);
        }

        if (rx <= -0.5f && anim.GetFloat("X") <= 0 && anim.GetFloat("Y") <= 0)
        {
            anim.SetBool("TurnL", true);
        }
        else
        {
            anim.SetBool("TurnL", false);
        }

        if (Input.GetMouseButton(0) && !picked && canPick)
        {
            isPicking = true;
            anim.SetInteger("GetObj", 1);
        }

        if (isPicking)
        {
            //FirstPersonCtrl.transform.LookAt(ItemToDrop.transform);
            anim.SetInteger("GetObj", 1);
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
            camera2.transform.position = Vector3.Lerp(camera2.transform.position, cameraPerspective.position, SpeedChangePerspective * Time.deltaTime);
            camera2.transform.rotation = Quaternion.Slerp(camera2.transform.rotation, cameraPerspective.rotation, SpeedChangePerspective * Time.deltaTime);
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Picking Up"))
        {
            FirstPersonCtrl.GetComponent<FirstPersonController>().enabled = false;
            anim.SetInteger("GetObj", 0);
            isPicking = false;
            picked = true;
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Movement") && !isPicking)
        {
            camera2.transform.position = Vector3.Lerp(camera2.transform.position, camera1.transform.position, SpeedChangePerspective * Time.deltaTime);
            camera2.transform.rotation = Quaternion.Slerp(camera2.transform.rotation, camera1.transform.rotation, SpeedChangePerspective * Time.deltaTime);
            camera1.gameObject.SetActive(true);
            camera2.gameObject.SetActive(false);
            camera3.gameObject.SetActive(false);

            FirstPersonCtrl.GetComponent<FirstPersonController>().enabled = true;
        }

        if (isRepositioning && picked)
        {
            anim.SetInteger("ThrowInt", 1);
            
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Throw"))
        {
            FirstPersonCtrl.GetComponent<FirstPersonController>().enabled = false;
            anim.SetInteger("ThrowInt", 0);
        }
    }
}
