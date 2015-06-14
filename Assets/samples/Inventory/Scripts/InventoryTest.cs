using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class InventorySlot
{
    public GameObject Slot { get; private set; }
    public uint Count { get; private set; }
    GameObject mItem;
    float mCellSize;
    float mScaleFactor;

    public InventorySlot(GameObject slotPref, float offset, float cellSize, float position, float ScaleFactor = 14.0f)
    {
        Slot = GameObject.Instantiate<GameObject>(slotPref);

        RectTransform slotRect = Slot.GetComponent<RectTransform>();
        slotRect.localPosition = new Vector3(offset + position * (offset + cellSize) + cellSize / 2.0f, 0);
        slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, cellSize);
        slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cellSize);
        mCellSize = cellSize;
        mScaleFactor = ScaleFactor;
    }

    bool IsEmpty()
    {
        return Count == 0;
    }

    public bool AddItem(Sprite sprite, string tag)
    {
        if (mItem != null)
        {
            var img = mItem.GetComponent<Image>();
            if (img.sprite.GetHashCode() == sprite.GetHashCode()) //TODO: comparing by tag
            {
                Count++;
                UpdateLabel();
                return true;
            }
            return false;
        }
        else
        {
            mItem = new GameObject("Item");
            mItem.tag = tag;           
            var img = mItem.AddComponent<Image>();
            mItem.AddComponent<CanvasGroup>();
            mItem.AddComponent<Drag>();
            var rect = mItem.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, mCellSize - mScaleFactor);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, mCellSize - mScaleFactor);
            

            img.sprite = sprite;
            //Slot.GetComponent<Button>().targetGraphic = img;
            mItem.transform.SetParent(Slot.transform, false);
            mItem.transform.SetAsFirstSibling();
            Count++;
            UpdateLabel();
            return true;
        }
    }

    void UpdateLabel()
    {
        Slot.GetComponentInChildren<Text>().text = Convert.ToString(Count);
    }
}

public class InventoryTest : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float offset = 0.0f;
    public float leftOffset = 0.0f;
    public float cellSize = 64.0f;
    public int cellCount = 4;
    public GameObject slotPref = null;
    public GameObject itemPref = null;
    List<InventorySlot> slots = new List<InventorySlot>();

    // Use this for initialization
    void Start()
    {
        float invWidth = cellCount * cellSize + cellCount * offset + offset;
        float invHeight = cellSize + 2 * offset;
        RectTransform rect = GetComponent<RectTransform>();

        for (float i = -cellCount / 2.0f; i < cellCount / 2.0f; i += 1.0f)
        {
            var slot = new InventorySlot(slotPref, offset, cellSize, i);

            slot.Slot.transform.SetParent(transform, false);
            slots.Add(slot);
        }
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, invWidth);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invHeight);
        InitBorders(invHeight);
    }

    public void AddItem(Sprite sprite, string tag)
    {
        foreach (var slot in slots)
        {
            if (slot.AddItem(sprite, tag))
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    void InitBorders(float invHeight)
    {
        RectTransform lBorder = gameObject.transform.FindChild("Left Border").GetComponent<RectTransform>();
        RectTransform rBorder = gameObject.transform.FindChild("Right Border").GetComponent<RectTransform>();

        lBorder.localPosition = new Vector3((-cellCount / 2.0f) * (cellSize + offset) - (lBorder.rect.width / 2.0f), 0);
        rBorder.localPosition = new Vector3((cellCount / 2.0f) * (cellSize + offset) + (lBorder.rect.width / 2.0f), 0);
        lBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invHeight);
        rBorder.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, invHeight);
    }
}
