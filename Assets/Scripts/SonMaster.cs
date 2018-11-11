using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonMaster : MonoBehaviour {

    public List<AudioSource> musiques = new List<AudioSource>();
   
    public AudioSource currentMusique;

    public List<AudioSource> bruitageAS = new List<AudioSource>();

    public List<AudioL> clips;

    public float speedDownUp = 5;

    public void ChangeMusique(int i, float delay)
    {
        if(musiques[i] != currentMusique)
        {
            //launch co routine pour diminuer volume
            if (currentMusique != null) 
                StartCoroutine(diminitionSoundMusic(currentMusique, speedDownUp, 0));
            currentMusique = musiques[i];
            StartCoroutine(augmentatSoundMusic(currentMusique, speedDownUp, 0.5f, delay));
        }

    }
    private IEnumerator diminitionSoundMusic(AudioSource aS, float speed, float targetVolume)
    {
        float volume = aS.volume;
        while (volume > targetVolume)
        {
            volume -= speed * Time.deltaTime;
            aS.volume = volume;
            yield return new WaitForSeconds(0.1f);
        }
        aS.volume = targetVolume;
    }
    private IEnumerator augmentatSoundMusic(AudioSource aS, float speed, float targetVolume, float delay = 0)
    {
        float volume = aS.volume;
        yield return new WaitForSeconds(delay);
        while (volume < targetVolume)
        {
            volume += speed * Time.deltaTime;
            aS.volume = volume;
            yield return new WaitForSeconds(0.1f);
        }
        aS.volume = targetVolume;
    }

    public void JoueBruitage(int bruitageIndex, bool random)
    {
        AudioSource reS = bruitageAS[0];
        foreach (AudioSource aS in bruitageAS)
        {
            if (!aS.isPlaying)
            {
                reS = aS;
            }
        }
        PlaySOundList(clips[bruitageIndex].auClip, reS);
    }


    //BRUITAGE : exemple
    public void PlayShot()
    {
       // PlaySOundList(, );
    }

    public void PlaySOundList(List<AudioClip> listSource, AudioSource source)
    {
        int random = Random.Range(0, listSource.Count);
        source.clip = listSource[random];
        source.PlayOneShot(source.clip);
    }


}
