using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private CheckpointManager m_Manager;

    void Start()
    {
        // Tìm CheckpointManager trong cảnh
        m_Manager = FindObjectOfType<CheckpointManager>();

        if (m_Manager == null)
        {
            Debug.LogError("CheckpointManager not found in the scene!");
        }
    }

    // Xử lý khi người chơi va chạm với checkpoint
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (m_Manager != null)
            {
                // Cập nhật checkpoint trong CheckpointManager
                m_Manager.UpdateCheckpoint(this);
                Debug.Log("Checkpoint reached at: " + transform.position); // Sử dụng vị trí toàn cục (global)
            }
            else
            {
                Debug.LogError("CheckpointManager is null, cannot update checkpoint!");
            }
        }
    }
}