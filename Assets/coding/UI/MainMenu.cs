using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void pilihLevel()
    {
        SceneManager.LoadScene("_Pilih_Level");
    }

    public void Bantuan()
    {
        SceneManager.LoadScene("Bantuan");
    }

    public void Pengaturan()
    {
        SceneManager.LoadScene("Pengaturan");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
