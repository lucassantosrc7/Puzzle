using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad : MonoBehaviour {
    string FilePath;

    string setUrl = "https://us-central1-huddle-team.cloudfunctions.net/api/memory/lucassantosrc7@gmail.com";

	void Start () {
        FilePath = Path.Combine(Application.dataPath, "save.text");
        //StartCoroutine(save());
	}
	
	
	void Update () {
		
	}

    IEnumerator save(int pontuacao, string nickname)
    {
        WWWForm form = new WWWForm();

        string p = JsonUtility.ToJson(pontuacao);
        File.WriteAllText(FilePath, p);
        form.AddField("pontuacao", p);

        string n = JsonUtility.ToJson(nickname);
        File.WriteAllText(FilePath, n);
        form.AddField("nickname", n);

        WWW www = new WWW(setUrl, form);
        yield return null;
    }
}
