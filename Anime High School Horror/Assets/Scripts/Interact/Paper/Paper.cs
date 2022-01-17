using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    public GameObject paper;
    public Text paperText;
    public string textToWrite;

    private void Awake()
    {
        paperText.text = textToWrite;
    }
}
