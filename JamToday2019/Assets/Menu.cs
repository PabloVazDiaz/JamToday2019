using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Text JokeText;
    public GameObject LoadButton;
    int clicks = 0;

    public void NewGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadGame()
    {
        switch (clicks)
        {
            case 0:
                {
                    JokeText.text = "El juego no tiene carga de partida realmente";
                    break;
                }
            case 1:
                {
                    JokeText.text = "No en serio, este boton no hace nada";
                    break;
                }
            case 2:
                {
                    JokeText.text = "Como sigas pulsando lo vas a romper";
                    break;
                }
            default:
                {
                    JokeText.text = "";
                    LoadButton.SetActive(false);
                    break;
                }
        }
        clicks++;
    }

    public void Credits()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
