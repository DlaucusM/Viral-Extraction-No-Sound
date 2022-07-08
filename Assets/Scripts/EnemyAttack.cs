using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public AudioSource attackSource;
    public AudioClip[] attackSounds;
    public bool instaDeathAttacker;
    public float attackRate;
    public float damageMulitplier = 1.0f;
    private float timer;
    public GameObject player;
    public float health;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (instaDeathAttacker == true)
            {
                other.gameObject.GetComponent<PlayerHealth>().playerDeath();
            }
            else
            {
                health = other.gameObject.GetComponent<PlayerHealth>().playerHealth;

                timer = timer + Time.deltaTime;

                if (attackSource.isPlaying == false)
                {
                    attackSource.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Length-1)]);
                }

                if (timer >= attackRate)
                {
                    
                    other.gameObject.GetComponent<PlayerHealth>().playerHealth = health - 1 * damageMulitplier;
                    timer = 0.0f;
                }
            }
            
        }
    }
}
