using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ControlFreak2;

public class GameplayUIController : MonoBehaviour
{
    [Header("Graphics Settings")]
    public Text graphicsPreset;
    [HideInInspector]
    public string[] presets;
    public GameObject pausePanel;
    public GameObject levelCompletePanel;
    public GameObject levelFailPanel;
    public GameObject ControlRig;

    #region UnityMethods

    private void Awake()
    {
        presets = QualitySettings.names;
    }
    private void Start()
    {
        SetGraphicsPreset(PlayerPrefs.GetInt("GraphicsPreset"));
        GetGraphicsPreset();
    }

    //private void Update()
    //{
    //    if(CF2Input.GetButtonDown("Pause"))
    //    {
    //        ControlRig.SetActive(false);
    //        PausePanel.SetActive(true);
    //        Time.timeScale = 0;
    //    }
    //}
    #endregion

    #region Settings
    #region Graphics Settings
    void SetGraphicsPreset(int i)
    {
        PlayerPrefs.SetInt("GraphicsPreset", i);
    }
    void GetGraphicsPreset()
    {
        graphicsPreset.text = presets[QualitySettings.GetQualityLevel()];
    }

    public void NextPreset()
    {
        QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel() + 1);
        graphicsPreset.text = presets[QualitySettings.GetQualityLevel()];
        SetGraphicsPreset(QualitySettings.GetQualityLevel());
    }

    public void PreviousPreset()
    {
        QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel() - 1);
        graphicsPreset.text = presets[QualitySettings.GetQualityLevel()];
        SetGraphicsPreset(QualitySettings.GetQualityLevel());
    }
    #endregion

    public void SettingsSave()
    {
        PlayerPrefs.Save();
    }
    #endregion

}
