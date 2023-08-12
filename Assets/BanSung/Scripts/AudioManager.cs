using Jackal;
using UnityEngine;

namespace Assets.BanSung.Scripts
{
    public class AudioManager : Singleton<AudioManager>
    {
        public AudioSource _AudioSource;

        public void Play(AudioClip clip)
        {
            _AudioSource.PlayOneShot(clip);
        }
    }
}