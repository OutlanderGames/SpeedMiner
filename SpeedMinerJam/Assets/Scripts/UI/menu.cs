using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject pressStart;
    public GameManager gameManager;
    public float blinkTime;
    
    private bool once = true;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>();

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

    }

    IEnumerator Blink()
    {
        if (pressStart.activeSelf)
        {
            pressStart.SetActive(false);
        }
        else
        {
            pressStart.SetActive(true);
        }

        
        yield return new WaitForSeconds(blinkTime);
        once = true;
    }
    
    public void controlsButton()
    {

    }

    public void optionsButton()
    {

    }

    public void exitButton()
    {
        Application.Quit();
    }
}
