using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {
	public Sprite State1 = null;
	public Sprite State2 = null;
	SpriteRenderer mRenderer;
	Sprite prev = null;
	Sprite next = null;
	// Use this for initialization
	void Start ()
	{
		mRenderer = GetComponent<SpriteRenderer> ();
		mRenderer.sprite = State1;
		next = State2;
		prev = State1;
	}
	
	// Update is called once per frame
	void OnMouseDown () 
	{
		mRenderer.sprite = next;
		next = prev;
		prev = mRenderer.sprite;
	}
}
