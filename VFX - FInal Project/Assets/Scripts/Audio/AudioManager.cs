using System;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public Sound[] sounds;

        private void Awake()
        {
            foreach (var sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
                sound.source.clip = sound.clip;
                sound.source.outputAudioMixerGroup = sound.audioMixerGroup;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
            }
        }

        public void Play(string soundName)
        {
            var soundToPlay = Array.Find(sounds, sound => sound.name == soundName);
            soundToPlay.source.Play();
        }

        public void Loop(string soundName)
        {
            var soundToLoop = Array.Find(sounds, sound => sound.name == soundName);
            soundToLoop.source.loop = true;
        }

        public void UpdateValues()
        {
            foreach (var sound in sounds)
            {
                sound.source.clip = sound.clip;
                sound.source.outputAudioMixerGroup = sound.audioMixerGroup;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
            }
        }
    }
}
