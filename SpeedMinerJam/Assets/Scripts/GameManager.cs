using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text tiempoMin,tiempoSec,puntutationPlayer1,puntuationPlayer2;
    public Slider player1Slider, player2Slider;

    public TerrainController terrainController;

    public int player1Points,player2Points,player2Compare,player1Compare;
    public float dynamite1, dynamite2;
    public int  timerMin = 3;
    public float timerSec = 60;

    public bool winner;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        dynamite1 = 0;
        dynamite2 = 0;

        player1Compare = player1Points;
        player2Compare = player2Points;
    }
    private void Update()
    {
        setPuntuation();

            timerSec -= Time.deltaTime;
        

        tiempoMin.text = timerMin.ToString();
        tiempoSec.text = Mathf.Round(timerSec).ToString() ;

        if (timerSec <= 0.0f && timerMin != 0)
        {

            --timerMin;
            timerSec = 59;

        }
        if (timerSec<=0 && timerMin <= 0)
        {
            endGame();
            if (player1Points > player2Points)
            {
                winner = true;
            }
            else
            {
                winner = false;
            }
        }
        
        if (player1Compare <  player1Points)
        {
            player1Slider.value += 0.1f;
            player1Compare = player1Points;
        }
        if (player2Compare < player2Points)
        {
            player2Slider.value += 0.1f;
            player2Compare = player2Points;

        }

        if (Input.GetKeyDown(KeyCode.Home) && player1Slider.value == 1)
        {
            terrainController.emptyList1();
            player2Slider.value = 0;
            StartCoroutine(Blink());

        }
        if (Input.GetKeyDown(KeyCode.I) && player2Slider.value == 1)
        {
            terrainController.emptyList2();
            player2Slider.value = 0;
            StartCoroutine(Blink2());

        }
    }
    IEnumerator Blink()
    {

        yield return new WaitForSeconds(0.3f);
        terrainController.createTiles1();

    }

    IEnumerator Blink2()
    {

        yield return new WaitForSeconds(0.3f);
        terrainController.createTiles2();

    }
    void endGame()
    {
        SceneManager.LoadScene("gameover");
    }

    void setPuntuation()
    {
        puntuationPlayer2.text = player2Points.ToString();
        puntutationPlayer1.text = player1Points.ToString();

    }

    public void incrementDinamite()
    {
        player1Slider.value = dynamite1;
        player2Slider.value = dynamite2;
    }



}
