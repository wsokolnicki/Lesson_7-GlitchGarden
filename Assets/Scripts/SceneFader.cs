using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{

    [SerializeField] float fadeSpeed = 1f;
    Image fadePanel;
    Color currentColor = Color.black;
    public static bool didFadeHappend = true;

    private void Start()
    {
        fadePanel = GetComponent<Image>();
    }

    private void Update()
    {
            FadeAScreen();
    }

    private void FadeAScreen()
    {
        if (didFadeHappend)
        {
            if (Time.timeSinceLevelLoad < fadeSpeed)
            {
                float alphaChange = Time.deltaTime / fadeSpeed;
                currentColor.a -= alphaChange;
                fadePanel.color = currentColor;
            }
            else
            {
                gameObject.SetActive(false);
                didFadeHappend = false;
            }
        }
        else
        {
            gameObject.GetComponent<Image>().enabled = false;
        }
    }

}
