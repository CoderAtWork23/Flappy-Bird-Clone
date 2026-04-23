using MainStage.Player;
using UnityEngine;

namespace MainStage.Stage
{
    public class BallStack : MonoBehaviour
    {
        BallSpawner _ballSpawner;
        SoundManager _soundManager;
        const int BallsToAdd = 1;
        void Start()
        {
            _ballSpawner = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<BallSpawner>();
            _soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _ballSpawner.AddBalls(BallsToAdd);
                _soundManager.PlayBallSound();
                Destroy(gameObject);
            }
        }

    }
}
