using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BolaController : MonoBehaviour
{

    private Vector2 bolaVelocidade;
    public Rigidbody2D meuRB;
    public float limiteHorizontal = 12f;
    public float velocidade = 5f;
    public AudioClip boing;
    public Transform transformCamera;
    public float delay = 2f;
    public bool jogoIniciado = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //iniciando bola com delay
        delay = delay - Time.deltaTime;

        if(delay <= 0 && jogoIniciado == false)
        {
            jogoIniciado = true;

            int direcao = Random.Range(0, 4);

            switch (direcao)
            {
                case 0:
                    bolaVelocidade.x = velocidade;
                    bolaVelocidade.y = velocidade;
                    break;
                case 1:
                    bolaVelocidade.x -= velocidade;
                    bolaVelocidade.y = velocidade;
                    break;
                case 2:
                    bolaVelocidade.x -= velocidade;
                    bolaVelocidade.y -= velocidade;
                    break;
                case 3:
                    bolaVelocidade.x = velocidade;
                    bolaVelocidade.y -= velocidade;
                    break;
            }

            meuRB.velocity = bolaVelocidade;
        }

        if (transform.position.x > limiteHorizontal || transform.position.x < -limiteHorizontal)
        {
            SceneManager.LoadScene("Jogo");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boing, transformCamera.position);
    }
}
