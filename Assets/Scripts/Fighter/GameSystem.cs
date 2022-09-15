using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : MonoBehaviour
{
    int round = 0;

    GameObject gameMenu;
    public GameObject hero,enemy,enemy2;

    TextMeshProUGUI roundText, resultText;

    private void Start()
    {
        roundText = GameObject.Find("/Canvas/MainMenu/RoundText").GetComponent<TextMeshProUGUI>();
        resultText = GameObject.Find("/Canvas/GameMenu/ResultText").GetComponent<TextMeshProUGUI>();
        gameMenu = GameObject.Find("GameMenu");
        PlayGame();
    }
    public void showResult(string text)
    {
        resultText.text = $"YOU {text} THE ROUND";
    }
    public void NextGame()
    {
        hero.SetActive(false);
        enemy.SetActive(false);
        enemy2.SetActive(false);
        gameMenu.SetActive(true);
    }
    public void PlayGame()
    {
        round++;
        roundText.SetText($"ROUND {round}");
        gameMenu.SetActive(false);
        if (round == 2)
        {
            hero.SetActive(true);
            // enemy.SetActive(true);
            enemy2.SetActive(true);
        }
    }
}
