using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class trigger_behaviour : MonoBehaviour
{
   
    
    public bool isIn = false;

    private Texture2D _imageTexture;


    private void Awake()
    {
        _imageTexture = gameObject.GetComponentInParent<poster_stand>().image;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasBehaviour actions = other.gameObject.GetComponent<CanvasBehaviour>();
            actions.SetImage(_imageTexture);
            actions.ShowUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasBehaviour actions = other.gameObject.GetComponent<CanvasBehaviour>();
            actions.ShowUI(false);
            actions.ResetValues();
        }
    }




}
