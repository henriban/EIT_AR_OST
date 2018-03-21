using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    public NavMeshAgent agent;


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse: ");
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Make path
                Debug.Log("path");
                agent.SetDestination(hit.point);
            }
        }
	}
}
