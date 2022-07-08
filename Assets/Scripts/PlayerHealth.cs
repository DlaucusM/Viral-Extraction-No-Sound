using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public AudioSource playerAudio;
    public AudioClip[] heartbeat;

    public float playerHealth;
    public Text healthText;
    public float playerMaxHealth = 100;

    // THIS SCRIPT ALSO CONTAINS RESPAWN INFO FOR THE PLAYER
    //public GameObject currentCheckpoint;
    public float respawnDelay = 3.0f;
    public Respawner respawn;

    public GameObject character;
    public Text text1;
    public Text text2;
    public Text text3;
    public GameObject gameover;
    public Camera player;
    public Camera lose;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = playerMaxHealth;
        healthText.text = "Health: " + playerHealth;
        //currentCheckpoint = GameObject.FindGameObjectWithTag("StartPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + playerHealth;

            if (playerHealth <= 0)
            {
                playerHealth = 0;
                playerDeath();
            }
            if (playerAudio.isPlaying == false)
            {
                if (playerHealth <= 12)
                {
                    playerAudio.PlayOneShot(heartbeat[5]);
                }
                else if (playerHealth <= 24)
                {
                    playerAudio.PlayOneShot(heartbeat[4]);
                }
                else if (playerHealth <= 36)
                {
                    playerAudio.PlayOneShot(heartbeat[3]);
                }
                else if (playerHealth <= 48)
                {
                    playerAudio.PlayOneShot(heartbeat[2]);
                }
                else if (playerHealth <= 60)
                {
                    playerAudio.PlayOneShot(heartbeat[1]);
                }
                else if (playerHealth <= 72)
                {
                    playerAudio.PlayOneShot(heartbeat[0]);
                }
            }
        }
    }

    public void playerDeath()
    {
        // death stuff
        // Set a delay
        Invoke("RespawnFromDeath", respawnDelay);
        character.SetActive(false);
        text1.gameObject.SetActive(true);
        text2.gameObject.SetActive(true);
        text3.gameObject.SetActive(true);
        gameover.GetComponent<Gameover>().restart();
        player.enabled = false;
        lose.enabled = true;



    }

    void RespawnFromDeath()
    {
        respawn.RespawnPlayer();
        playerHealth = playerMaxHealth;
    }
}
