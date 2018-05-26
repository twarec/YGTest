using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimeGameFill : MonoBehaviour {
    Image image;
    public Text text;
    private void Start()
    {
        image = GetComponent<Image>();
        GameManager.gameManager.UpdateTimeGameAction += UpdateFill;
    }
    private void OnDestroy()
    {
        GameManager.gameManager.UpdateTimeGameAction -= UpdateFill;
    }
    private void UpdateFill(float v, int Time)
    {
        image.fillAmount = v;
        text.text = ((v / 60 > 0) ? (Time / 60).ToString() + ':' : "") + (Time % 60).ToString();  
    }
}
