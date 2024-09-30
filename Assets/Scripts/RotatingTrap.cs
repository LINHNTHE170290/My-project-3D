using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bẫy xoay
public class RotatingTrap : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100f, 0); // Tốc độ xoay

    private CheckpointManager checkpointManager;

    private void Start()
    {
        checkpointManager = FindObjectOfType<CheckpointManager>();
        
    }

    void Update()
    {
         transform.Rotate(rotationSpeed * Time.deltaTime); // Xoay liên tục
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the rotating trap at position: " + transform.localPosition);
            checkpointManager.RespawnPlayer(collision.gameObject);
        }

    }
}
