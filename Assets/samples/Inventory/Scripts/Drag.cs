using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    Vector3 start;
    Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        start = transform.position;
        startParent = gameObject.transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //transform.parent.GetComponent<GridLayoutGroup>().enabled = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var pos = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        pos.z = 50.0f;
        transform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject.transform.parent == startParent)
            transform.position = start;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //transform.parent.GetComponent<GridLayoutGroup>().enabled = true;
    }
}
