using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class image_drag : MonoBehaviour, IDragHandler 
{
    #region IDragHandler implementation

    public void OnDrag (PointerEventData eventData)
    {
        this.transform.position += (Vector3)eventData.delta/1500;
    }

    #endregion
    
    // public void DragObject()
    // {
    //     transform.position = Input.mousePosition;
    // }
    
}
