using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PilihLevel : MonoBehaviour
{
    public void level1()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void level2()
    {
        SceneManager.LoadScene("Level_2");
    }

    public void level3()
    {
        SceneManager.LoadScene("Level_3");
    }

    public void kembali()
    {
        SceneManager.LoadScene(0);
    }
}
