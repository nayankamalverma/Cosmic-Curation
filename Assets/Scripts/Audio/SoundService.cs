using System;
using Unity.VisualScripting;
using UnityEngine;

namespace CosmicCuration.Audio
{
	public class SoundService : MonoBehaviour
	{
        private static SoundService instance;
        public static SoundService Instance => instance;

        [SerializeField]
        private AudioSource backgroundMusic;
        [SerializeField]
        private AudioSource soundEffect;
        [SerializeField]
        private SoundScriptableObject soundScriptableObject;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            PlayBackgroundMusic(SoundType.BackgroundMusic);
        }

        public void Play(SoundType soundType)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                soundEffect.clip = clip;
                soundEffect.PlayOneShot(clip);
            }
            else Debug.Log("Audio clip not found for " + soundType);

        }

        private void PlayBackgroundMusic(SoundType soundType)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                backgroundMusic.clip = clip;
                backgroundMusic.Play();
            }
            else Debug.LogError("No Audio Clip selected.");
        }

        private AudioClip GetSoundClip(SoundType soundType)
        {
            Sounds sound = Array.Find(soundScriptableObject.audioList, s => s.soundType == soundType);
            if(sound.audio != null) return sound.audio;
            return null;
        }
    }
}