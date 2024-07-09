using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [Header("Status")]
    public bool isEnemyAlive;

    [Header("Life controller")]
    [SerializeField] private int maxLife;
    [SerializeField]private float vanishTime;
    private int currentLife;

    private void Start()
    {
        isEnemyAlive = true;
        currentLife = maxLife;
    }

    public void takeDamage(int damage){   //aplica o dano ao inimigo

        if(isEnemyAlive){
            currentLife -= damage;
            GetComponent<EnemyController>().EnemyDamageAnimation();

            if(currentLife <= 0){
                isEnemyAlive = false;
                GetComponent<EnemyController>().DefeatAnimation();
                Destroy(this.gameObject,vanishTime);
                Debug.Log("Inimigo morreu");

            }
        }
    }

}
