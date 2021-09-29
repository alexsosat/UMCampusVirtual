using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CanvasBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject hintText;
    [SerializeField] private GameObject image;
    [SerializeField] private GameObject closeButton;

    private Sprite mySprite;
    private Image image_renderer;
    private PhotonView view;

    private bool canOpen = false;


    private void Awake()
    {
        canvas = gameObject.transform.Find("Canvas").gameObject;
        hintText = canvas.transform.Find("Text (TMP)").gameObject;
        image = canvas.transform.Find("Image").gameObject;
        closeButton = canvas.transform.Find("Button").gameObject;
        view = GetComponent<PhotonView>();
    }

    public void setImage(Texture2D image_texture)
    {
        image_renderer = image.GetComponent<Image>();
        mySprite = Sprite.Create(image_texture, new Rect(0.0f, 0.0f, image_texture.width, image_texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        image_renderer.sprite = mySprite;
        image_renderer.preserveAspect = true;
    }

    public void showUI(bool value)
    {
        canOpen = value;
        canvas.SetActive(value);
    }

    public void showPoster(bool value)
    {
        hintText.SetActive(!value);
        image.SetActive(value);
        closeButton.SetActive(value);
        //player.GetComponent<MoveBehaviour>().runSpeed = value?0:0.7f;
        //player.GetComponentInChildren<ThirdPersonOrbitCamBasic>().enabled = !value;
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (canOpen && Input.GetKeyDown(KeyCode.E))
            {
                showPoster(true);
            }
        }
    }
}
