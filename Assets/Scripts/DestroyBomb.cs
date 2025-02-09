﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour
{
    GameObject player; 
    public float destroyRange = 5.0f;
    public GameObject Audio_Object;
    
    public AudioClip se;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ヌルポ対策
        if (this.gameObject != null)
        {
            if (this.transform.position.z < player.transform.position.z - destroyRange )
            {
                destroy();
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (PrintScore.score - 1000 >= 0)
            {
                PrintScore.score += 1000;
            }
            else
            {
                PrintScore.score = 0;
            }
            Instantiate(Audio_Object, transform.position, transform.rotation);
            destroy();
        }
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
