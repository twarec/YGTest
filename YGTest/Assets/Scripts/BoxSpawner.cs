using UnityEngine;
using DG.Tweening;

public class BoxSpawner : MonoBehaviour {
    public DragBox dragBoxPrefab;
    private DragBox dragBox;
    public DragBox DragBox
    {
        get
        {
            return dragBox;
        }
        set
        {
            if(value == null)
                initializationBox(); 
            else
                dragBox = value;
        }
    }
    public void initializationBox()
    {
        var dbi = Instantiate(dragBoxPrefab, transform);
        dbi.transform.position = transform.position;
        dbi.gameObject.AddComponent<DestroyAction>().DestroyA += () =>
        {
            DragBox = null;
            GameManager.Point++;
        };
        DragBox = dbi;
        ColorRandom.colorRandom.BoxColorRandomizer(dbi.GetComponent<SpriteRenderer>());
        dbi.transform.localScale = Vector3.zero;
        dbi.transform.DOScale(Vector3.one, .25f);
    }
}
