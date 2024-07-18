using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General References")]                          //headers para ajudar na organizaçao de variaveis do ponto de vista do unity
    private Rigidbody2D oRigidbody2D;
    private Animator oAnimator;

    [Header("Player Movement")]
    [SerializeField] private float playerSpeed;             //velocidade em que o jogador se move
    private Vector2 movementInput;                          //entrada de movimento
    private Vector2 movementDirection;                      //qual direçao x e y o jogador ira andar

    [Header("AttackController")]
    [SerializeField] private float tempoMaxEntreAtaques;     //tempo de espera entre um ataque e outro
    private float tempoAtualEntreAtaques;                   //quanto tempo passou desde o ultimo ataque
    private bool podeAtacar;

    [Header("Damage Controller")]
    [SerializeField] private float tempoMaximoDoDano;
    private float tempoAtualDoDano;
    private bool levouDano;


    private void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();

        tempoAtualDoDano = tempoMaximoDoDano;
    }

    private void Update()
    {
        if (GetComponent<PlayerLife>().isPlayerAlive)
        {
            CronometroDeAtaque();
            if (!levouDano)
            {
                ReceiveInputs();
                PlayerMove();
                EspelharPlayer();
                PlayerAnimations();
            }
            else
            {
                CronometroDeDano();
            }
        }
        else{
            DefeatAnimation();
        }
    }



    private void ReceiveInputs()
    {

        // Armazena a direção que o jogador define
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    //funçao que inverte o gameobject dependendo da direçao do movimento
    private void EspelharPlayer()
    {

        //se direita 
        if (movementInput.x == 1)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        //se esquerda
        else if (movementInput.x == -1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);    //alterando somente eixo x
        }
    }

    private void PlayerMove()
    {

        //movimenta o jogador com base na direçao
        movementDirection = movementInput.normalized;            //.normalized para manter a velocidade ao andar em diagonal
        oRigidbody2D.velocity = movementDirection * playerSpeed;

    }

    //variavel para rodar animação de receber dano e zera a velocidade do jogador
    public void DamageAnimation()
    {
        oAnimator.SetTrigger("taking-damage");
        levouDano = true;

        oRigidbody2D.velocity = Vector2.zero;
    }

    private void PlayerAnimations()
    {

        //animaçoes de movimento (Parado e andando)
        if (movementInput.magnitude == 0)
        {                    //magnitude retorna o vetor resultante
            oAnimator.SetTrigger("parado");
        }
        else if (movementInput.magnitude != 0)
        {
            oAnimator.SetTrigger("walking");
        }

        //animaçoes de ataque (soco e chute)
        if (Input.GetKeyDown(KeyCode.Q) && podeAtacar)
        {
            oAnimator.SetTrigger("socando");
            podeAtacar = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && podeAtacar)
        {
            oAnimator.SetTrigger("chutando");
            podeAtacar = false;
        }

    }

    public void DefeatAnimation()
    {
        oAnimator.Play("player-defeated");
    }


    //funçao que coloca um cooldown nas skills
    private void CronometroDeAtaque()
    {
        tempoAtualEntreAtaques -= Time.deltaTime;       //time.deltatime permite controlar melhor o framerate e descontar x segundos a cada segundo

        if (tempoAtualEntreAtaques <= 0)
        {
            podeAtacar = true;
            tempoAtualEntreAtaques = tempoMaxEntreAtaques;
        }
    }

    //funçao que controla freeze ao levar dano
    private void CronometroDeDano()
    {
        tempoAtualDoDano -= Time.deltaTime;
        DamageAnimation();
        if (tempoAtualDoDano <= 0)
        {
            levouDano = false;
            tempoAtualDoDano = tempoMaximoDoDano;
        }
    }


}
