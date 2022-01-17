using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpScare : MonoBehaviour
{
    public Sprite jumpScareSprite;
    public Sprite nullSprite;
    public Image image;
    bool active;
    public AudioClip jumpScareAudio;
    AudioSource audioSource;
    public float jumpScareDuration;

    private void Awake()
    {
       // image = GetComponent<Image>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!active)
            {
                image.sprite = jumpScareSprite;
                active = true;

                StartCoroutine("HideSprite");

                if (jumpScareAudio != null)
                {
                    audioSource.PlayOneShot(jumpScareAudio);
                }
            }
            
        }
    }

    IEnumerator HideSprite()
    {
        yield return new WaitForSeconds(jumpScareDuration);
        active = false;
        image.sprite = nullSprite;
    }
}
