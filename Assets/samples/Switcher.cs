using UnityEngine;
using System.Collections;

public class Switcher : MonoBehaviour {
	public string TargetScene = "";

	void OnMouseDown()
	{
		Application.LoadLevel(TargetScene);
	}
}
