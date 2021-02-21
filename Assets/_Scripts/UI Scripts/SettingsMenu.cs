using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    AudioMixer audioMixer;

    public void SetSoundEffectsVolume (float volume)
    {
        audioMixer.SetFloat("SEVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MVolume", volume);
    }
}
