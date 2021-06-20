using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LentaRun : MonoBehaviour
{
    private float speedInit = 0.6f;
    // private float speedIncrease = 0.0f;
    private float speedIncrease = 0.3f;
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        speed = speedInit;
    }

    // Update is called once per frame
    void Update()
    {
        if ((int) transform.position.x % 5 == 0) {
            float newSpeed = speedInit + speedIncrease * ((int) Math.Abs(transform.position.x) / 5);
            if (newSpeed > speed) speed = newSpeed;
        }
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        // Debug.Log(speed);
        // Debug.Log("pos: x=" + transform.position.x + "; y=" + transform.position.y + "; z=" + transform.position.z);
    }
}
