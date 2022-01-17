using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ControlFreak2;
using System.Linq;

public class RaycastManager : MonoBehaviour
{
    #region Raycast
    [Header("Raycast Settings")]
    public float distance = 2f;
    public LayerMask layerMaskInteract;
    public Color RaycastGizmoColor;
    RaycastHit hit;
    #endregion
    #region Player
    GameObject Player;
    Camera playerCamera;
    GameObject crosshair;
    #endregion
    #region Audio
    public AudioClip[] lockedSounds;
    private AudioClip locked;
    #endregion
    #region RaycastedObject
    public InteractObject raycastedObject;
    public string raycastedObjectType = "";
    public bool raycastingObj;
    public Text raycastedItemInfo;
    #endregion
    #region GameButtons
    public GameObject interactButton;
    #endregion
    #region GlobalVariables
    string doorType;
    int currentObjective;
    #endregion
    #region Class Instances
    Keys key;
    GUIReferences GUIReferences;
    GameManager gameManager;
    GameplayUIController gameplayUI;
    #endregion

    private void Start()
    {
        //inventory.items = new List<GameObject>();
        key = FindObjectOfType<Keys>();
        Player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        GUIReferences = FindObjectOfType<GUIReferences>();
        gameManager = FindObjectOfType<GameManager>();
        crosshair = GUIReferences.crosshair;
        gameplayUI = FindObjectOfType<GameplayUIController>();
        Debug.Log(gameplayUI);
    }
    private void Update()
    {
        currentObjective = gameManager.GetObjective();
        #region RaycastRay
        Vector3 position = transform.parent.position;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, direction * distance, RaycastGizmoColor);

        if (Physics.Raycast(position, direction, out hit, distance, layerMaskInteract.value))
        {
            Debug.Log((int)hit.distance);
            if (hit.transform.gameObject.GetComponent<InteractObject>())
            {
                raycastedObject = hit.transform.gameObject.GetComponent<InteractObject>();
                raycastedObjectType = raycastedObject.interactableType.ToString();
                raycastedItemInfo.text = raycastedObject.itemName;
                raycastedItemInfo.GetComponent<CanvasGroup>().alpha = 1;
                crosshair.GetComponent<Image>().color = Color.red;
                raycastingObj = true;
                interactButton.SetActive(true);
            }

        }
        else
        {
            raycastedItemInfo.text = null;
            interactButton.SetActive(false);
            crosshair.GetComponent<Image>().color = Color.white;
            raycastedItemInfo.GetComponent<CanvasGroup>().alpha = 0;
            raycastedObject = null;
            raycastedObjectType = null;
            raycastingObj = false;
        }
        #endregion
        #region Raycast Functionality
        if (raycastingObj)
        {
            if (raycastedObjectType == interactType.Door.ToString())
            {

                if(raycastedObject.gameObject.GetComponent<NormalDoor>())
                {
                    doorType = raycastedObject.gameObject.GetComponent<NormalDoor>().doorType.ToString();
                    Debug.Log(doorType);
                    if (CF2Input.GetButtonDown("Use"))
                    {
                        if (raycastedObject.gameObject.GetComponent<NormalDoor>().doorState == doorState.Unlocked)
                        {
                            if (!raycastedObject.gameObject.GetComponent<NormalDoor>().isPerforming)
                            {
                                raycastedObject.SendMessage("PerformAction");

                              //if(gameManager.currentLevel == 0)
                              //  {
                              //    gameManager.SetObjective(1);
                              //  }
                                

                            }
                        }
                        else if (raycastedObject.gameObject.GetComponent<NormalDoor>().doorState == doorState.Locked)
                        {
                            currentObjective = gameManager.GetObjective();
                            #region Level 1
                            if(gameManager.currentLevel== 0 )
                            {
                                if (raycastedObject.itemName == "Class 2-D" && currentObjective == 0)
                                {
                                    gameManager.SetObjective(1);
                                }
                            }
                            #endregion
                            #region Level 3
                            if (gameManager.currentLevel == 2)
                            {
                                if (raycastedObject.itemName == "Class 2-B" && currentObjective == 0)
                                {
                                    gameManager.SetObjective(1);
                                }
                                if (raycastedObject.itemName == "Class 2-B" && currentObjective == 3)
                                {
                                    raycastedObject.SendMessage("UnlockDoor");
                                }
                            }

                            #endregion
                            #region Level 4
                            if (gameManager.currentLevel == 3)
                            {
                                if (raycastedObject.itemName == "Class 2-E" && currentObjective == 0)
                                {
                                    gameManager.SetObjective(1);
                                }
                                //if (raycastedObject.itemName == "Class 2-B" && currentObjective == 3)
                                //{
                                //    raycastedObject.SendMessage("UnlockDoor");
                                //}
                            }
                            #endregion

                            if (Inventory.instance.SearchinInventory(doorType+"Key"))
                            {
                                if (doorType == keyType.Red.ToString())
                                {
                                    raycastedObject.SendMessage("UnlockDoor");
                                }

                               else if (doorType == keyType.Green.ToString())
                                {
                                    raycastedObject.SendMessage("UnlockDoor");

                                }

                               else if (doorType == keyType.Blue.ToString())
                                {
                                    raycastedObject.SendMessage("UnlockDoor");
                                }


                            }
                            else
                            {
                                locked = lockedSounds[Random.Range(0, lockedSounds.Length)];
                                raycastedObject.SendMessage("PlayAudioClip", locked);
                            }

                        }
                        else if (raycastedObject.gameObject.GetComponent<NormalDoor>().doorState == doorState.Pin)
                        {
                            locked = lockedSounds[Random.Range(0, lockedSounds.Length)];
                            raycastedObject.SendMessage("PlayAudioClip", locked);
                            #region Level 2
                            if(gameManager.currentLevel == 1)
                            {
                                if (raycastedObject.itemName == "Class 1-D" && currentObjective == 0)
                                {
                                    gameManager.SetObjective(1);
                                }
                            }
                            #endregion
                            
                        }
                        //else if(raycastedObject.gameObject.GetComponent<NormalDoor>().doorState == doorState.Lockpick)
                        //{
                        //    raycastedObject.gameObject.GetComponent<NormalDoor>().padLock.SetActive(true);
                        //    //raycastedObject.SendMessage("UnlockDoor");
                        //}
                    }
                }
                
            }
            else if (raycastedObjectType == interactType.Key.ToString())
            {
                string key = raycastedObject.gameObject.GetComponent<Keys>().keyColor.ToString();
                currentObjective = gameManager.GetObjective();
                Debug.Log(key);
                if (CF2Input.GetButtonDown("Use"))
                {
                    Inventory.instance.items.Add(raycastedObject.gameObject);
                    raycastedObject.gameObject.SetActive(false);
                    #region Level 1

                    if (gameManager.currentLevel == 0)
                    {
                        if(currentObjective == 1 && key == "Red")
                    {
                            gameManager.SetObjective(2);
                        }
                    }
                    #endregion
                    #region Level 4

                    if (gameManager.currentLevel == 3)
                    {
                        if (currentObjective == 4 && key == "Green")
                        {
                            gameManager.SetObjective(5);
                        }
                    }
                    #endregion
                }
            }
            else if(raycastedObjectType == interactType.HideSpot.ToString())
            {
                if(raycastedObject.gameObject.GetComponent<HideSpot>())
                {
                    if (CF2Input.GetButtonDown("Use"))
                    {
                        raycastedObject.SendMessage("Hide");
                    }
                }
                
            }
            else if(raycastedObjectType == interactType.Safe.ToString())
            {
                if (CF2Input.GetButtonDown("Use"))
                {
                    if (Inventory.instance.SearchinInventory("Stethoscope"))
                    {
                        raycastedObject.gameObject.GetComponent<LPLockActivator>().ActivateObject();
                    }
                    else
                    {
                        Debug.Log("You need Stethoscope!");
                    }
                }
                    
            }
            else if(raycastedObjectType == interactType.Bonefire.ToString())
            {
                if(CF2Input.GetButtonDown("Use"))
                {
                    // raycastedObject.
                    PlayerPrefs.SetInt("CheckPoint", 1);

                    if(gameManager.currentLevel==0)
                    {
                        if(currentObjective == 4)
                        if(currentObjective == 4)
                        {
                            gameplayUI.levelCompletePanel.SetActive(true);
                            PlayerPrefs.SetInt("UnlockedLevel", 1);
                        }

                    }

                    if (gameManager.currentLevel == 1)
                    {
                        if (currentObjective == 4)
                        {
                            gameplayUI.levelCompletePanel.SetActive(true);
                            PlayerPrefs.SetInt("UnlockedLevel", 2);
                        }

                    }

                    if(gameManager.currentLevel == 2)
                    {
                        if (currentObjective == 5)
                        {
                            gameplayUI.levelCompletePanel.SetActive(true);
                            PlayerPrefs.SetInt("UnlockedLevel", 3);
                        }
                    }
                    if (gameManager.currentLevel == 3)
                    {
                        if (currentObjective == 6)
                        {
                            gameplayUI.levelCompletePanel.SetActive(true);
                            PlayerPrefs.SetInt("UnlockedLevel", 4);
                        }
                    }


                }
            }
            else if(raycastedObjectType == interactType.Paper.ToString())
            {
                if(CF2Input.GetButtonDown("Use"))
                {
                    raycastedObject.GetComponent<Paper>().paper.SetActive(true);

                    if(gameManager.currentLevel == 1)
                    {
                        if(currentObjective == 1)
                        {
                          gameManager.SetObjective(2);
                        }
                    }
                }
            }
            else if(raycastedObjectType == interactType.Keypad.ToString())
            {
                if(gameManager.currentLevel == 1)
                {
                    if(currentObjective == 2)
                    {
                        gameManager.SetObjective(3);
                    }
                }
            }
            else if(raycastedObjectType == interactType.Axe.ToString())
            {
                if(CF2Input.GetButtonDown("Use"))
                {
                    Inventory.instance.items.Add(raycastedObject.gameObject);
                    raycastedObject.gameObject.SetActive(false);
                    if (gameManager.currentLevel == 2)
                    {
                        if (currentObjective == 1)
                        {
                            gameManager.SetObjective(2);
                        }
                    }
                }
                
            }
            else if(raycastedObjectType == interactType.Stethoscope.ToString())
            {
                if (CF2Input.GetButtonDown("Use"))
                {
                    Inventory.instance.items.Add(raycastedObject.gameObject);
                    raycastedObject.gameObject.SetActive(false);
                    if (gameManager.currentLevel == 3)
                    {
                        if (currentObjective == 3)
                        {
                            gameManager.SetObjective(4);
                        }
                    }
                }
            }
            
        }
        else if(!raycastingObj)
        {
            
        }
        #endregion
    }
}
