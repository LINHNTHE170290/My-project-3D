using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bay bua 
public class SwingingHammerTrap : MonoBehaviour
{
    public Transform hammer; // Object dai dien cho bua
    public float swingSpeed = 2.8f;
    public float swingAngle = 60.0f;

    private Quaternion initialRotation; // ham luu vi tri ban dau

    void Start()
    {
        initialRotation = hammer.rotation; // luu vi tri ban dau trong Start
    }

    void Update()
    {
         float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
         hammer.rotation = initialRotation * Quaternion.Euler(0, 0, angle); // duy tri vi tri ban dau

    }
    

    
}
