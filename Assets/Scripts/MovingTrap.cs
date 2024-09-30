using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bẫy ép có gai
public class MovingTrap : MonoBehaviour
{
    public float moveSpeed = 2f; // Tốc độ di chuyển của bẫy
    public float moveDistance = 3f; // Khoảng cách di chuyển 
    public Vector3 moveDirection = Vector3.right; // Hướng di chuyển

    private Vector3 startPosition;
    private bool movingForward = true;

    private CheckpointManager checkpointManager;
    void Start()
    {
        startPosition = transform.position; // Lưu vị trí ban đầu
        checkpointManager = FindObjectOfType<CheckpointManager>();
        
    }

    void Update()
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player hit the moving saw trap at position: " + transform.localPosition);
            checkpointManager.RespawnPlayer(collision.gameObject);
        }
    }

}
