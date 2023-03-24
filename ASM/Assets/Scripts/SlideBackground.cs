using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideBackground : MonoBehaviour {

    public float scrollSpeed = 0.5f;
    private Renderer rend;
    float offset;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    //khoan cach offset

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0.01f);
    }
}
