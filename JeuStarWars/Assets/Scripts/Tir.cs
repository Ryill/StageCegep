using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    private float vitesse = 6f;
    public GameObject joueur;
    private Vector3 dir;
    Vector3 posDebut;
    private bool fromPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        posDebut = transform.position;
        dir = joueur.transform.position;
//        dir = new Vector3(dir.x, dir.y - 1, dir.z);
        transform.LookAt(dir);
        //transform.LookAt(new Vector3(-90,dir.y,dir.z));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(fromPlayer == false)
        {
            if(collision.gameObject.name == "sabre")
            {
                fromPlayer = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fromPlayer == false)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, dir, vitesse * Time.deltaTime);
            transform.position = newPos;
        }
        else
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, posDebut, vitesse * Time.deltaTime);
            transform.position = newPos;
        }
        
        
        //transform.position += pos * dir * vitesse * Time.deltaTime;

    }
}
