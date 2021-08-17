using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject options;
    public void Main()
    {
        main.SetActive(true);
        options.SetActive(false);
    }
    public void Options()
    {
        main.SetActive(false);
        options.SetActive(true);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
