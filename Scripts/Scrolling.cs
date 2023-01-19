using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float scrollSpeed=10;
    public Renderer bgRend;

    void Start()
    {
        bgRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        bgRend.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);

    }
}