using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes_Test : MonoBehaviour
{
    public static Scenes_Test Instance;
    public float duration;
    public Image image;
    public Image image2;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(ImageFadeIn(image2, 0, duration));
        
    }
    public void LoadEndScene()
    {
        StartCoroutine(ImageFade(image, 1, duration));
        LeanTween.delayedCall(3f, () => { SceneManager.LoadScene(3); });
      
    }
    void Update()
    {

    }

    public IEnumerator ImageFade(
Image sr,
float endValue,
float duration)
    {
        float elapsedTime = 0;
        float startValue = sr.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }
    public IEnumerator ImageFadeIn(
Image sr,
float endValue,
float duration)
    {
        float elapsedTime = 0;
        float startValue = sr.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }
}