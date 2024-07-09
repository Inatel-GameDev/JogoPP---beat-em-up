using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [SerializeField]private int damage;
    //other é o componente colidido
    private void OnTriggerEnter2D(Collider2D other) {

        //se colidir com o player
        if(other.gameObject.GetComponent<PlayerLife>() != null){
            other.gameObject.GetComponent<PlayerLife>().takeDamage(damage);  //chamando metodo de dano
        }    
        //se colidir com o inimigo
        else if(other.gameObject.GetComponent<EnemyLife>() != null){
            other.gameObject.GetComponent<EnemyLife>().takeDamage(damage); 
        }
    }
}
