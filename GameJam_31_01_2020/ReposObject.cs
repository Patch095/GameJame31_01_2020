using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReposObject : MonoBehaviour
{
    public string NameObj;
    public float SpeedToRepos = 1;
    public Transform objToRepos;
    public Camera ReposCam;
    public Camera CameraFPS;

    GameObject player;

    public bool reposObject = false;

    bool objOnPos;
    bool isTriggeredFromGhost = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        objToRepos = GameObject.Find(NameObj).transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distToObj = Vector3.Distance(transform.position, objToRepos.position);
        Debug.Log("dist to obj " + distToObj);

        if(distToObj <= 7f && Input.GetMouseButton(0) && player.GetComponent<PlayerPlayAnim>().picked)
        {
            reposObject = true;
        }

        if(reposObject)
        {
            //player.GetComponent<PlayerPlayAnim>().RightPosForRepos = transform.GetChild(0).transform;
            //player.transform.LookAt(transform.position - new Vector3(0, transform.position.y, 0));
            objToRepos.SetParent(null);
            objToRepos.position = Vector3.Lerp(objToRepos.position, transform.position, SpeedToRepos * Time.deltaTime);
            objToRepos.rotation = Quaternion.Slerp(objToRepos.rotation, transform.rotation, SpeedToRepos * Time.deltaTime);
            objToRepos.GetComponent<DropObject>().isRepos = true;
            player.GetComponent<PlayerPlayAnim>().isRepositioning = true;
            CameraFPS.gameObject.SetActive(false);
            ReposCam.gameObject.SetActive(true);

        }
        else
        {
            objToRepos.GetComponent<DropObject>().isRepos = false;
            player.GetComponent<PlayerPlayAnim>().isRepositioning = false;
        }

        if(!GetComponent<ObjOutOfPosition>().ObjOutPos)
        {
            player.GetComponent<PlayerPlayAnim>().picked = false;
        }
    }
}
