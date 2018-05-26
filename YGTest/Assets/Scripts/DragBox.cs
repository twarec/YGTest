using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class DragBox : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    Vector3 startPos;
    SpriteRenderer spriteRenderer;
    float LastPressTime;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.pointerCurrentRaycast.worldPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Circle"))
            if (spriteRenderer.color == collision.GetComponent<SpriteRenderer>().color)
            {
                transform.SetParent(collision.transform);
                transform.DOLocalMove(Vector3.zero, .25f)
                    .OnKill(() =>
                    {
                        enabled = false;
                        transform.DOScale(Vector3.zero, .5f)
                        .OnKill(() =>
                        {
                            Destroy(gameObject);
                        }).SetEase(Ease.Linear);
                    });
            }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (LastPressTime != 0 && Time.time - LastPressTime < .5f)
        {
            if (!ColorRandom.colorRandom.FindColorIsCircle(spriteRenderer.color))
            {
                GetComponent<DestroyAction>().DestroyA = null;
                Destroy(gameObject);
                transform.parent.GetComponent<BoxSpawner>().DragBox = null;
            }
        }
        LastPressTime = Time.time;
    }
}
