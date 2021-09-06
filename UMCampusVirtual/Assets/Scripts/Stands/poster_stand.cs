using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class poster_stand : MonoBehaviour
{
    public Texture2D image;
    private Renderer m_Renderer;

    private Sprite mySprite;
    private Image image_renderer;

    private void Awake()
    {
        m_Renderer = gameObject.transform.Find("Plane").GetComponent<Renderer>();
        image_renderer = gameObject.GetComponentInChildren<Image>();
    }

    private void Start()
    {
        image_renderer.enabled = false;
        m_Renderer.material.SetTexture("_MainTex", image);
        mySprite = Sprite.Create(image, new Rect(0.0f, 0.0f, image.width, image.height), new Vector2(0.5f, 0.5f), 100.0f);
        image_renderer.sprite = mySprite;
        image_renderer.preserveAspect = true;
    }
}
