using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private PlayerHealth playerhealth;
    private UIManager uiManager;
    public GameObject UI;

    private void Awake()
    {
        playerhealth = GetComponent<PlayerHealth>();
        uiManager = FindObjectOfType<UIManager>();
    }

    public void RespawnCheck()
    {   
        if (currentCheckpoint == null) 
        {
            uiManager.GameOver();
            return;
        }

        playerhealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint location
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("sentuh");
            
        }

         if (collision.gameObject.tag == "WIN")
        { 
        uiManager.GameWin();
        Time.timeScale = 0;
        collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
