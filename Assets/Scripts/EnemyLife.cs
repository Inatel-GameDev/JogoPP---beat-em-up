using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [Header("Status")]
    public bool isEnemyAlive;

    [Header("Life controller")]
    [SerializeField] private int maxLife;
    private int currentLife;
    [SerializeField] private float vanishTime;

    [Header("Drops")]
    [SerializeField] private int dropFoodChance;
    [SerializeField] private GameObject[] foodsType;  //array de comidas


    private void Start()
    {
        isEnemyAlive = true;
        currentLife = maxLife;
    }

    public void takeDamage(int damage)
    {   //aplica o dano ao inimigo

        if (isEnemyAlive)
        {
            currentLife -= damage;
            GetComponent<EnemyController>().EnemyDamageAnimation();
            UIManager.istance.AtualizarBarraDeVidaDoInimigoAtual(maxLife,currentLife);  //barra de vida

            if (currentLife <= 0)
            {
                isEnemyAlive = false;
                GetComponent<EnemyController>().DefeatAnimation();
                UIManager.istance.DesativarPainelDoInimigo();
                SpawnFood();
                Destroy(this.gameObject, vanishTime);
    
            }
        }
    }

    private void SpawnFood()
    {

        int dropChance = Random.Range(0, 100);  //chance de dropar comida
        
        if (dropChance <= dropFoodChance)  //se chance for menor que a chance fixa
        {
            GameObject food = foodsType[Random.Range(0, foodsType.Length)];
            Instantiate(food, transform.position, transform.rotation);         //instanciando o gameobject
        }
    }

}
