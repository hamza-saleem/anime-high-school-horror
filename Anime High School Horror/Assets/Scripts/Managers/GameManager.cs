using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public delegate void m_InitAll();
    public m_InitAll m_InitAllBehavior;
    public int currentLevel;
    int currentLevelNumber;
    public GameObject[] levels;
    public GameObject player;
    public GameObject[] playerSpawnPositions;
    public Transform savePoint;

    ObjectivesManager objectivesManager;
    public Text objectivesTask;
    public Text checkpointText;

    public UnityEvent introCutscene;
    public UnityEvent noIntroCutscene;

    #region Builtin Methods

    private void Awake()
    {
        InitAllBehavior();
        if (PlayerPrefs.GetInt("Intro") == 0)
        {
            PlayerPrefs.SetInt("Intro", 1);
            if (introCutscene != null)
            {
                introCutscene.Invoke();
            }
        }
        else
        {
            if (noIntroCutscene != null)
            {
                noIntroCutscene.Invoke();
            }
        }
        PlayerPrefs.SetInt("CurrentObjective", 0);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        
        

        

       // checkpointText.DOFade(0, 2);

    }
    private void InitAllBehavior()
    {

        Application.targetFrameRate = 60;

        if (m_InitAllBehavior != null)
        {
            m_InitAllBehavior(); // Init All Managers From GameManager Script
        }
    }
    private void Start()
    
    {
        FadeInFadeOut();
    }
    #endregion

    #region CustomMethods

    public void LoadLevel()
    {
        //FadeInFadeOut();
        if (!PlayerPrefs.HasKey("CheckPoint"))
        {
            PlayerPrefs.SetInt("CheckPoint", 0);
        }
        currentLevelNumber = PlayerPrefs.GetInt("CurrentLevel");
        levels[currentLevelNumber].SetActive(true);
        objectivesManager = levels[currentLevelNumber].GetComponent<ObjectivesManager>();
        objectivesTask.text = "- " + objectivesManager.objectives[0];

        if (PlayerPrefs.GetInt("CheckPoint") == 0)
        {
            player.transform.position = playerSpawnPositions[currentLevelNumber].transform.position;
            player.transform.rotation = playerSpawnPositions[currentLevelNumber].transform.rotation;
        }

        else
        {
            player.transform.position = savePoint.position;
            player.transform.rotation = savePoint.rotation;
        }
    }
    public void SetObjective(int objectiveNumber)
    {
        objectivesTask.text = "- " + objectivesManager.objectives[objectiveNumber];
        PlayerPrefs.SetInt("CurrentObjective", objectiveNumber);
    }
    public int GetObjective()
    {
        return (PlayerPrefs.GetInt("CurrentObjective"));
    }
    public void FadeInFadeOut()
    {
        Fading.instance.DoFadingDo();
    }

    #endregion
}
