using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerScript : MonoBehaviour
{
    /*public GameObject laser;
    public GameObject laserPoint;
    */

    //-----Object Pooling-----//
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float muzzleVelocity = 700f;
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private float cooldownWindow = 0.1f;
    
    private IObjectPool<Projectile> objectPool;

    /*Delete if working*/ [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    private float nextTimeToShoot;
    //-----Object Pooling-----//

    private void Awake()
    {
        objectPool = new ObjectPool<Projectile>(CreateProjectile, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
    }

    void FixedUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal"); // Stores the keys pressed
        var y = Input.GetAxisRaw("Vertical"); // Stores the keys pressed
        transform.position += new Vector3(x, y, 0) * Time.deltaTime * 6; // Moves the player acording to the

        /*if(Input.GetKeyDown("space"))
        {
            Instantiate(laser, laserPoint.transform.position, laserPoint.transform.rotation);
        }*/

        // Shoot if we have exceeded delay
        if (Input.GetButtonDown("Fire1") && Time.time > nextTimeToShoot && objectPool != null)
        {
            Projectile bulletObject = objectPool.Get(); // Get a pooled object.

            if(bulletObject == null) return;

            // Align
            bulletObject.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);
            // move forward
            bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * muzzleVelocity, ForceMode.Acceleration);
            // Turn off
            bulletObject.Deactivate();
            // cooldown
            nextTimeToShoot = Time.time + cooldownWindow;

        }
    }

    private Projectile CreateProjectile()
    {
        Projectile projectileInstance = Instantiate(projectilePrefab);
        projectilePrefab.ObjectPool = objectPool;
        return projectileInstance;
    }

    private void OnGetFromPool(Projectile pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Projectile pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(Projectile pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }


}
