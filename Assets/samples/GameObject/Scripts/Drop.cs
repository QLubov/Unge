using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.tag == "minion")
            Debug.Log("OnDrop minion!");
        else
            Debug.Log("OnDrop something1");

    }
}
