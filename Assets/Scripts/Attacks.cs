using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [SerializeField]private int damage;
    //other é o componente colidido
    private void OnTriggerEnter2D(Collider2D other) {

        //se o objeto colidido tiver o componente PlayerLife
        if(other.gameObject.GetComponent<PlayerLife>() != null){
            other.gameObject.GetComponent<PlayerLife>().takeDamage(damage);  //chamando metodo de dano
        }    
    }
}
