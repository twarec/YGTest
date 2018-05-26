using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PointsText : MonoBehaviour {
    private Text text;
    private void Start()
    {
        text = GetComponent<Text>();
        GameManager.gameManager.UpdatePoint += UpdateText;
    }
    private void OnDestroy()
    {
        GameManager.gameManager.UpdatePoint -= UpdateText;
    }
    private void UpdateText(int v)
    {
        text.text = v.ToString();
    }
}
