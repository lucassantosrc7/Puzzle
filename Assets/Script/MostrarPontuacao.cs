using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPontuacao : MonoBehaviour {

    static Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	
    public static void MudarTexto()
    {
        text.text = "Pontos= " + Game_Controller.pontuacao.ToString();
    }
}
