using UnityEngine;

namespace MainStage.Player
{
    public class BallScript : MonoBehaviour
    {
        [SerializeField] float moveSpeed;
        void Update()
        {
            transform.position += Vector3.right * (Time.deltaTime * moveSpeed);
            if (transform.position.x >= 30f) Destroy(gameObject);
        }
    
    }
}
