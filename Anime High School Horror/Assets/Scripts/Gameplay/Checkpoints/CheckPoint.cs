using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CheckPoint : MonoBehaviour
{
    GameManager gameManager;
    public int checkpointNumber;
    Transform checkpoint;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        checkpoint = transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
           // gameManager.SetPlayerPosition(checkpoint);
            PlayerPrefs.SetInt("CheckPoint", checkpointNumber);
            gameManager.checkpointText.DOFade(1, 2);
        }
    }
}
