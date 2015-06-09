using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour {

    public Sprite state1 = null;
    public Sprite state2 = null;
    SpriteRenderer rnd;

	// Use this for initialization
	void Start ()
    {
        rnd = GetComponent<SpriteRenderer>();
        rnd.sprite = state1;
	}
	
	// Update is called once per frame
	void OnMouseDown ()
    {
        if (rnd.sprite == state1)
            rnd.sprite = state2;
        else
            rnd.sprite = state1;
	}
}
