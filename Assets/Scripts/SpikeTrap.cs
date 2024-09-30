using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bẫy gai (ẩn)
public class SpikeTrap : MonoBehaviour
{
    public Transform spikes;
    public float speed = 1.0f; // Tốc độ di chuyển của gai
    public float raiseHeight = 1.0f; // Độ cao gai nhô lên

    private Vector3 initialPosition; // Vị trí ban đầu
    private Vector3 raisedPosition;  // Vị trí nhô lên
    private bool isPlayerOnTrap = false;

    private CheckpointManager checkpointManager;
    void Start()
    {
        initialPosition = spikes.position; // Lưu vị trí ban đầu
        raisedPosition = new Vector3(spikes.position.x, initialPosition.y + raiseHeight, spikes.position.z);
        //checkpointManager = FindObjectOfType<CheckpointManager>();
        
    }

    void Update()
    {
            if (isPlayerOnTrap)
            {
                spikes.position = Vector3.Lerp(spikes.position, raisedPosition, speed * Time.deltaTime);
            }
            else
            {
                spikes.position = Vector3.Lerp(spikes.position, initialPosition, speed * Time.deltaTime);
            }
        
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTrap = true;
            Debug.Log("Player hit the spike trap at position: " + transform.localPosition);
            checkpointManager.RespawnPlayer(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnTrap = false;
            Debug.Log("Player left the trap!");
        }
    }
}
