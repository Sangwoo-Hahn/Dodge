using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineWidthChange2 : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float startWidth = 1.0f;
    public float endWidth = 0.1f;
    public float duration = 1.0f;

    public void Change()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }

        lineRenderer.startWidth = startWidth;
        lineRenderer.endWidth = startWidth;

        StartCoroutine(ChangeLineWidthOverTime());
    }

    private IEnumerator ChangeLineWidthOverTime()
    {
        float elapsedTime = 0.0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float currentWidth = Mathf.Lerp(startWidth, endWidth, t);

            lineRenderer.startWidth = currentWidth;
            lineRenderer.endWidth = currentWidth;

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        lineRenderer.startWidth = endWidth;
        lineRenderer.endWidth = endWidth;
    }
}
