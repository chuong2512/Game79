using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateApp : MonoBehaviour
{
    public void OnClickRateUs()
    {
        PlayerPrefs.SetInt("Rate", 1);
        Application.OpenURL("market://details?id=" + Application.identifier);
    }
    public void OnClickPrivacy()
    {
        Application.OpenURL("");
    }
}
