using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string tipoMaterial;
    public SpriteRenderer spriteRenderer;
    public TerrainController terrainController;
    public GameManager gameManager;
    public int points;
    public int vida;
    public int ratioAparicion;

    public Sprite sprite1, sprite2, sprite3, sprite4, sprite5,sprite6;
    public char[] proportion;

    //TRUE is player 1 :: FALSE is player 2
    public bool dmgDealer = true;

    public string state;

    public PlayerController playerController;



    private void Start() 
    {
        //Get components
        spriteRenderer = GetComponent<SpriteRenderer>();
        terrainController = GameObject.FindGameObjectWithTag("terraincontroller").GetComponent<TerrainController>();
        gameManager = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>();


        //Actions 
        setProportions();
        random();
    }

    private void Update()
    {

        checkLife();
    }
    void getDmg()
    {
        vida -= playerController.dmgPoints;
    }

    void setProportions()
    {
        if (gameManager.timerMin == 2) proportion = terrainController.minuto1;
        else if (gameManager.timerMin == 1) proportion = terrainController.minuto2;
        else proportion = terrainController.minuto3;
    }

    void checkLife()
    {
        if (vida <= 0)
        {
            if (dmgDealer)
            {
                gameManager.player1Points += points;
            }
            if (!dmgDealer)
            {
                gameManager.player2Points += points;

            }
            gameObject.SetActive(false);     

        }


    }
    
   public void random()
    {
        int rnd;


        rnd = Random.Range(0, 100);

        Debug.LogWarning(rnd);
        //Seteamos el valor de los tiles
        switch (proportion[rnd])
        {
            case 'v':

                tipoMaterial = "vacio";
                spriteRenderer.sprite = sprite1;
                points = 0;
                vida = 3;

                break;
            case 'e':

                tipoMaterial = "estaño";
                spriteRenderer.sprite = sprite5;
                points = 100;
                vida = 7;

                break;
            case 'c':

                tipoMaterial = "cobre";
                spriteRenderer.sprite = sprite6;
                points = 150;
                vida = 11;

                break;
            case 'h':

                tipoMaterial = "hierro";
                spriteRenderer.sprite = sprite2;
                points = 150;
                vida = 11;

                break;
            case 'p':

                tipoMaterial = "plata";
                spriteRenderer.sprite = sprite4 ;
                points = 350;
                vida = 28;

                break;
            case 's':

                tipoMaterial = "esmeralda";
                spriteRenderer.sprite = sprite3;
                points = 450;
                vida = 38;
                break;

            case 'o':

                tipoMaterial = "oro";
                spriteRenderer.sprite = sprite4;
                points = 350;
                vida = 28;

                break;
            case 'd':

                tipoMaterial = "diamante";
                spriteRenderer.sprite = sprite3;
                points = 450;
                vida = 38;

                break;

        }
    }

}
