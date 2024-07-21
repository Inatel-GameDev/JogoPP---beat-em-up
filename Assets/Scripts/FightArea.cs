using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightArea : MonoBehaviour
{

    [Header("Verificações")]
    private bool canVerifyPlayer; //para evitar que fique colidindo sem parar com o trigger
    private bool canSpawn;

    [Header("Spawn Timer")]
    [SerializeField] private float timeBetweenSpawns;
    private float currentTimeBetweenSpawns;

    [Header("Spawn Controller")]
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemiesToSpawn;
    private int spawnedEnemies;
    private int currentEnemy;

    private void Start()
    {
        canVerifyPlayer = true;
        canSpawn = false;
        spawnedEnemies = 0;
        currentEnemy = 0;
    }

    private void Update()
    {
        //se pode spawnar e ainda resta inimigos a serem spawnados
        if (canSpawn && spawnedEnemies < enemiesToSpawn.Length)
        {
            SpawnTimer();
        }
    }

    private void SpawnTimer()
    {
        //controla a quantidade de inimigos spawnados em determinado tempo
        currentTimeBetweenSpawns -= Time.deltaTime;
        if (currentTimeBetweenSpawns <= 0)
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = timeBetweenSpawns;

        }
    }

    private void SpawnEnemy()
    {
        //escolhe um novo local de spawn e novo inimigo
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject newEnemy = enemiesToSpawn[currentEnemy];

        //spawna inimigo no local escolhido
        Instantiate(newEnemy, randomPoint.position, randomPoint.rotation);
        currentEnemy++;
        spawnedEnemies++;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (canVerifyPlayer)
        {
            //se o objeto que colidiu tem o componente PlayerController
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                canSpawn = true;
                canVerifyPlayer = false;

            }
        }
    }
}
