using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int lifeGain;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<PlayerLife>() != null)
        {
            other.gameObject.GetComponent<PlayerLife>().restoreLife(lifeGain);
            SoundManager.instance.pegarComida.Play();

            Destroy(this.gameObject);
        }
    }
}
