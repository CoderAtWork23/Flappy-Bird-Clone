using UnityEngine;

namespace MainStage.Stage
{
    public class BackgroundScript : MonoBehaviour
    {
        [SerializeField] float backgroundSpeed = 2f;
        public bool move;

        void Awake()
        {
            move = true;
        }
        void Update()
        {
            if (move)
                transform.position +=  Vector3.left * (backgroundSpeed * Time.deltaTime);
        }
    }
}
