using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public Vector3 direction;
    public bool moving;
    public bool xAxis;

    private Rigidbody rb;
    private int side;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 dir, bool xAxis)
    {
        direction = dir;
        moving = false;
        side = 1;
        this.xAxis = xAxis;
    }

    public void Update()
    {
        if(moving)
        {
            rb.MovePosition(transform.position + direction * App.obstacleManager.speed* side * Time.deltaTime);

            if(xAxis)
            {
                if(Mathf.Abs(transform.position.x) > 10)
                {
                    moving = false;
                    transform.position = new Vector3(10 * side, transform.position.y, transform.position.z);
                }
            }
            else
            {
                if(Mathf.Abs(transform.position.z) > 10)
                {
                    moving = false;
                    transform.position = new Vector3(transform.position.x, transform.position.y, 10 * side);
                }
            }
        }
    }

    public void StartMoving()
    {
        moving = true;
        side *= -1;
    }
}
