using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class C_Options : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resDrop;

    public Dropdown qDrop;

    Resolution[] res;

    private void Start()
    {
        res = Screen.resolutions;

        resDrop.ClearOptions();

        List<string> options = new List<string>();
        int currentRes = 0;
        for(int i = 0; i < res.Length; i++)
        {
            string p = res[i].width.ToString() + " x " + res[i].height.ToString();
            options.Add(p);
            if(res[i].width == Screen.currentResolution.width && res[i].height == Screen.currentResolution.height) currentRes = i;
        }
        resDrop.AddOptions(options);
        resDrop.value = currentRes;
        resDrop.RefreshShownValue();

        qDrop.value = QualitySettings.GetQualityLevel();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution r = res[resolutionIndex];
        Screen.SetResolution(r.width,r.height,Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVol", volume);
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
