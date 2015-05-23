using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Pair<T, U> {
	public Pair() {
	}
	
	public Pair(T first, U second) {
		this.First = first;
		this.Second = second;
	}
	
	public T First { get; set; }
	public U Second { get; set; }
};

public class Inventory : MonoBehaviour {
	public int labelOffset = 1;
	public Texture2D CellTexture;
	public int CellCount;
	List<Pair<CollectableItem, int>> mItems = new List<Pair<CollectableItem, int>>();

	void Start () {
		
	}
	void OnGUI() {
		DrawInventory ();
		DrawInventoryItems ();
	}
	// Update is called once per frame
	void Update () {
	}

	private void DrawInventory () {
		if (CellTexture == null)
			return;
		Vector3 coord = GetScreenSpace (transform.position);
		for (int i = 0; i < CellCount; i++) {
			GUI.DrawTexture(new Rect(coord.x + i*CellTexture.width, coord.y, CellTexture.width, CellTexture.height), CellTexture);
		}
	}

	void DrawInventoryItems () {
		Vector3 coord = GetScreenSpace (transform.position);
		for (int i = 0; i < mItems.Count; i++) {
			Texture2D itemImage = mItems [i].First.texture;
			Rect pos = new Rect (coord.x + i * CellTexture.width, coord.y, itemImage.width, itemImage.height);

			GUI.DrawTexture (pos, itemImage);

			pos.position += new Vector2(0, labelOffset);
			GUI.Label(pos, "" + mItems[i].Second);
		}
	}

	void OnDrawGizmos () {
		DrawInventory ();
	}

	public static Vector3 GetScreenSpace (Vector3 position) {
		Vector3 coord = Camera.main.WorldToScreenPoint (position);
		coord.y = Screen.height - coord.y;
		return coord;
	}

	public void Add (CollectableItem item) {
		if (mItems.Count >= CellCount)
			return;
		for (int i = 0; i < mItems.Count; i++) {
			if (item.gameObject.name == mItems[i].First.gameObject.name){
				mItems[i].Second++;
				return;
			}
		}
		mItems.Add (new Pair<CollectableItem, int> (item, 1));
	}

}
