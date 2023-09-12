using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource ButtonSource;
    public AudioSource BlowSource;
    public AudioSource CashSource;
    public AudioSource CompleteSource;
    public AudioSource ObjectHitSource; 
    
    public AudioClip ButtonClip;
    public AudioClip BlowClip;
    public AudioClip CashClip;
    public AudioClip CompleteClip;
    public AudioClip ObjectHitClip;
   
    public void ButtonSound()
    {
        ButtonSource.PlayOneShot(ButtonClip);
    }
    
   
    public void BlowSound()
    {
        ButtonSource.PlayOneShot(BlowClip, 0.4f);
    }
    
    
    public void CashSound()
    {
        ButtonSource.PlayOneShot(CashClip);
    }
    
    
    public void CompleteSound()
    {
        ButtonSource.PlayOneShot(CompleteClip);
    }
    
    public void ObjectHitSound()
    {
        ButtonSource.PlayOneShot(ObjectHitClip);
    }

}
