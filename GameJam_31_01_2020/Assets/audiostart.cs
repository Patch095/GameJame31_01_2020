using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiostart : MonoBehaviour
{
    AudioSource source;
    public AudioClip clip;
    public bool isStarted;
    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            source.PlayOneShot(clip);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            isStarted = true;
        }
    }
}
