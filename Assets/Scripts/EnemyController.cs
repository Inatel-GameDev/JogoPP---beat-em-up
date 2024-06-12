using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("General References")]
    [SerializeField]private Rigidbody2D oRigidbody2D;
    
    [SerializeField]private SpriteRenderer oSpriteRenderer;
    private GameObject oPlayer;
    
    [Header("Enemy Movement")]
    [SerializeField] private float enemySpeed;
    private Vector2 movementDirection;
    [SerializeField]private float atackDistance;



    private void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();    
        oPlayer = FindObjectOfType<PlayerController>().gameObject;             //referencia do jogador
    }

    private void Update()
    {
        Chase();
        EspelharInimigo();
    }


    private void EspelharInimigo(){

        if(oRigidbody2D.position.x < 0){
            oSpriteRenderer.flipX = false;
        }
        else if(oRigidbody2D.position.x > 0){
            oSpriteRenderer.flipX = true;
        }
    }
    
    private void Chase(){

        //se estiver distante = segue,  else = ataca
        if(Vector2.Distance(transform.position,oPlayer.transform.position) > atackDistance){

            //onde inimigo tem que ir = onde ta o player - onde ta o inimigo
            movementDirection = (oPlayer.transform.position - transform.position).normalized;
            oRigidbody2D.velocity = movementDirection * enemySpeed;

        }
        else{
            oRigidbody2D.velocity = Vector2.zero;      //fica parado
        }

    }
}
