using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject g;
    public Transform target;
    [SerializeField]
    private float speed;

    private Vector3 offset;
    private Vector3 targetPos;

    private void Start()
    {
        if (target == null) return;
        offset = transform.position - target.position;
    }

    private void Update()
    {
        if (target == null) return;
        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
}
