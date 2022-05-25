using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager
{
    //GameObject random_range;
    BoxCollider boxCollider;

    //private void Awake()
    //{
    //    boxCollider = random_range.GetComponent<BoxCollider>();
    //}

    public Vector3 RandomPosition(GameObject random_range)
    {
        boxCollider = random_range.GetComponent<BoxCollider>();

        Vector3 originPosition = random_range.transform.position;
        float range_X = boxCollider.bounds.size.x;
        float range_Z = boxCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }
}