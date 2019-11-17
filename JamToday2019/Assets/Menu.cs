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
    public GameObject CreditsPanel;
    public void Credits()
    {
        StartCoroutine(ShowCredits());
    }

    IEnumerator ShowCredits()
    {
        CreditsPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        CreditsPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
