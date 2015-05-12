using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {
	public Texture2D CellTexture;
	public int CellCount;
	List<CollectableItem> mItems = new List<CollectableItem>();

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
			Texture2D itemImage = mItems [i].texture;
			GUI.DrawTexture (new Rect (coord.x + i * CellTexture.width, coord.y, itemImage.width, itemImage.height), itemImage);
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
		if(mItems.Count < CellCount)
			mItems.Add (item);
	}

}
