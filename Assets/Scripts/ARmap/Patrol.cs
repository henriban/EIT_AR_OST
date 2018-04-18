using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public GameObject Player;
    public GameObject Products;
    public GameObject StartPos;
    public GameObject EndPos;

    private List<Vector3> _poeng;
    private int _destPoint;
    private NavMeshAgent _agent;
    private bool _done;

    public GameObject[] Goals;

    void Start()
    {
        _poeng = new List<Vector3> {StartPos.transform.position};
        foreach (Product product in Data.AllProducts) //.ShoppingList)
        {
            var position = Products.transform.Find(product.productPosition.name).position;
            _poeng.Add(position);
//            _poeng.Add(product.productPosition.transform);
        }
//        foreach (var goal in Goals)
//        {
//            _poeng.Add(goal.transform);
//        }

        _poeng.Add(EndPos.transform.position);

        _agent = GetComponent<NavMeshAgent>();
    }


    bool GotoNextPoint()
    {
        if (_destPoint < _poeng.Count)
        {
            Debug.Log(_poeng[_destPoint]);
            _agent.destination = _poeng[_destPoint++];

            Debug.Log("Agent dest" + _agent.destination);
            return false;
        }

        Debug.Log("We are done");
        return true;
    }


    public Transform Dots;
    void Update()
    {
        if (_poeng.Count == 0)
        {
            _done = true;
        }
        if (_done == false)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            cube.transform.SetParent(Dots);
            cube.transform.localPosition = Player.transform.position;
            cube.transform.localScale = new Vector3(0.5f, 0.25f, 0.5f);
            cube.transform.localRotation = Quaternion.identity;
            cube.GetComponent<Renderer>().material.color = Color.green;
        }

        if (!_agent.pathPending && _agent.remainingDistance < _agent.stoppingDistance)
        {
            _done = GotoNextPoint();
        }
    }
}
