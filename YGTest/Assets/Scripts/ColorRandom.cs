using UnityEngine;
using DG.Tweening;

public class ColorRandom : MonoBehaviour {
    public Color[] colors;
    public SpriteRenderer[] circles;
    public BoxSpawner[] boxeSpawners;
    public static ColorRandom colorRandom;
    private void Awake()
    {
        colorRandom = this;
    }
    public void CirlesColorRandomizer()
    {
        for(int i = 0; i < circles.Length; i++)
        {
            var color = colors[Random.Range(0, colors.Length)];
            bool ActiveColor = true;
            for (int j = 0; j < circles.Length; j++)
            {
                if (circles[j].color == color)
                {
                    ActiveColor = false;
                    break;
                }
            }
            if (!ActiveColor)
            {
                i--;
                continue;
            }
            circles[i].color = color;
        }
    }
    public void CirleColorRandomizer(SpriteRenderer spriteRenderer)
    {
        while (true)
        {
            var color = colors[Random.Range(0, colors.Length)];
            bool ActiveColor = true;
            for (int j = 0; j < circles.Length; j++)
            {
                if (circles[j].color == color)
                {
                    ActiveColor = false;
                    break;
                }
            }
            if (ActiveColor)
            {
                spriteRenderer.color = color;
                break;
            }
        }
    }
    public void BoxColorRandomizer(SpriteRenderer spriteRenderer)
    {
        while (true)
        {
            var color = colors[Random.Range(0, colors.Length)];
            bool ActiveColor = true;
            for (int j = 0; j < boxeSpawners.Length; j++)
            {
                if (boxeSpawners[j].DragBox && boxeSpawners[j].DragBox.GetComponent<SpriteRenderer>().color == color)
                {
                    ActiveColor = false;
                    break;
                }
            }
            if (ActiveColor)
            {
                spriteRenderer.color = color;
                break;
            }
        }
    }
    public void LoadColor()
    {
        colors = GameManager.GetColors();
    }
    public bool FindColorIsCircle(Color color)
    {
        foreach (var v in circles)
            if (v.color == color)
                return true;
        return false;
    }
}
