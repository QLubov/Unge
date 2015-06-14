using UnityEngine;
using System.Collections;

public class CallectableTest : MonoBehaviour {
    public Sprite collected;
    InventoryTest inv;
	// Use this for initialization
	void Start ()
    {
        inv = GameObject.Find("InventoryTest").GetComponent<InventoryTest>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}
    void OnMouseDown()
    {
        inv.AddItem(collected, gameObject.tag);
        Destroy(gameObject);
    }
}
