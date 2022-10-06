using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehavior : MonoBehaviour
{
    [SerializeField]
    private float verticalSpeed;
    [SerializeField]
    private Boundary boundary;
    
    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.position.y < boundary.min)
        {
            ResetPosition();
        }
    }

    private void Move()
    {
        transform.position -= new Vector3(0, verticalSpeed * Time.deltaTime);
    }

    private void ResetPosition()
    {
        transform.position = new Vector2(0, boundary.max);
    }
}
