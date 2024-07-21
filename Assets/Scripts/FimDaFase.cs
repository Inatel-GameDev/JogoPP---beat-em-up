using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FimDaFase : MonoBehaviour
{
    [SerializeField] private string nextFase;
    [SerializeField] private float transitionTime;
    [SerializeField] private float loadTime;

    private IEnumerator Transition()
    {
        //espera x segundos e escurece tela
        yield return new WaitForSeconds(transitionTime);
        UIManager.istance.ActivateTransition();

        //espera x segundos e carrega fase seguinte
        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(nextFase);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //se colidir, verifica se derrotou inimigos. Caso sim, carrega proxima fase
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            EnemyController[] enemiesAlive = FindObjectsOfType<EnemyController>();
            if (enemiesAlive.Length == 0)
            {
                StartCoroutine(Transition());
            }
        }
    }
}
