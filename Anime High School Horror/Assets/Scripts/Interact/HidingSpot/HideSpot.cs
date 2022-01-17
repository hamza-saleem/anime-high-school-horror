using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpot : MonoBehaviour
{
    public Camera hideCamera;
    public GameObject raycastManager;
    public Camera playerCamera;
    public GameObject playerObj;

    [SerializeField]
    Vector3 spotPosition;
    Quaternion spotRotation;
    public Vector3 hideCameraPositionOffset;
    public Vector3 hideCameraRotationOffset;
    Quaternion newRotation;
    [SerializeField]
    Vector3 cameraPosition;

    private void Awake()
    {
        spotPosition = transform.position;
        spotRotation = transform.rotation;
    }

    public void Hide()
    {
        //playerCamera.gameObject.SetActive(false);
        raycastManager.SetActive(false);
        hideCamera.gameObject.SetActive(true);
        playerObj.layer = 23;
    }

    public void Unhide()
    {
        hideCamera.gameObject.SetActive(false);
        playerCamera.enabled = true;
        raycastManager.SetActive(true);
        playerObj.layer = 11;

    }

    private void Update()
    {
        //spotSize = (transform.position / 2) + hideCameraOffset;

        hideCamera.gameObject.transform.position += hideCameraPositionOffset;
       // hideCamera.gameObject.tratranslate(0,0,0);
        //Debug.Log(spotSize);
    }
}
