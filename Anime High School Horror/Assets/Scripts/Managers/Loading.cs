using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject loadingPanel;
    public Slider slider;

    public void GameType(string gameType)
    {
        if(gameType == "NewGame")
        {
            PlayerPrefs.SetInt("CurrentLevel", 0);
            PlayerPrefs.DeleteKey("CheckPoint");
            PlayerPrefs.SetInt("Intro", 0);
        }
    }

    public void LoadingScene(string sceneName)
    {
        loadingPanel.SetActive(true);

        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string sceneName)
    {
        
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        float progress = operation.progress / 0.9f;

        while(!operation.isDone)
        {
            slider.value = operation.progress;
            //operation.allowSceneActivation = false;

            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
