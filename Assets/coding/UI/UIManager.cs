using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
   [SerializeField] private GameObject gameOverScreen;
   [SerializeField] private AudioClip gameOverSound;

   [SerializeField] private GameObject pauseScreen;

   [SerializeField] private GameObject WinGameScreen;
   [SerializeField] private AudioClip WinGameSound;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        WinGameScreen.SetActive(false);

    }
    
    #region Game over
    public void GameOver()
    {
        //panel game over menyala
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        //mengulang game jika kehabisan health point
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        //kembali ke main menu
        SceneManager.LoadScene(0);
    }
    
    public void Quit()
    {
        //keluar game
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //keluar saat game mode di unity
        #endif
    }
    #endregion

    #region Pause Game
    public void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            // untuk panel pause pada game objek menyala
            PauseGame(!pauseScreen.activeInHierarchy);
        }

    }

    public void PauseGame(bool status)
    {
        //agar game berhenti
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void SoundVolume()
    {
        //merubah volume sfx angkanya saja
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }

    public void MusicVolume()
    {
        //merubah volume musik angkanya saja
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }

    #endregion

    #region Game Win
    public void GameWin()
    {
        //menaplikan panel game win
        WinGameScreen.SetActive(true);
        SoundManager.instance.PlaySound(WinGameSound);
        Time.timeScale = 0;
    }
    #endregion
}
