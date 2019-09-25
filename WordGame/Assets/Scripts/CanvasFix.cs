using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class CanvasFix : MonoBehaviour {

    public CanvasScaler canvasScaler;

    private void Start()
    {
        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);
    }

    public void ContiuousFocus()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    public void TriggerFocus()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
    }

    public void MacroFocus()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_MACRO);
    }

    public void NormalFocus()
    {
        CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_NORMAL);
    }
}
