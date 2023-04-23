using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangorraScript : MonoBehaviour
{
    public float force = 100f; // a força aplicada à gangorra
    public float threshold = 0.1f; // a inclinação máxima permitida antes de desequilibrar a gangorra
    public float resetTime = 2f; // tempo em segundos para reiniciar o jogo após a queda do personagem
    public GameObject character; // o objeto do personagem controlado pelo jogador
    public GameObject gameOverScreen; // o objeto da tela de game over

    private bool gameover = false; // flag para indicar se o jogo acabou
    private float timer = 0f; // temporizador para reiniciar o jogo após a queda do personagem

    void Update()
    {
        if (!gameover)
        {
            // verifica se o personagem está em cima da gangorra
            if (character.transform.position.y > transform.position.y)
            {
                // aplica uma força na direção do personagem para equilibrar a gangorra
                Vector3 direction = character.transform.position - transform.position;
                GetComponent<Rigidbody>().AddForce(direction.normalized * force * Time.deltaTime);
            }

            // obtém a inclinação atual da gangorra
            float angle = transform.rotation.eulerAngles.z;

            // verifica se a inclinação ultrapassou o limite permitido
            if (angle > 180)
            {
                angle = angle - 360;
            }

            if (Mathf.Abs(angle) > threshold)
            {
                // aplica uma força na direção oposta à inclinação para equilibrar a gangorra
                GetComponent<Rigidbody>().AddTorque(new Vector3(0, 0, -angle) * force * Time.deltaTime);
            }

            // verifica se o personagem caiu do iceberg
            if (character.transform.position.y < transform.position.y - 1)
            {
                gameover = true;
                gameOverScreen.SetActive(true);
            }
        }
        else
        {
            // aguarda um tempo antes de reiniciar o jogo após a queda do personagem
            timer += Time.deltaTime;
            if (timer >= resetTime)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
    }
}
#Teste
