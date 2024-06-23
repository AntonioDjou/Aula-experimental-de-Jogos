using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject laser;
    public GameObject laserPoint;

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal"); // Stores the keys pressed
        var y = Input.GetAxisRaw("Vertical"); // Stores the keys pressed
        transform.position += new Vector3(x, y, 0) * Time.deltaTime * 6; // Moves the player acording to the

        if(Input.GetKeyDown("space"))
        {
            Instantiate(laser, laserPoint.transform.position, laserPoint.transform.rotation);
        } 
    }
}
