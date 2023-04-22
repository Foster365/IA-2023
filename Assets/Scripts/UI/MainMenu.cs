using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private String leveName;
    public void OnStartPlay()
    {
        SceneManager.LoadScene(leveName);
    }

    public void OnQuitAplication()
    {
        Application.Quit();
    }
}
