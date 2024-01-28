using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwaper : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapSprite(int index)
    {
        spriteRenderer.sprite = sprites[index];
    }
}
