using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExceptionErrors : MonoBehaviour
{
    private CheckpointManager checkpointManager;

    private void Start()
    {
        // Tìm CheckpointManager trong cảnh
        checkpointManager = FindObjectOfType<CheckpointManager>();
        
    }

    // Xử lý khi người chơi va chạm với vật thể dẫn đến hồi sinh
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player died at position: " + transform.localPosition);

            // Gọi hàm hồi sinh từ CheckpointManager
            checkpointManager.RespawnPlayer(collision.gameObject);
        }
    }
}