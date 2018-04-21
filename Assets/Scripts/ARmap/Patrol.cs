using System.Collections.Generic;
using System.Linq;
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
    
    private Dictionary<string, Vector3> _productPositions = new Dictionary<string, Vector3>();
    private Vector3 _endPosition;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _productPositions = Data.AllProducts
            .ConvertAll(product => product.productPosition.name)
            .ToDictionary(n => n, n => Products.transform.Find(n).position);
        _endPosition = EndPos.transform.position;
        UpdateGoals();
    }

    void UpdateGoals()
    {
        _goals = Data.ShoppingList.ConvertAll(p => _productPositions[p.productPosition.name]);
        _goals.Add(_endPosition);
    }

    public void GeneratePath()
    {
        foreach (Transform dot in Dots)
        {
            Destroy(dot.gameObject);
        }

        UpdateGoals();
        _destPoint = 0;
        _done = false;
        _agent.destination = _goals[0];
    }


    private bool GotoNextPoint()
    {
        if (_destPoint >= _goals.Count) return true;
        _agent.destination = _goals[_destPoint++];
        return false;

    }

    void Update()
    {
        if (_goals.Count == 0) _done = true;
        if (_done) return;
        
        _createDot();

        if (!_agent.pathPending && _agent.remainingDistance < _agent.stoppingDistance)
        {
            _done = GotoNextPoint();
        }
    }

    private void _createDot()
    {
        var dot = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        dot.transform.SetParent(Dots);
        dot.transform.localPosition = Player.transform.position;
        dot.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
        dot.transform.localRotation = Quaternion.identity;
        dot.GetComponent<Renderer>().material.color = Color.green;
    }
}