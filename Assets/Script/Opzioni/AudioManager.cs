using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    //pubblico così si può usare anche da altri script
    public static AudioManager instance;
    //sfx significa effetto speciale
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private void Awake()
    {
        //istanza dell' oggetto se già non è avvenuta
        if(instance==null)
        {
            instance = this;
            //non distruggo l' oggetto quando viene caricata una nuova scena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //deve essere lo stesso nome del file della musica che si vuole eseguire
        PlayMusic("Theme");
    }
    public void PlayMusic(string nome)
    {
        //cerco il suono in base al nome
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if(s==null)
        {
            Debug.Log("Sound not found");
        }
        //se lo ha trovato riproduco il suono
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string nome)
    {
        //cerco il suono in base al nome
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }
    //per opzioni che regolano il volume
    public void OpzioniMusic()
    {
        //cambio stato della musica
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
