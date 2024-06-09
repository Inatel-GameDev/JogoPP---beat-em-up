using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Rigidbody2D oRigidbody2D;
    private GameObject oPlayer;
    
    [SerializeField] private float enemySpeed;
    private Vector2 movementDirection;


    private void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();    
        oPlayer = FindObjectOfType<PlayerController>().gameObject;             //referencia do jogador
    }

    private void Update()
    {
        Chase();
    }


    
    private void Chase(){

        //onde inimigo tem que ir = onde ta o player - onde ta o inimigo
        movementDirection = (oPlayer.transform.position - transform.position).normalized;
        oRigidbody2D.velocity = movementDirection * enemySpeed;
    }
}
