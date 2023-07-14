using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class gameOver : MonoBehaviour
{
    GameManager gameManager;

    public Image winner;
    public Sprite player1, player2;
    public Text player;
    public GameObject playAgain;

    bool once;
    public float blinkTime;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>();

        if (gameManager.winner)
        {
            winner.sprite = player1;
            player.text = "Player 1";
        }
        else
        {
            winner.sprite = player2;
            player.text = "Player 2";

        }

    }

    public void startButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            startButton();
        }

        if (once)
        {
            StartCoroutine(Blink());
            once = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene("SampleScene");

        }
    }

    IEnumerator Blink()
    {
        if (playAgain.activeSelf)
        {
            playAgain.SetActive(false);
        }
        else
        {
            playAgain.SetActive(true);
        }


        yield return new WaitForSeconds(blinkTime);
        once = true;
    }
}
