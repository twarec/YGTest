using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadLiderBoard : MonoBehaviour {
    private void Start()
    {
        List<int> vs = Liderboard.GetLiderboard();
        if (vs.Count > 0)
        {
            transform.GetChild(0).GetComponent<Text>().text = vs[0].ToString();
            for(int i = 1; i < vs.Count; i++)
            {
                Text text = Instantiate(transform.GetChild(0), transform).GetComponent<Text>();
                text.text = vs[i].ToString();
            }
        }
        else
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, 50 * vs.Count);
    }
}
