using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class trigger_behaviour : MonoBehaviour
{
   
    
    public bool isIn = false;

    private Texture2D image_texture;


    private void Awake()
    {
        image_texture = gameObject.GetComponentInParent<poster_stand>().image;
    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasBehaviour actions = other.gameObject.GetComponent<CanvasBehaviour>();
            actions.setImage(image_texture);
            actions.showUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanvasBehaviour actions = other.gameObject.GetComponent<CanvasBehaviour>();
            actions.showUI(false);
        }
    }




}
