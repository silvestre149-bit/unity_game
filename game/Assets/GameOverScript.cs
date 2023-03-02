using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverScreen;

    private bool gameover = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("Personagem colidiu com a água");
            gameover = true;
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Update()
    {
        if (gameover && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
