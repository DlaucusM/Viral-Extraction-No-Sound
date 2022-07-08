using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    private bool dead = false;
    public AudioSource death;
    public AudioListener listener;
    public AudioClip flatline;

    private void Update()
    {
        if (dead && death.isPlaying == false)
        {
            death.Play();
        }

    
            if (Input.GetKeyDown(KeyCode.Return) && dead == true)
            {
                SceneManager.LoadScene(Application.loadedLevel);
                dead = false;
                listener.enabled = false;
                death.Stop();
            }

            if (Input.GetKeyDown(KeyCode.Escape) && dead == true)
            {
                Application.Quit();
            }
        
    }

    public void restart()
    {
        dead = true;
        listener.enabled = true;
    }

}
