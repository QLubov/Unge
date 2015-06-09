using UnityEngine;
using System.Collections;

public class RTCreator : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        string pName = "sharik";
        GameObject obj = new GameObject();

        var sprite = Resources.Load<Sprite>(pName);
        var sRenderer = obj.AddComponent<SpriteRenderer>();
        sRenderer.sprite = sprite;

        obj.transform.SetParent(transform, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
