using System.Collections.Generic;
using MainStage.Player;
using MainStage.Stage;
using UnityEngine;

namespace MainStage.Enemies
{
    public class PipeSpawnerScript : MonoBehaviour
    {
        [SerializeField] GameObject pipePrefab;
        [SerializeField] GameObject pipePrefab2;
        [SerializeField] GameObject enemyAIPrefab;
        [SerializeField] LogicManager logicManager;
        [SerializeField] BallSpawner ballSpawner;

        private int _maxBalls;

        // Enemy (Public)
        public float spawnRateEnemy;
        public float heightOffsetEnemy;
        // Enemy (Private)
        private List<GameObject> _enemyList;
        private float _timerEnemy;
        private bool _spawnEnemy;

        // Pipe (Public)
        public float spawnRatePipe;
        public float heightOffsetPipe;
        // Pipe (Private)
        private List<GameObject> _pipeList;
        private float _timerPipe;
        private bool _spawnPipe;

        void Start()
        {
            _enemyList = new List<GameObject>();
            _spawnEnemy = true;
            _maxBalls = BallSpawner.MaxBalls;
        
            _pipeList = new List<GameObject>();
            _spawnPipe = true;
            SpawnPipe();
        }

        void Update()
        {
            if (_spawnEnemy)
            {
                if (_timerEnemy >= spawnRateEnemy)
                {
                    TrySpawnEnemy();
                    _timerEnemy = 0;
                }
                else
                {
                    _timerEnemy += Time.deltaTime;
                }
            }

            if (_spawnPipe)
            {
                if (_timerPipe >= spawnRatePipe)
                {
                    SpawnPipe();
                    _timerPipe = 0;
                }
                else
                    _timerPipe += Time.deltaTime;
            }
            else
            {
                StopPipes();
            }

            if (logicManager.gameOverPanel.activeSelf)
            {
                _spawnEnemy = false;
                _spawnPipe = false;
                StopPipes();
            }

            DeletePipes();
            DeleteEnemies();
        }

        void TrySpawnEnemy()
        {
            int currentBalls = ballSpawner.BallCount;

            // 0 balls = 20% chance, 1 ball = 70%, 5 balls = 94%
            float spawnChance;
            if (currentBalls == 0)
                spawnChance = 0.2f;
            else
                spawnChance = 0.7f + ((float)(currentBalls - 1) / (_maxBalls - 1)) * 0.24f;

            if (Random.value <= spawnChance)
                SpawnEnemy();
        }

        void SpawnEnemy()
        {
            float lowerPoint = transform.position.y - heightOffsetEnemy;
            float highestPoint = transform.position.y + heightOffsetEnemy;

            _enemyList.Add(Instantiate(enemyAIPrefab, new Vector3(transform.position.x, Random.Range(lowerPoint, highestPoint), 0), transform.rotation));
        }

        void DeleteEnemies()
        {
            for (int i = _enemyList.Count - 1; i >= 0; i--)
            {
                if (!_enemyList[i])
                    _enemyList.RemoveAt(i);
            }
        }

        void SpawnPipe()
        {
            float lowestPoint = transform.position.y - heightOffsetPipe;
            float highestPoint = transform.position.y + heightOffsetPipe;

            // Ammo pack chance scales inversely with ball count:
            // 0 balls = 100% chance of ammo pack, 5 balls = 0% chance
            int currentBalls = ballSpawner.BallCount;
            float ammoPackChance = 1f - (float)currentBalls / (_maxBalls * 0.4f);

            GameObject prefabToSpawn = Random.value <= ammoPackChance ? pipePrefab2 : pipePrefab;

            _pipeList.Add(Instantiate(prefabToSpawn, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation));
        }

        void DeletePipes()
        {
            if (_pipeList.Count > 0 && _pipeList[0].transform.position.x < -20)
            {
                Destroy(_pipeList[0]);
                _pipeList.RemoveAt(0);
            }
        }

        void StopPipes()
        {
            foreach (var pipe in _pipeList)
                pipe.GetComponent<PipeScript>().move = false;
        }
    }
}