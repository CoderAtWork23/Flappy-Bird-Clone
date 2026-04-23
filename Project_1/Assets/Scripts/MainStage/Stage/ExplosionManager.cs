using UnityEngine;

namespace MainStage.Stage
{
    public class ExplosionManager : MonoBehaviour
    {
        [SerializeField] GameObject explosionPrefab;
        [SerializeField] SoundManager soundManager;
        public void InstantiateExplosion(GameObject obj)
        {
            float x = obj.transform.position.x;
            float y = obj.transform.position.y;
            Instantiate(explosionPrefab,new Vector2(x,y),transform.rotation);
            soundManager.PlayExplosionSound();
        }
    }
}
