using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTrigger : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        int objective = gameManager.GetObjective();
        if(other.gameObject.CompareTag("Player"))
        {
          if(gameManager.currentLevel==0)
            {
                if(objective == 2)
                {
                    gameManager.SetObjective(3);
                    Destroy(gameObject);
                }
                if (objective == 3)
                {
                    gameManager.SetObjective(4);
                    Destroy(gameObject);
                }
            }

          if(gameManager.currentLevel == 1)
            {
                if(objective == 3)
                {
                    gameManager.SetObjective(4);
                    Destroy(gameObject);
                }
            }
          if(gameManager.currentLevel == 2)
            {
                if(objective == 1)
                {
                    gameManager.SetObjective(2);
                    Destroy(gameObject);
                }
                if (objective == 2)
                {
                    gameManager.SetObjective(3);
                    GameObject.Find("Barricade1").SetActive(false);
                    GameObject.Find("Barricade2").SetActive(false);
                    Destroy(gameObject);
                }
                if (objective == 3)
                {
                    gameManager.SetObjective(4);
                    Destroy(gameObject);
                }
                if(objective == 4)
                {
                    gameManager.SetObjective(5);
                    Destroy(gameObject);
                }
            }
          if(gameManager.currentLevel == 3)
            {
                if(objective == 1)
                {
                    gameManager.SetObjective(2);
                }

                if(objective == 5)
                {
                    gameManager.SetObjective(6);
                }
            }
            
        }
    }

}
