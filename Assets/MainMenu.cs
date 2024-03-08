using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] SceneFader fader;

    public void Play()
    {
        fader.FadeOn(1);
        Debug.Log("button pressed");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
