using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Pauza : MonoBehaviour {

    bool Pauzirano = false;
    bool Zavrseno = false;
    

    void Start()
    {
        Time.timeScale = 1.0f;
        Pauzirano = false;
        Zavrseno = false;
    }

    public void Kraj()
    {
        Time.timeScale = 0.0f;
        Zavrseno = true;
    }


    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Pauzirano)
            {
                SceneManager.LoadScene("GlavniMeni");
                Pauzirano = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                Pauzirano = true;
            }
        }
        else if (Input.GetKeyDown("return") && Pauzirano)
        {
            Time.timeScale = 1.0f;
            Pauzirano = false;
        }

        if (Zavrseno && Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("GlavniMeni");
    }

    void OnGUI()
    {
        var centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperCenter;

        if (Pauzirano)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 150, 150), "<color=black><size=30>Pauzirali ste igru</size></color>\n<size=20>Pritisnite escape za izlaz, a enter za nastavak igre</size>");

        if (Zavrseno)
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 250, 150), "<color=black><size=35>Izgubili ste :(</size>\n<size=20>Pritisnite space za nastavak</size></color>");
    }
}
