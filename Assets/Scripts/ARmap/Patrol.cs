﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class Patrol : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Player;
    public GameObject imagetarget;
    public GameObject startPos;
    public GameObject endPos;
    public float countdown = 0.030f;

    private List<Transform> points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool done = false;

    void Start()
    {
        points = new List<Transform>();
        points.Add(startPos.transform);
        //int index = 1;
        foreach (Product product in Data.AllProducts)
            // foreach (Product product in Data.ShoppingList)
        {
            points.Add(product.productPosition.transform);
            //index++;
        }


        points.Add(endPos.transform);
        int count = 0;
        foreach (Transform t in points)
        // foreach (Product product in Data.ShoppingList)
        {
            count++;
            Debug.Log(t.position+"for index"+ count);
            
            //index++;
        }
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        //GotoNextPoint();
    }

 /*
    bool GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Count == 0)
        {
            return false;
        }
        if (destPoint < points.Count)
        {
            agent.destination = points[destPoint].position;
            if (agent.destination != points[destPoint].position)
            {
                agent.destination = points[destPoint].position;
            }
            Debug.Log("Agent dest"+agent.destination);
            Debug.Log("Point position" + points[destPoint].position +"at destPoint "+ destPoint);
            destPoint += 1;
            return false;
        } else
        {
            Debug.Log("We are done");
            return true;
        }

        // Set the agent to go to the currently selected destination.
        

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        //destPoint = (destPoint + 1) % points.Length;
        
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
            //Debug.Log(done);
            //Debug.Log(destPoint);
            if (done == false)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cube.transform.position = Player.transform.position;
                cube.transform.SetParent(imagetarget.gameObject.transform);
                cube.transform.rotation = Player.transform.rotation;
                Vector3 scale = new Vector3(0.01f, 0.005f, 0.01f);
                cube.transform.localScale = scale;
                cube.GetComponent<Renderer>().material.color = Color.green;
            }
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                if (GotoNextPoint())
                {
<<<<<<< HEAD
=======
                    //GotoNextPoint();
>>>>>>> f256834c794fce4fa6af9d635440590856d8420b
                    done = true;

                }
        }
    }*/
}