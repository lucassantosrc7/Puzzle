using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PegarNickName : MonoBehaviour {

    InputField inputField;

	void Start () {
        inputField = GetComponent<InputField>();
	}

    public void Enviar_Nome()
    {
        Game_Controller.nickName = inputField.text;
    }
}
