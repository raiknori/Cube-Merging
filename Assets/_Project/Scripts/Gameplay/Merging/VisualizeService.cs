using UnityEngine;

public class VisualizeService
{
    private Color minColor = new Color(0f, 0.3f, 0f);   //dark green
    private Color maxColor = new Color(0.5f, 0f, 0f);   //dark red
    public void VisualizeMerge(IMergeable mergeable)
    {
        UpdateText(mergeable);
        UpdateColor(mergeable);
    }

    void UpdateText(IMergeable mergeable)
    {
        foreach (var edgeText in mergeable.EdgesText)
        {
            edgeText.SetText($"{mergeable.Value}");
        }
    }

    void UpdateColor(IMergeable mergeable)
    {

        if (mergeable.Value <= 2)
        {
            mergeable.Renderer.material.color = minColor;
            return;
        }

        float c = Mathf.Log(mergeable.Value, 2) / Mathf.Log(2048, 2);
        c = Mathf.Clamp01(c);

        Color newColor = Color.Lerp(minColor, maxColor, c);
        mergeable.Renderer.material.color = newColor;
    }
}