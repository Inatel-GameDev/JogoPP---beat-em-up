using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager istance;
    [SerializeField]private GameObject PainelDoInimigo;
    [SerializeField]private Slider BarraDeVidaDoInimigoAtual;

    private void Awake()  //roda antes do start
    {
        if(istance == null){
            istance = this;
        }else{
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        DesativarPainelDoInimigo();
    }

    public void AtivarPainelDoInimigo(){
        PainelDoInimigo.SetActive(true);
    }

    public void DesativarPainelDoInimigo(){
        PainelDoInimigo.SetActive(false);
    }

    //barra de vida dinamica
    public void AtualizarBarraDeVidaDoInimigoAtual(int maxValue, int currentValue){
        BarraDeVidaDoInimigoAtual.maxValue = maxValue;
        BarraDeVidaDoInimigoAtual.value = currentValue;

        AtivarPainelDoInimigo();
    }


}
