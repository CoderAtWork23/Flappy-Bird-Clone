using MainStage.Stage;
using UnityEngine;

namespace MainStage.Player
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] GameObject ballPrefab;
    
        [SerializeField] LogicManager logicManager;
        [SerializeField] SoundManager soundManager;
        public int BallCount { get; private set; }
        public const int MaxBalls = 5;
    

        void Start()
        {
            BallCount = 5;
            logicManager.UpdateBalls(BallCount);
        }

        public void InstantiateBall()
        {
            if (BallCount > 0)
            {
                Instantiate(ballPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
                soundManager.PlayKickSounds();
                BallCount--;
                logicManager.UpdateBalls(BallCount);
            }
        }

        public void AddBalls(int amount)
        {
            if (BallCount == MaxBalls) return;
            BallCount += amount;
            logicManager.UpdateBalls(BallCount);
        }
    }
}
