using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum doorState
{
    Unlocked,
    Locked,
    Lockpick,
    Pin
}
public enum doorType
{
    None,
    Red,
    Green,
    Blue,
}
public class NormalDoor : MonoBehaviour
{
    public GameObject padLock;
    LPLockActivator lockPickProcess;
    public doorState doorState = doorState.Unlocked;
    public doorType doorType = doorType.None;
    public Vector3 openRotation;
    public Vector3 closeRotation;
    Vector3 rotation;
    public float animationTime;
    [SerializeField]
    bool isOpen = false;
    AudioSource audioSource;
    public AudioClip Open;
    public AudioClip Close;
    public AudioClip[] unlockDoor;
    public bool isPerforming;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        lockPickProcess = FindObjectOfType<LPLockActivator>();
        if(doorState!=doorState.Lockpick)
        {
            padLock = null;
        }
        //Debug.Log(doorState.ToString());
    }
    public void UnlockDoor()
    {
        if(doorState == doorState.Locked)
        {
            doorState = doorState.Unlocked;
            audioSource.clip = unlockDoor[Random.Range(0, unlockDoor.Length)];
            audioSource.Play();
        }
        else if (doorState == doorState.Lockpick)
        {
            lockPickProcess.Win();
        }
        else if (doorState == doorState.Pin)
        {
            lockPickProcess.Win();
        }
    }

    public void PlayAudioClip(AudioClip sound)
    {
        audioSource.clip = sound;
        audioSource.Play();
    }
    public string GetDoorType()
    {
        return doorType.ToString();
    }
    public void PerformAction()
    {
        if(doorState == doorState.Pin || doorState == doorState.Lockpick)
        {
            doorState = doorState.Unlocked;
            gameObject.layer = 0;
        }
        if(audioSource)
        {
            if(isOpen)
            {
                audioSource.clip = Close;
                audioSource.Play();
            }
            else
            {
                audioSource.clip = Open;
                audioSource.Play();
            }
        }
        if (isOpen)
        {
            rotation = closeRotation;
        }
        else
        {
            rotation = openRotation;
        }

        isOpen = !isOpen;
        transform.DORotate(rotation, animationTime);

        isPerforming = true;
        StartCoroutine(ResetPerforming());
    }

    IEnumerator ResetPerforming()
    {
        yield return new WaitForSeconds(animationTime);
        isPerforming = false;
    }
}
