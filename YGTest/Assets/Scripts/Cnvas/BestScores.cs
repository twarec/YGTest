using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BestScores : MonoBehaviour {
    private void Start()
    {
        GetComponent<Text>().text = Liderboard.GetLiderboard()[0].ToString();
    }
}
