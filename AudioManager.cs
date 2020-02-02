using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioClip moveSfx;
    public static AudioClip alarmSfx;
    public static AudioClip doorSfx;
    public static AudioClip fixSfx;

    public static AudioClip music;

    public static AudioSource sfxPlayer;
    public static AudioSource musicPlayer;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        sfxPlayer = GameObject.FindGameObjectWithTag("SFXPlayer").GetComponent<AudioSource>();
        sfxPlayer = GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>();
        musicPlayer.clip = music;
    }

    public static void PlayMoveSfx()
    {
        sfxPlayer.Stop();
        sfxPlayer.clip = moveSfx;
        sfxPlayer.loop = true;
        sfxPlayer.Play();
    }
    public static void PlayAlarmSfx()
    {
        sfxPlayer.Stop();
        sfxPlayer.clip = moveSfx;
        sfxPlayer.loop = true;
        sfxPlayer.Play();
    }
    public static void PlayDoorSfx()
    {
        sfxPlayer.Stop();
        sfxPlayer.clip = moveSfx;
        sfxPlayer.Play();
    }
    public static void PlayFixSfx()
    {
        sfxPlayer.Stop();
        sfxPlayer.clip = moveSfx;
        sfxPlayer.Play();
    }
    public static void StopSfx()
    {
        sfxPlayer.Stop();
        sfxPlayer.clip = moveSfx;
        sfxPlayer.Play();
    }

    public static void PlayMusic()
    {
        musicPlayer.loop = true;
        musicPlayer.Play();
    }

    public static void ResetMusic()
    {
        musicPlayer.Stop();
        musicPlayer.Play();
    }
}
