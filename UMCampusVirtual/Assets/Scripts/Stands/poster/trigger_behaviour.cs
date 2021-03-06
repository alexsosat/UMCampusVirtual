using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using StarterAssets;

public class trigger_behaviour : MonoBehaviour
{
    public GameObject text;
    public GameObject button;
    public Image image;
    public bool isIn = false;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
     
        if (isIn && Input.GetKeyDown(KeyCode.E))
        {
            showPoster(true);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            showUI(false);
        }
    }

    private void showUI(bool value)
    {
        isIn = value;
        text.SetActive(value);
    }

    public void showPoster(bool value)
    {
        text.SetActive(!value);
        image.enabled = value;
        button.SetActive(value);
        player.GetComponent<ThirdPersonController>().enabled = !value;
        Cursor.lockState = value? CursorLockMode.None:CursorLockMode.Locked;
    }

}
