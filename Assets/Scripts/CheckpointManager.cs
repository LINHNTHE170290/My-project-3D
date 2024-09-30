using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Transform currentCheckpoint;

    // Ghi lại checkpoint mới
    public void SetCurrentCheckpoint(Transform newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;
        Debug.Log("New Checkpoint Set (global): " + currentCheckpoint.position); // Sử dụng vị trí toàn cục (global)
    }

    // Cập nhật checkpoint khi người chơi va chạm
    public void UpdateCheckpoint(Checkpoint checkpoint)
    {
        SetCurrentCheckpoint(checkpoint.transform);
    }

    // Hồi sinh người chơi tại checkpoint hiện tại
    public void RespawnPlayer(GameObject player)
    {
        // Kiểm tra xem đã lưu checkpoint chưa
        if (currentCheckpoint != null)
        {
            // Tắt các thành phần vật lý trước khi di chuyển
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true; // Tắt vật lý để tránh tác động không mong muốn
                player.GetComponent<vThirdPersonInput>().cc.input = Vector3.zero;
                player.GetComponent<vThirdPersonInput>().enabled = false;
                rb.velocity = Vector3.zero;
            }

            // Đặt vị trí người chơi tại vị trí checkpoint
            player.transform.position = currentCheckpoint.position + new Vector3(0, 9, 0); // Sử dụng vị trí toàn cục (global)
            Debug.Log("Player respawned at: " + currentCheckpoint.position); // Hiển thị vị trí toàn cục (global)

            // Bật lại vật lý sau khi đã di chuyển
            if (rb != null)
            {
                rb.isKinematic = false; // Bật lại vật lý sau khi hồi sinh
                StartCoroutine(delay(player));
            }
        }
        else
        {
            // Nếu không có checkpoint, tìm GameObject với tag "Start"
            GameObject startPoint = GameObject.FindGameObjectWithTag("Start");
            if (startPoint != null)
            {
                // Tắt các thành phần vật lý trước khi di chuyển
                Rigidbody rb = player.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = true; // Tắt vật lý để tránh tác động không mong muốn
                    player.GetComponent<vThirdPersonInput>().cc.input = Vector3.zero;
                    player.GetComponent<vThirdPersonInput>().enabled = false;
                    rb.velocity = Vector3.zero;
                }

                // Đặt vị trí người chơi tại vị trí vạch xuất phát
                player.transform.position = startPoint.transform.position + new Vector3(0, 9, 0); // Sử dụng vị trí toàn cục (global)
                Debug.Log("Player respawned at Start: " + startPoint.transform.position); // Hiển thị vị trí vạch xuất phát

                // Bật lại vật lý sau khi đã di chuyển
                if (rb != null)
                {
                    rb.isKinematic = false; // Bật lại vật lý sau khi hồi sinh
                    StartCoroutine(delay(player));
                }
            }
        }
    }

    IEnumerator delay(GameObject player)
    {
        yield return new WaitForSeconds(1);
        player.GetComponent<vThirdPersonInput>().enabled = true;
        StopCoroutine(delay(player));

    }
}