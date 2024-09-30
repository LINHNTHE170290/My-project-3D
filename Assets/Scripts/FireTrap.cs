using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bẫy phun lửa
public class FireTrap : MonoBehaviour
{
    public ParticleSystem fireEffect; // Hiệu ứng
    public float fireDuration = 5f; // Thời gian phun
    public float offDuration = 5f; // Thời gian tắt


    private CheckpointManager checkpointManager;

    void Start()
    {
        StartCoroutine(ActivateFire());
        checkpointManager = FindObjectOfType<CheckpointManager>();
       
    }

    private IEnumerator ActivateFire()
    {
        while (true)
        {
            fireEffect.gameObject.SetActive(true);
            fireEffect.Play();
            yield return new WaitForSeconds(fireDuration);
            fireEffect.Stop();
            fireEffect.gameObject.SetActive(false);
            yield return new WaitForSeconds(offDuration);
        }
    }
    

}
