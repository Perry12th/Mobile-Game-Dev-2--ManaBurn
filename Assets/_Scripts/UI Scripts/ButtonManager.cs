using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public AudioClip buttonPress;
    public Text health;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(buttonPress, 0.8f);
        SceneManager.LoadScene("Game");
        SaveManager.instance.SetLoadOnStart(false);
    }

    public void RestartWaveButton()
    {
        SaveManager.instance.SetLoadOnStart(true);
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
    public void SaveButton()
    {
        audioSource.PlayOneShot(buttonPress, 0.8f);
        PlayerPrefs.SetString("currentHealth", health.text);
        
    }
}
