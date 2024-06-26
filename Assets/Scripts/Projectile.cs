using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    /*Rigidbody2D laserRigidbody;
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

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        objectPool.Release(this);
    }
    */

    [SerializeField] private float timeoutDelay = 3f;
    private IObjectPool<Projectile> objectPool;
    public IObjectPool<Projectile> ObjectPool { set => objectPool = value; }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine(timeoutDelay));
    }

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        // reset the moving Rigidbody
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity = new Vector3(0f, 0f, 0f);
        rbody.angularVelocity = new Vector3(0f, 0f, 0f);
        // release it back to the pool
        objectPool.Release(this);
    }
}
