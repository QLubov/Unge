using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryTest : MonoBehaviour {
    [Range(0.0f, 10.0f)]
    public float offset = 0.0f;
    public float cellSize = 64.0f;
    public int cellCount = 4;
    public GameObject slotPref = null;
    List<GameObject> slots = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        float invWidth = cellCount * cellSize + cellCount * offset + offset;
        float invHeight = cellSize + 2 * offset;
        RectTransform rect = GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, invWidth);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invHeight);

        for (int i = 0; i < cellCount; i++)
        {
            GameObject slot = Instantiate<GameObject>(slotPref);
            

            RectTransform slotRect = slot.GetComponent<RectTransform>();
            //slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cellSize);
            //slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cellSize);
            slot.transform.parent = transform;
            //slotRect.localPosition = rect.localPosition + new Vector3(offset + i * cellSize, 0);
            //
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
