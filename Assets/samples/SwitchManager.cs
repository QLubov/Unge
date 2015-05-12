using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SwitchManager : MonoBehaviour {
	public string TargetScene = "";

	public void SwitchScene(){
		//BinaryFormatter binFormat = new BinaryFormatter();
		// Сохранить объект в локальном файле.
		//using(Stream fStream = new FileStream("user.dat", FileMode.Create, FileAccess.Write, FileShare.None))
		//{
		//	binFormat.Serialize(fStream, GameObject.Find("Inventory").GetComponent<InventoryView>());
		//}
		Application.LoadLevel(TargetScene);
	}
}
