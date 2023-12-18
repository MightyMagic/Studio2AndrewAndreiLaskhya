using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSystem : MonoBehaviour, IObserver
{
    [SerializeField] ObserverSubject playerSubject;

    [SerializeField] AudioSource sfxAudioSource;

    [SerializeField] AudioClip birdsClip;
    [SerializeField] AudioClip beaconClip;

    [SerializeField] float volumePower;

   public void OnNotify(SoundAction soundAction)
   {
        switch(soundAction)
        {
            case SoundAction.AttackedByBirds:
                Debug.Log("attack started");
                if (!sfxAudioSource.isPlaying)
                {
                    sfxAudioSource.clip = birdsClip;
                    sfxAudioSource.loop = true;
                    sfxAudioSource.Play();
                }
                else
                {
                    sfxAudioSource.Stop();
                    sfxAudioSource.clip = birdsClip;
                    sfxAudioSource.loop = true;
                    sfxAudioSource.Play();
                }
                break;
            case SoundAction.BirdsLeft:
                Debug.Log("attack stopped");
                if (sfxAudioSource.isPlaying)
                {
                    sfxAudioSource.loop = false;
                    //sfxAudioSource.Stop();
                }
                break;
            case SoundAction.EnteredBeacon:
                if (!sfxAudioSource.isPlaying)
                {
                    sfxAudioSource.loop = false;
                  
                    sfxAudioSource.clip = beaconClip;
                    sfxAudioSource.Play();
                   
                }
                else if (sfxAudioSource.clip != beaconClip)
                {
                    sfxAudioSource.Stop();
                   
                    sfxAudioSource.loop = false;
                    sfxAudioSource.clip = beaconClip;
                    sfxAudioSource.Play();
                   
                }
                Debug.Log("entered beacon");
                break;
        }
        
   }

    private void OnEnable()
    {
        playerSubject.AddObserver(this);
    }

    private void OnDisable()
    {
        playerSubject.RemoveObserver(this);
    }
}

public enum SoundAction
{
    AttackedByBirds,
    BirdsLeft,
    EnteredBeacon
}
