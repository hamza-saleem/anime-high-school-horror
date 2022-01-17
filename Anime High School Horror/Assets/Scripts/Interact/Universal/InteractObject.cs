using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum interactType
{   
    None,
    Door,
    Key,
    HideSpot,
    Safe,
    Bonefire,
    Paper,
    Keypad,
    Stethoscope,
    Axe
}

public class InteractObject : MonoBehaviour
{
    
    [Header("Object Settings")]
    public interactType interactableType= interactType.None;
    public string itemName;
    [Space(10)]
    [Header("Check")]
    public bool raycasted;
    [SerializeField]
    RaycastManager raycastManager;

    void Start()
    {
        raycastManager = FindObjectOfType<RaycastManager>();
    }
    private void Update()
    {
        if (raycastManager)
        {
            if (raycastManager.raycastedObject == null || raycastManager.raycastedObject != gameObject)
            {
                raycasted = false;
            }
            else if (raycastManager.raycastedObject != null || raycastManager.raycastedObject == gameObject)
            {
                raycasted = true;
            }
        }

        if(raycasted)
        {
            Debug.Log(interactableType);
        }
    }
}
