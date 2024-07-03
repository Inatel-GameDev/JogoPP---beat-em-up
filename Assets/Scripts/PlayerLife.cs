using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public bool isAlive;    //deve ser publica para ser acessado em outros scripts
    [SerializeField]private int maxLife;
    private int currentLife;

    private void Start()
    {
        isAlive = true;
        currentLife = maxLife;

        
    }

    public void takeDamage(int damage){
        
        if(isAlive){
            currentLife -= damage;

            if(currentLife <= 0){
                isAlive = false;
                Debug.Log("Player morreu");
            }
        }
    }
}
