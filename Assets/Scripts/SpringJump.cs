using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringJump : MonoBehaviour
{
    public float jumpForce = 1700f; // luc nhay khi cham vao lo xo

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Player da va cham voi lo xo!");
        if (collision.gameObject.CompareTag("Player"))
        {
            // ap dung luc nhay khi nguoi choi cham vao
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                //Debug.Log("Đang ap dung luc nhay");
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
