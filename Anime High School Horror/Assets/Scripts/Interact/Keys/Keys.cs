using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum keyType
{
    Red,
    Green,
    Blue
}
public class Keys : MonoBehaviour
{
    public static Keys instance;
    public keyType keyColor;
    
    private void Awake()
    {
        instance = this;
    }
    public string GetKey()
    {
        return keyColor.ToString();
    }
}
