using MainStage.Stage;
using UnityEngine;
using UnityEngine.Events;

namespace MainStage.Enemies
{
    public class EnemyTriggerScript : MonoBehaviour
    {
        public UnityEvent explosion;

        private void Awake()
        {
            explosion.AddListener(() =>
                GameObject.FindGameObjectWithTag("ExplosionManager") 
                    .GetComponent<ExplosionManager>()
                    .InstantiateExplosion(gameObject)
            );
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                explosion.Invoke();
                Destroy(transform.root.gameObject);
            }
        }
    }
}
