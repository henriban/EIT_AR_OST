using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Player;
    public GameObject imagetarget;


    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private bool done = false;

    void Start()
    {


        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    bool GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
        {
            return false;
        }
        if (destPoint < points.Length)
        {
            agent.destination = points[destPoint].position;
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
        Debug.Log(done);
        Debug.Log(destPoint);
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
                GotoNextPoint();
                done = true;

            }
    }
}