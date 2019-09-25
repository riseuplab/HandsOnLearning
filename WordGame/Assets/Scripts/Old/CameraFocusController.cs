using UnityEngine;
using System.Collections;
using Vuforia;

public class CameraFocusController: MonoBehaviour {
	void Start() {    
		var vuforia = VuforiaARController.Instance;    
		vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);    
		
	}  


	private void OnVuforiaStarted() {    
		CameraDevice.Instance.SetFocusMode(
			CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
	}

}