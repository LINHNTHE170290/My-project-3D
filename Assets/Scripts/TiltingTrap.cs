using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Cho qua bien dang bay
public class TiltingTrap : MonoBehaviour
{
    public Transform trapBody; // phan than bay
    public float speed = 2.0f; // toc do di chuyen len xuong
    public float moveDistance = 2.0f; // khoang cach di chuyen
    //public float tiltAmount = 15.0f; // goc nghieng toi da

    private Vector3 startPos; // vi tri ban dau cua bay
    private bool movingUp = true; // co xac dinh huong di chuyen
    

    void Start()
    {
        // luu vi tri than bay ban dau
        startPos = trapBody.position;
    }

    void Update()
    {
        // di chuyen bay len xuong
            MoveTrapUpAndDown();
        
    }

    void MoveTrapUpAndDown()
    {
        if (movingUp)
        {
            trapBody.position += Vector3.up * speed * Time.deltaTime;

            if (trapBody.position.y >= startPos.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            trapBody.position -= Vector3.up * speed * Time.deltaTime;

            if (trapBody.position.y <= startPos.y)
            {
                movingUp = true;
            }
        }

        // nghieng than bay khi di chuyen
        //TiltTrap();
    }

    //void TiltTrap()
    //{
    // tinh toan goc nghieng khi di chuyen
    //float tiltAngle = tiltAmount * (movingUp ? 1 : -1) * Mathf.Sin(Time.time * speed);

    // ap dung goc nghieng cho than bay
    //trapBody.localRotation = Quaternion.Euler(0, 0, tiltAngle);
    //}
   
}
