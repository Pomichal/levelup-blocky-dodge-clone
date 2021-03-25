using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{

    public float rotateSpeed;

    public float minY;
    public float maxY;

    public float dir;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        transform.position += Vector3.up * dir * Time.deltaTime;

        if(transform.position.y > maxY || transform.position.y < minY)
        {
            dir *= -1;
        }
    }
}
