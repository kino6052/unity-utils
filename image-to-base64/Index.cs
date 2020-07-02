using System;
using UnityEngine;

public class Index : MonoBehaviour
{
  void ReceiveTexture(string textureString) {
    byte[] bTexture = System.Convert.FromBase64String(textureString);
    texture.LoadImage(bTexture);
    material.mainTexture = texture;
  }
}