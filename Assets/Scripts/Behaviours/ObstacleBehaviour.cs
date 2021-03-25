using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public Vector3 direction;
    public bool moving;
    public bool xAxis;
    public Transform particlesHolder;
    public ParticleSystem particles;

    private Rigidbody rb;
    private int side;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        particles.Stop();
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
                    particles.Stop();
                }
            }
            else
            {
                if(Mathf.Abs(transform.position.z) > 10)
                {
                    moving = false;
                    transform.position = new Vector3(transform.position.x, transform.position.y, 10 * side);
                    particles.Stop();
                }
            }
        }
    }

    public void StartMoving()
    {
        particles.Play();
        moving = true;
        side *= -1;

        if(xAxis)
        {
            particlesHolder.rotation = Quaternion.Euler(0, side == -1 ? 0  : 180, 0);
            //if(side == -1)
            //{
                //particlesHolder.rotation = Quaternion.Euler(0, 0, 0);
            //}
            //else
            //{
                //particlesHolder.rotation = Quaternion.Euler(0, 180, 0);
            //}
        }
        else
        {
            particlesHolder.rotation = Quaternion.Euler(0, side == -1 ? 270 : 90, 0);
        }
    }
}
