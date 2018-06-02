using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
        image.color = new Color(1, v, 0);
        if (Time < 25 && Time != System.Int32.Parse(text.text))
            text.transform.DOScale(1.25f, .125f).SetLoops(2, LoopType.Yoyo);
        text.text = ((Time / 60 > 0) ? (Time / 60).ToString() + ':' : "") + (Time % 60).ToString();  
    }
}
