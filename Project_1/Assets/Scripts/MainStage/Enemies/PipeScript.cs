using UnityEngine;

namespace MainStage.Enemies
{
    public class PipeScript : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 5;
        public bool move = true;
        // Update is called once per frame
        void Update()
        {
            if (move)
                transform.position += Vector3.left * (moveSpeed * Time.deltaTime); //the pipe is going left
        }
    
    }
}
