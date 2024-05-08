using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle fullscreenTog, vsyncTog;

    public ResItem[] resolutions;

    [SerializeField]
    private int selectedResolution;

    public TextMeshProUGUI resolutionLabel;

    private void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
        
        if(QualitySettings.vSyncCount == 0)
        {
            vsyncTog.isOn = false;
        }
        else
        {
            vsyncTog.isOn = true;
        }

        // Search for resolution in list
        bool foundRes = false;

        for (int i = 0; i < resolutions.Length ; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true; 
                
                selectedResolution = i;
                UpdateResLabel();
            }
        }

        if (!foundRes)
        {
            resolutionLabel.text = Screen.width.ToString() + " x " +Screen.height.ToString();
        }
    }

    public void ResLeft()
    {
        selectedResolution--;

        if(selectedResolution < 0)
        {
            selectedResolution = 0;
        }

        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;

        if(selectedResolution > resolutions.Length - 1)
        {
            selectedResolution = resolutions.Length - 1;
        }
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }

    public void ApplyGraphics()
    {
        // Apply fullscreen
        Screen.fullScreen = fullscreenTog.isOn;
        if(vsyncTog.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }

        // Set resolution
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }
}


[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}