using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class poster_stand : MonoBehaviour
{
    public Texture2D image;
    private Renderer m_Renderer;

    

    private void Awake()
    {
        m_Renderer = gameObject.transform.Find("Plane").GetComponent<Renderer>();
    }

    private void Start()
    {
        m_Renderer.material.SetTexture("_MainTex", image);
    }
}
