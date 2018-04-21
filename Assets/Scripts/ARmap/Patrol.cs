﻿using System.Collections.Generic;
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

    void Start()
    {
        _poeng = new List<Vector3> {StartPos.transform.position};
        foreach (Product product in Data.ShoppingList)
        {
            var position = Products.transform.Find(product.productPosition.name).position;
            _poeng.Add(position);
        }

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
            cube.transform.localScale = new Vector3(0.5f, 0.1f, 0.5f);
            cube.transform.localRotation = Quaternion.identity;
            cube.GetComponent<Renderer>().material.color = Color.green;
        }

        if (!_agent.pathPending && _agent.remainingDistance < _agent.stoppingDistance)
        {
            _done = GotoNextPoint();
        }
    }
}
