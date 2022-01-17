using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    MainUIController UI;
    public Button continueBtn;
    int graphicsPreset;

    #region UnityMethods
    private void Awake()
    {
        UI = FindObjectOfType<MainUIController>();
        if (!PlayerPrefs.HasKey("CheckPoint"))
            continueBtn.interactable = false;
        
    }
    private void Start()
    {
        SetGraphicsPreset(PlayerPrefs.GetInt("GraphicsPreset"));
        GetGraphicsPreset();
    }
    #endregion

    #region Settings
    #region Graphics Settings
    void SetGraphicsPreset(int i)
    {
        PlayerPrefs.SetInt("GraphicsPreset", QualitySettings.GetQualityLevel());
    }
    void GetGraphicsPreset()
    {
        UI.graphicsPreset.text = UI.presets[QualitySettings.GetQualityLevel()];
    }

    public void NextPreset()
    {
       QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel() + 1);
        UI.graphicsPreset.text = UI.presets[QualitySettings.GetQualityLevel()];
        SetGraphicsPreset(QualitySettings.GetQualityLevel());
    }

    public void PreviousPreset()
    {
        QualitySettings.SetQualityLevel(QualitySettings.GetQualityLevel() - 1);
        UI.graphicsPreset.text = UI.presets[QualitySettings.GetQualityLevel()];
        SetGraphicsPreset(QualitySettings.GetQualityLevel());
    }
    #endregion

    public void SettingsSave()
    {
        PlayerPrefs.Save();
    }
    #endregion

    
    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
