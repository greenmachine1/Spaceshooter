using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

    public Image fadingImage;
    public float fadeRate;
    private Color alphaColor;
    private Image fImage;
    private void Awake()
    {
        fImage = fadingImage.GetComponent<Image>();
        alphaColor = fImage.color;
        alphaColor.a = 1f;
    }


    void Update () {
        alphaColor.a -= fadeRate;
        fImage.color = alphaColor;

        if(alphaColor.a <= 0)
        {
            fadingImage.enabled = false;
        }


	}
}
