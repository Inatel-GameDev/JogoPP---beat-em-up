using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [Header("Status")]
    public bool isPlayerAlive;    //deve ser publica para ser acessado em outros scripts
    [Header("Life controller")]
    [SerializeField]private int maxLife;
    private int currentLife;

    private void Start()
    {
        isPlayerAlive = true;   //player começa vivo
        currentLife = maxLife;  //vida inicial = maxima
    }

    public void restoreLife(int lifePoint)
    {
        if(currentLife + lifePoint <= maxLife){
            currentLife += lifePoint;
        }
        else{
            currentLife = maxLife;
        }

    }

    public void takeDamage(int damage){  //aplica o dano ao player
        
        if(isPlayerAlive){
            currentLife -= damage;
            GetComponent<PlayerController>().DamageAnimation();  //animação de dano

            if(currentLife <= 0){
                isPlayerAlive = false;
                GetComponent<PlayerController>().DefeatAnimation();
            }
        }
    }
}
