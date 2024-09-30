using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    void Start()
    {
        // Tìm đối tượng CheckpointManager trong scene
        checkpointManager = FindObjectOfType<CheckpointManager>();
        
    }

    // Xử lý va chạm với người chơi
    private void OnCollisionEnter(Collision collision)
    {
        // Kiểm tra nếu đối tượng va chạm là người chơi
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player attacked by fire at position: " + transform.localPosition);

            // Hồi sinh người chơi thông qua CheckpointManager
            
            checkpointManager.RespawnPlayer(collision.gameObject);
            
        }
    }
}
