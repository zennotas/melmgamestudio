using UnityEngine;
using System.Collections;

public class Gun {
	public int Bullets { get; private set; }
	public GameObject GunObject { get; private set; }
	public GameObject FlashLight { get; private set; }
	public bool FlashLightMode { get; set; }

	public Gun (int bullets, GameObject gunObject, GameObject flashLight, bool flashLightMode) {
		Bullets = bullets;
		GunObject = gunObject;
		FlashLight = flashLight;
		FlashLightMode = flashLightMode;
	}

	public void ToggleFlashLight(bool mode) {
		FlashLight.SetActive (mode);
	}
}
