using MainStage.Stage;
using UnityEngine;

namespace MainStage.Enemies
{
    public class MiddleTriggerScript : MonoBehaviour
    {
        LogicManager _logicManager;
        void Start()
        {
            _logicManager = GameObject.Find("LogicManager").GetComponent<LogicManager>();
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                _logicManager.AddScore(1);
            }
        }
    }
}
