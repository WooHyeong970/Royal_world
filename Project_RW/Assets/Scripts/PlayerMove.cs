using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    bool isCount = false;

    public LayerMask enemy;
    public LayerMask town;
    public LayerMask field;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = 3.0f;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemy))
            {
                agent.SetDestination(hit.point);
                isCount = true;
            }
            else if (Physics.Raycast(ray, out hit, Mathf.Infinity, town))
            {
                agent.SetDestination(hit.point);
                isCount = false;
            }
            else if(Physics.Raycast(ray, out hit, Mathf.Infinity, field))
            {
                agent.SetDestination(hit.point);
                isCount = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Test();
        }
    }
    private void LateUpdate()
    {
        if(agent.isStopped)
        {
            Debug.Log("is Stopped");
        }
    }

    public void Test()
    {
        agent.Stop();
        
    }
}