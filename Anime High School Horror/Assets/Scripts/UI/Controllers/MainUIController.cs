using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    [Header("Graphics Settings")]
    public Text graphicsPreset;
    [HideInInspector]
    public string[] presets;
    private void Awake()
    {

        presets = QualitySettings.names;
        
        if(!PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.SetInt("UnlockedLevel", 0);
            //PlayerPrefs.SetInt("CheckPoint", 0);
            PlayerPrefs.SetInt("Sound", 1);
            PlayerPrefs.SetInt("Music", 1);
            PlayerPrefs.SetInt("GraphicsPreset", 2) ;
        }
    }
}
