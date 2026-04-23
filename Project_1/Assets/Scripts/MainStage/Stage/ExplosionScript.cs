using UnityEngine;

namespace MainStage.Stage
{
    public class ExplosionScript : MonoBehaviour
    {
        //To Do
        //Sound Here
    
        public void DestroyOnAnimationEnd()
        {
            Destroy(gameObject);
        }
    }
}
