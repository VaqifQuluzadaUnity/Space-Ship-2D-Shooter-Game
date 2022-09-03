using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicBox.SaveManagement;

public class SaveManagerSingleton : MonoBehaviour
{
   public static SaveManagerSingleton instance;

	 public string shipsJsonFileName="defaultFile";

	 public string playerJsonFileName = "playerData";

	 public SaveManager saveManager;

	 

	 private void Awake()
	 {
			if(instance!=null && instance != this)
			{
				 Destroy(instance.gameObject);
			}
			instance = this;

			DontDestroyOnLoad(this);

			saveManager = new SaveManager(StorageMethod.JSON);

	 }
}
