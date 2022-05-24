using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField]
    //bool isCount = false;

    enum State
    {
        IDLE,
        MOVE,
        FIGHT,
        ENTER,
    };
    [SerializeField]
    State state;

    Transform curPos;
    Vector3 nextPos;

    private void Start()
    {
        state = State.IDLE;
        agent = GetComponent<NavMeshAgent>();
        curPos = agent.transform;
        nextPos = agent.transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIObject()) return;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                curPos = agent.transform;
                nextPos = new Vector3(hit.point.x, 0.5f, hit.point.z);
                if(hit.transform.gameObject.layer == 6)
                {
                    state = State.FIGHT;              
                }
                else if(hit.transform.gameObject.layer == 7)
                {
                    state = State.ENTER;
                }
                else
                {
                    state = State.MOVE;
                }
                agent.SetDestination(hit.point);
            }
        }  
    }

    private void LateUpdate()
    {
        if(Vector3.Distance(curPos.position, nextPos) < 0.1f)
        {
            if(state == State.FIGHT)
            {
                state = State.IDLE;
                Debug.Log("is FIGHT");
                GameManager.Instance.Ready();
            }
            else if(state == State.ENTER)
            {
                SceneManager.LoadScene(2);
                state = State.IDLE;
            }
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}