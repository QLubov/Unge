using UnityEngine;
using System.Collections;

public class CollectableItem : MonoBehaviour {
	public Texture2D texture;
	SpriteRenderer mSpriteRenderer;
	Inventory mInventory;
	
	// Use this for initialization
	void Start () {
		mSpriteRenderer = GetComponent<SpriteRenderer> ();
		mInventory = GameObject.Find ("Inventory").GetComponent<Inventory>();
	}
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown () {
	
		if (mSpriteRenderer.enabled) {
			mSpriteRenderer.enabled = false;
			mInventory.Add(this);
		}
	}
}