using UnityEngine;

namespace MainStage.Stage
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] AudioSource deathSound;
        [SerializeField] AudioSource ballSound;
        [SerializeField] AudioSource explosionSound;
        [SerializeField] AudioSource aliveSong;
    
        [Space]
        [SerializeField] AudioSource[] kickSounds;
        int _kickSound = 0;
    
    
        public void PlayDeathSound() { deathSound.Play(); }
        public void PlayBallSound() { ballSound.Play(); }
        public void PlayExplosionSound() { explosionSound.Play(); }
        public void PlayAliveSong() { aliveSong.Play(); }
        public void StopAliveSong() { aliveSong.Stop(); }

        public void PlayKickSounds()
        {
            kickSounds[_kickSound].Play();
            _kickSound++;
            if (_kickSound >= kickSounds.Length)
                _kickSound = 0;
        }
    
    }
}
