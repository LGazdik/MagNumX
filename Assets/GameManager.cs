using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] SceneFader fader;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        
    }

    public void Restart()
    {
        fader.FadeOn(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        fader.FadeOn(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
