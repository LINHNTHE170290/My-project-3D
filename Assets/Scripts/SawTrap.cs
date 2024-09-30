using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bẫy cưa có di chuyển
public class SawTrap : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 2.5f;
    public Vector3 moveDirection = Vector3.right;
    public float rotationSpeed = 200f;

    private Vector3 startPosition;
    private bool movingForward = true;

    private CheckpointManager checkpointManager;
    void Start()
    {
        startPosition = transform.position;

        checkpointManager = FindObjectOfType<CheckpointManager>();
        
    }

    void Update()
    {
       MoveSaw();
       RotateSaw();
        
    }

    void MoveSaw()
    {
        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + moveDirection * moveDistance, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition + moveDirection * moveDistance) < 0.1f)
                movingForward = false;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
                movingForward = true;
        }
    }

    void RotateSaw()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the saw trap at position: " + transform.localPosition);
            checkpointManager.RespawnPlayer(collision.gameObject);
        }
    }

}
