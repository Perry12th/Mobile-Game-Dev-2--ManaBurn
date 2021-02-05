using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public AudioClip buttonPress;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(buttonPress, 0.8f);
        SceneManager.LoadScene("Game");
    }
    public void GameOverButton()
    {
        audioSource.PlayOneShot(buttonPress, 0.8f);

        SceneManager.LoadScene("GameOver");
    }

    public void ReturnToMenuButton()
    {
        audioSource.PlayOneShot(buttonPress, 0.8f);

        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        audioSource.PlayOneShot(buttonPress, 0.8f);

        Application.Quit();
    }
}
