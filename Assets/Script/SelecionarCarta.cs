using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecionarCarta : MonoBehaviour {

    SelecionarCarta selecionarCarta;

    [SerializeField]
    Color color;
    Color cor_Original;

    public enum Tipo_Carta
    {
       Vermelho, Azul, Verde, Amarelo
    }

    public Tipo_Carta tipo_Carta;

    [SerializeField]
    int pontos = 50;

    Image image;

	void Start () {
        selecionarCarta = this.GetComponent<SelecionarCarta>();

        image = this.GetComponent<Image>();
        cor_Original = image.color;

        Game_Controller.Num_Cartas++;
    }

    public void Selecionar_Carta() {
        if (!Game_Controller.verificando)
        {
            VirarCarta();

            if (!Game_Controller.carta_Virada)
            {
                Game_Controller.carta_Virada = true;
                Game_Controller.carta_Atual = selecionarCarta;
            }
            else
            {
                StartCoroutine(Verificar_Carta(2f));
            }
        }
    }

    IEnumerator Verificar_Carta(float Temp_Carta_Virada) {
        Game_Controller.verificando = true;
        yield return new WaitForSeconds(Temp_Carta_Virada);

        if (Game_Controller.carta_Atual.tipo_Carta == tipo_Carta)
        {
            Game_Controller.pontuacao += pontos;
            MostrarPontuacao.MudarTexto();

            Game_Controller.carta_Atual.gameObject.SetActive(false);
            Game_Controller.Num_Cartas_Viradas++;

            gameObject.SetActive(false);
            Game_Controller.Num_Cartas_Viradas++;
        }
        else
        {
            Game_Controller.carta_Atual.DesvirarCarta();
            DesvirarCarta();
        }

        Game_Controller.verificando = false;
        Game_Controller.carta_Virada = false;
        Game_Controller.carta_Atual = null;
    }

    public void VirarCarta()
    {
        image.color = color;
    }

    public void DesvirarCarta() {
        image.color = cor_Original;
    }
}
