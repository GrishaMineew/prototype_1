﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PathAgent : MonoBehaviour
{
    public float runSpeed = 1F;
    //public GameObject idleRacoon;
    //public GameObject runRacoon;
    public string sceneName;

    private PathCreator pathCreator;
    private bool fail;

    void Start()
    {
        if (pathCreator == null)
        {
            pathCreator = FindObjectOfType<PathCreator>();
        }

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        bool warped = agent.Warp(transform.position);
        Debug.Log("WARPED " + warped + " " + transform.position);
    }

    void Update()
    {
        if(fail) {
            LevelLoader.Replay();
        }

        if (pathCreator.IsEmpty())
        {
            //Debug.Log("EMPTY PATH");
            return;
        }
        Vector3 next = pathCreator.GetNext();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        //Debug.Log("DESTINATION " + next);
        agent.SetDestination(next);
        
        
        float magnitude = Vector3.Magnitude(next - transform.position);
        // Debug.Log("DESTINATION " + magnitude);
        if(magnitude < 1.5) {
            pathCreator.RemoveNext();
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Dog>() != null) {
            Debug.Log("FAIL");
            fail = true;
        }
    }
}
