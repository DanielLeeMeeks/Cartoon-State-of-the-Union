using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour {

    public Canvas debugCanvas;
    public Dropdown resPicker;
    public GameObject settingsGO;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleDebug();
        }
	}

    public void SettingsUp()
    {
        QualitySettings.IncreaseLevel(true);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void SettingsDown()
    {
        QualitySettings.DecreaseLevel(true);
        Debug.Log(QualitySettings.GetQualityLevel());
    }

    public void SetResolution()
    {
        if (resPicker.value == 0)
        {
            Screen.SetResolution(640, 480, true);
            debugCanvas.scaleFactor = 0.5f;
        }
        else if (resPicker.value == 1)
        {
            Screen.SetResolution(1280, 720, true);
            debugCanvas.scaleFactor = 1;
        }
        else if (resPicker.value == 2)
        {
            Screen.SetResolution(1920, 1080, true);
            debugCanvas.scaleFactor = 2;
        }
        else if (resPicker.value == 3)
        {
            Screen.SetResolution(3840, 2160, true);
            debugCanvas.scaleFactor = 4;
        }
        else if (resPicker.value == 4)
        {
            Screen.SetResolution(7680, 4320, true);
            debugCanvas.scaleFactor = 8;


        }
        else if (resPicker.value == 5)
        {
            Screen.SetResolution(640, 480, false);
            debugCanvas.scaleFactor = 0.5f;
        }
        else if (resPicker.value == 6)
        {
            Screen.SetResolution(1280, 720, false);
            debugCanvas.scaleFactor = 1;
        }
        else if (resPicker.value == 7)
        {
            Screen.SetResolution(1920, 1080, false);
            debugCanvas.scaleFactor = 2;
        }
        else if (resPicker.value == 8)
        {
            Screen.SetResolution(3840, 2160, false);
            debugCanvas.scaleFactor = 4;
        }
        else if (resPicker.value == 9)
        {
            Screen.SetResolution(7680, 4320, false);
            debugCanvas.scaleFactor = 8;
        }

        debugCanvas.scaleFactor = 2;
    }

    public void toggleDebug()
    {
        if (settingsGO.activeSelf)
        {
            settingsGO.SetActive(false);
        }
        else
        {
            settingsGO.SetActive(true);
        }
    }
}
