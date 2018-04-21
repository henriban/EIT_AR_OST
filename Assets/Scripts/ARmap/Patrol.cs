using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public GameObject Player;
    public GameObject Products;
    public GameObject EndPos;


    public Transform Dots;
    private List<Vector3> _goals;
    private int _destPoint;
    private NavMeshAgent _agent;
    private bool _done = true;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        updateGoals();
    }

    void updateGoals()
    {
        _goals = new List<Vector3> {};
        foreach (Product product in Data.ShoppingList)
        {
            var position = Products.transform.Find(product.productPosition.name).position;
            _goals.Add(position);
        }

        _goals.Add(EndPos.transform.position);
    }

    public void generatePath()
    {
        foreach (Transform dot in Dots)
        {
            Destroy(dot.gameObject);
        }

        updateGoals();
        _destPoint = 0;
        _done = false;
        _agent.destination = _goals[0];
    }


    bool GotoNextPoint()
    {
        if (_destPoint < _goals.Count)
        {
            Debug.Log(_goals[_destPoint]);
            _agent.destination = _goals[_destPoint++];

            Debug.Log("Agent dest" + _agent.destination);
            return false;
        }

        return true;
    }

    void Update()
    {
        if (_goals.Count == 0)
        {
            _done = true;
        }

        if (_done == false)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cube.transform.SetParent(Dots);
            cube.transform.localPosition = Player.transform.position;
            cube.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
            cube.transform.localRotation = Quaternion.identity;
            cube.GetComponent<Renderer>().material.color = Color.green;

            if (!_agent.pathPending && _agent.remainingDistance < _agent.stoppingDistance)
            {
                _done = GotoNextPoint();
            }
        }
    }
}