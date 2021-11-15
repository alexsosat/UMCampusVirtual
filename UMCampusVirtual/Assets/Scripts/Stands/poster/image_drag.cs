using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class image_drag : MonoBehaviour, IDragHandler
{
    public GameObject canvasObject;
    private float _xCoefficient = 0f;
    private float _zCoefficient = 0f;
    
    #region IDragHandler implementation

    public void OnDrag (PointerEventData eventData)
    {
        SetCoefficients(canvasObject.transform.eulerAngles.y);
        
        Vector2 moveDelta = eventData.delta / 1500;
        this.transform.position += new Vector3(moveDelta.x*_xCoefficient,moveDelta.y,moveDelta.x * _zCoefficient);
    }

    private void SetCoefficients(float canvasRotation)
    {
        _xCoefficient = (float)Mathf.Cos((canvasRotation * Mathf.PI)/180);
        _zCoefficient = (float)Mathf.Sin((canvasRotation * Mathf.PI)/180)*-1;
        
    }

    #endregion
    
    // public void DragObject()
    // {
    //     transform.position = Input.mousePosition;
    // }
    
}
