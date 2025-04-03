using System.Collections;
using UnityEngine;

public class TitleLogo : MonoBehaviour
    {
    private Renderer logoRenderer;
    private Color originalColor;

    void Start()
        {
        logoRenderer = GetComponent<Renderer>();
        if (logoRenderer != null)
            {
            originalColor = logoRenderer.material.color;
            }
        StartCoroutine(FlickerEffect());
        }

    IEnumerator FlickerEffect()
        {
        while (true)
            {
            float flickerInterval = Random.Range(0.05f, 0.2f);
            float alpha = Random.Range(0.2f, 1.0f);
            Color flickerColor = originalColor;
            flickerColor.a = alpha;
            logoRenderer.material.color = flickerColor;
            yield return new WaitForSeconds(flickerInterval);
            }
        }
    }
