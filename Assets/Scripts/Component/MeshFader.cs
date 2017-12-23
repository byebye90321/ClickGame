using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFader : MonoBehaviour
{
    public Renderer[] fadeRenderers;
    public float speed = 1f;

    [ContextMenu("Text FadeIn")]
    private void TestIn()
    {
        StartCoroutine(FadeIn());
    }

    [ContextMenu("Text FadeOut")]
    private void TestOut()
    {
        StartCoroutine(FadeOut());
    }


    public IEnumerator FadeIn()
    {
        float alpha = 0;
        for (int i = 0; i < fadeRenderers.Length; i++)
        {
            Color color = fadeRenderers[i].material.color;
            color.a = alpha;
            fadeRenderers[i].material.color = color;
        }
        while (alpha < 1)
        {
            alpha += Time.deltaTime * speed;
            alpha = Mathf.Min(1, alpha);
            for (int i = 0; i < fadeRenderers.Length; i++)
            {
                Color color = fadeRenderers[i].material.color;
                color.a = alpha;
                fadeRenderers[i].material.color = color;
            }
            yield return null;
        }
    }



    public IEnumerator FadeOut()
    {
        float alpha = 1;
        for (int i = 1; i > fadeRenderers.Length; i--)
        {
            Color color = fadeRenderers[i].material.color;
            color.a = alpha;
            fadeRenderers[i].material.color = color;
        }
        while (alpha > 0)
        {
            alpha += Time.deltaTime * speed;
            alpha = Mathf.Max(0, alpha);
            for (int i = 1; i > fadeRenderers.Length; i--)
            {
                Color color = fadeRenderers[i].material.color;
                color.a = alpha;
                fadeRenderers[i].material.color = color;
            }
            yield return null;
        }
    }
}
