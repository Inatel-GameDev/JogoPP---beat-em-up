using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("General References")]
    [SerializeField] private Rigidbody2D oRigidbody2D;

    [SerializeField] private SpriteRenderer oSpriteRenderer;
    private GameObject oPlayer;
    private Animator oAnimator;

    [Header("Enemy Movement")]
    [SerializeField] private float enemySpeed;
    private Vector2 movementDirection;

    [Header("Enemy Attack")]
    [SerializeField] private float attackCooldown;
    private float currentCooldown;
    private bool canAttack;
    [SerializeField] private float attackDistance;
    [SerializeField] private int amountOfEnemyAttack;       //quantos ataques tem disponivel
    private int currentEnemyAttack;        //ataque escolhido




    private void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
        oPlayer = FindObjectOfType<PlayerController>().gameObject;             //referencia do jogador
    }

    private void Update()
    {
        if (GetComponent<EnemyLife>().isEnemyAlive)
        {
            CoolDownController();
            Chase();
            EspelharInimigo();
        }
        else{
            DefeatAnimation();
        }
    }


    private void EspelharInimigo()
    {

        if (oPlayer.transform.position.x > transform.position.x)
        {
            //oSpriteRenderer.flipX = true;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            //oSpriteRenderer.flipX = false;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Chase()
    {

        //se estiver distante = segue,  else = ataca
        if (Vector2.Distance(transform.position, oPlayer.transform.position) > attackDistance)
        {

            //onde inimigo tem que ir = onde ta o player - onde ta o inimigo
            movementDirection = (oPlayer.transform.position - transform.position).normalized;
            oRigidbody2D.velocity = movementDirection * enemySpeed;

            oAnimator.SetTrigger("andando");
        }
        //para e começa a atacar
        else
        {
            oRigidbody2D.velocity = Vector2.zero;
            oAnimator.SetTrigger("parado");

            ChooseAttack();
        }

    }

    //escolher ataque de forma aleatorio
    private void ChooseAttack()
    {
        currentEnemyAttack = Random.Range(0, amountOfEnemyAttack);  //escolhe um ataque no intervalo entre a e b, b é exclusivo
        if (canAttack)
        {
            Attacking();  //escolhe ataque
        }
    }

    //define qual ataque
    private void Attacking()
    {

        switch (currentEnemyAttack)
        {
            case 0:
                oAnimator.SetTrigger("punch");
                break;
            case 1:
                oAnimator.SetTrigger("super-punch");
                break;
        }

        canAttack = false;

    }

    private void CoolDownController()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0)
        {
            canAttack = true;
            currentCooldown = attackCooldown;
        }
    }

    public void EnemyDamageAnimation()
    {
        oAnimator.SetTrigger("taking-damage");
    }

    public void DefeatAnimation()
    {
        oAnimator.Play("defeat-bill");  //testando o play ao invez do trigger 
        oRigidbody2D.velocity = Vector2.zero;
    }
}

