using UnityEngine;
using System.Collections;

public class InventoryTestLoad : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        var inv = GameObject.Find("InventoryTest");
        inv.transform.SetParent(transform);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
