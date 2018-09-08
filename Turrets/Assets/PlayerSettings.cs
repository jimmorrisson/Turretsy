using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    private AudioSource currentLevelMusic;
    [SerializeField]
    private Toggle musicToggle;

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 1);
            musicToggle.isOn = true;
            currentLevelMusic.enabled = true;
            PlayerPrefs.Save();
        }
        else
        {
            if(PlayerPrefs.GetInt("music") == 1)
            {
                musicToggle.isOn = true;
                currentLevelMusic.enabled = true;
            }
            else
            {
                musicToggle.isOn = false;
                currentLevelMusic.enabled = false;
            }
        }
    }

    public void OnMusicToggled()
    {
        if(musicToggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            currentLevelMusic.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            currentLevelMusic.enabled = false;
        }

        PlayerPrefs.Save();
    }
}
