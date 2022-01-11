using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cshTestGradient : MonoBehaviour
{
    public Color[] colors;

    public FilterMode filterMode = FilterMode.Point;
    public TextureWrapMode wrapMode = TextureWrapMode.Clamp;
    public bool isLinear = false;
    public bool hasMipMap = false;

    void Start()
    {
        var mr = GetComponent<MeshRenderer>();
        // generate texture and assign as main texture
        mr.material.mainTexture = UnityLibrary.GradientTextureMaker.Create(colors, wrapMode, filterMode, isLinear, hasMipMap);
    }
}
