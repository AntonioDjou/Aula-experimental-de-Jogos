using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    Rigidbody2D laserRigidbody;
    Vector3 movement;
    public int bulletSpeed = 3;

    void Awake()
    {
        laserRigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2);
    }

    void Update()
    {
        movement.Set(0,35,0);
        laserRigidbody.MovePosition (transform.position + movement * Time.deltaTime * bulletSpeed);
    }
}
