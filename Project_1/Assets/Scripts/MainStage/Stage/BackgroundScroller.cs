using System.Collections.Generic;
using UnityEngine;

namespace MainStage.Stage
{
    public class BackgroundScroller : MonoBehaviour
    {
        [SerializeField] GameObject backgroundPrefab;
        [SerializeField] LogicManager logicManager;
    
        List<GameObject> _background = new List<GameObject>();
        void Start()
        {
            _background.Add(Instantiate(backgroundPrefab, new Vector3(22f, 0, 0), transform.rotation));
        }

        void Update()
        {
            if (_background.Count < 2 && _background[0].transform.position.x <= -22f)
            {
                _background.Add(Instantiate(backgroundPrefab, new Vector3(57.6f, 0, 0), transform.rotation));
            }
        
            if (logicManager.gameOverPanel.activeSelf)
                StopWallPapers();
        
            if (!(_background[0].transform.position.x <= -57.6f)) return;
            Destroy(_background[0]);
            _background.RemoveAt(0);
        }
    
        void StopWallPapers()
        {
            foreach (GameObject background in _background)
                background.GetComponent<BackgroundScript>().move =  false;       
        }
    
    
    }
}
