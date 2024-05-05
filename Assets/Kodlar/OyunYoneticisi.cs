using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunYoneticisi : MonoBehaviour
{
    public void Basla()
    {
        SceneManager.LoadScene(1);
    }
    public void Devam()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("kalan"));
    }
    public void Cikis()
    {
        Application.Quit();
    }
}
