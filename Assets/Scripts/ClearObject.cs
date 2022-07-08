using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearObject : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();

        audioSource.pitch = 1f + Random.Range(-0.5f, 0.5f);
        audioSource.PlayOneShot(transform.parent.GetComponent<Gun>().enemyDeathSounds[Random.Range(0, transform.parent.GetComponent<Gun>().enemyDeathSounds.Length - 1)]);

        Invoke("DestroySelf", 5.0f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
