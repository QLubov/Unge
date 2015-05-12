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
	void OnGUI () {
		Rect rect = mSpriteRenderer.sprite.rect;
		rect.position = Inventory.GetScreenSpace(transform.position);
		GUI.Label (rect, "BLABLABLA!!1");
	}
	// Update is called once per frame
	void Update () {
		if (mSpriteRenderer.enabled && Input.GetMouseButtonDown (0)) {
			Rect rect = mSpriteRenderer.sprite.rect;
			rect.position = Inventory.GetScreenSpace(transform.position);
			rect.position -= new Vector2(rect.width/2, rect.height/2);
			if(rect.Contains(Input.mousePosition))
			{
				mInventory.Add(this);
				mSpriteRenderer.enabled = false;
			}
		}
	}
}
