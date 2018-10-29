using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEnergy : MonoBehaviour {

    private GameObject wayPoint;
    private Vector3 wayPointPos;
    public float speed = 0f;
    void Start()
    {
        wayPoint = GameObject.Find("wayPoint");
    }

    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);

        if (transform.parent.parent = null)
        {
            Destroy(gameObject);
        }
    }
}
