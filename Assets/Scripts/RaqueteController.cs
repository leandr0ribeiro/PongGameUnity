using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaqueteController : MonoBehaviour
{
    //private
    private Vector3 minhaPosicao;
    private float posicaoY;
    private float velocidade = 5f;
    private float meuLimite = 3.5f;
    //public
    public bool player1;
    public bool automatico;
    public Transform transformBola;
    

    // Start is called before the first frame update
    void Start()
    {
        minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaVelocidade = velocidade * Time.deltaTime;
        minhaPosicao.y = posicaoY;
        transform.position = minhaPosicao;

        if (!automatico)
        {
            if (player1 == false && Input.GetKey(KeyCode.Return))
            {
                automatico = true;
            }
            if (player1 == false)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    posicaoY = posicaoY + deltaVelocidade;
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    posicaoY = posicaoY - deltaVelocidade;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.W))
                {
                    posicaoY = posicaoY + deltaVelocidade;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    posicaoY = posicaoY - deltaVelocidade;
                }
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                automatico = false;
            }
            posicaoY = Mathf.Lerp(posicaoY, transformBola.position.y, 0.02f);
        }

        if (posicaoY < -meuLimite)
        {
            posicaoY = -meuLimite;
        }
        else if (posicaoY > meuLimite)
        {
            posicaoY = meuLimite;
        }
    }
}
