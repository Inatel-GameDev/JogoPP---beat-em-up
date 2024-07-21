using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFOllow : MonoBehaviour
{
    [Header("Referencias do Jogador")]
    private GameObject oPlayer;
    private Vector3 playerPosition;

    [Header("Movement Limits")]
    [SerializeField]private float maxX;
    [SerializeField]private float minX;
     [SerializeField]private float maxY;
     [SerializeField]private float minY;
    private void Start()
    {
        oPlayer = FindObjectOfType<PlayerController>().gameObject;

    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer(){
        //armazena posicao do jogador
        playerPosition = oPlayer.transform.position;
        //faz x ser igual do jogador
        transform.position = new Vector3(playerPosition.x,transform.position.y,transform.position.z);

        //limita camera
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),Mathf.Clamp(transform.position.y,minY,maxY),transform.position.z);


    }
}
