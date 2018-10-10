using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour {

	public static bool carta_Virada = false;
    public static bool verificando = false;
    public static SelecionarCarta carta_Atual;
    public static int pontuacao = 0;
    public static string nickName;

    public static int Num_Cartas = 0;
    public static int Num_Cartas_Viradas;

    public Text display;
	
	void Update () {
        if(Num_Cartas_Viradas >= Num_Cartas)
        {
            Salvar();
        }
	}

    void Salvar()
    {
        string url = "https://us-central1-huddle-team.cloudfunctions.net/api/memory/lucassantosrc7@gmail.com";

        WWWForm formDate = new WWWForm();
        formDate.AddField("pontuacao", pontuacao.ToString());
        formDate.AddField("nickname", nickName);

        WWW www = new WWW(url, formDate);
    }
}
