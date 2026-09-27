using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImage : MonoBehaviour
{
    public Texture[] textures;
    private int currTextureIndex = 0;

    private void Start()
    {
        if (textures.Length > 0)
        {
            GetComponent<Renderer>().material.mainTexture = textures[0];
        }
    }

    public void changeImage()
    {
        currTextureIndex = (currTextureIndex + 1) % textures.Length;
        GetComponent<Renderer>().material.mainTexture = textures[currTextureIndex];
    }
}
