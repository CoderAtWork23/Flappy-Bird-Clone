using UnityEngine;
using UnityEngine.EventSystems;

namespace RejectedConcepts
{
    public class ButtonDebug : MonoBehaviour, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("BUTTON WAS CLICKED");
        }
    }
}
