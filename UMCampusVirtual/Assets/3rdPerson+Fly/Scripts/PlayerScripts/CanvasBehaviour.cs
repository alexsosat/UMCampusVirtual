using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CanvasBehaviour : MonoBehaviour
{
    public GameObject player;
    
    private GameObject _canvas;
    private GameObject _hintText;
    private GameObject _image;
    private GameObject _closeButton;
    private GameObject _scaleScroll;
    
    private Sprite _mySprite;
    private Image _imageRenderer;
    private PhotonView _view;

    private bool _canOpen = false;
    private bool _imageOpen = false;


    private void Awake()
    {
        _canvas = gameObject.transform.Find("Canvas").gameObject;
        _hintText = _canvas.transform.Find("Text (TMP)").gameObject;
        _image = _canvas.transform.Find("Image").gameObject;
        _closeButton = _canvas.transform.Find("Button").gameObject;
        _scaleScroll = _canvas.transform.Find("Slider").gameObject;
        _view = GetComponent<PhotonView>();
    }

    public void SetImage(Texture2D imageTexture)
    {
        _imageRenderer = _image.GetComponent<Image>();
        _mySprite = Sprite.Create(imageTexture, new Rect(0.0f, 0.0f, imageTexture.width, imageTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
        _imageRenderer.sprite = _mySprite;
        _imageRenderer.preserveAspect = true;
    }

    public void ShowUI(bool value)
    {
        _canOpen = value;
        _canvas.SetActive(value);
    }

    public void ShowPoster(bool value)
    {
        _imageOpen = value;
        _hintText.SetActive(!value);
        _image.SetActive(value);
        _closeButton.SetActive(value);
        _scaleScroll.SetActive(value);
        //player.GetComponent<MoveBehaviour>().runSpeed = value?0:0.7f;
        player.GetComponentInChildren<ThirdPersonOrbitCamBasic>().enabled = !value;
        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ScaleImage(Slider slider)
    {
        _image.transform.localScale =  new Vector3(slider.value,slider.value,1f);
    }

    public void ResetValues()
    {
        _image.transform.localScale = new Vector3(1, 1, 1);
        _image.transform.localPosition = new Vector3(0, 0, 0);
        _scaleScroll.GetComponent<Slider>().value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_view.IsMine)
        {
            if (_canOpen && !_imageOpen && Input.GetKeyDown(KeyCode.E))
            {
                ShowPoster(true);
            }
            else if (_imageOpen && Input.GetKeyDown(KeyCode.E))
            {
                ShowPoster(false);
            }
        }
    }
}
