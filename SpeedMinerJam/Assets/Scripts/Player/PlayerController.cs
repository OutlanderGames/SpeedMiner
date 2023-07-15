using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Acceso al controlador de juego y terreno, adem�s de las tres posiciones en horizontal que puede ocupar
    public GameObject Izq,Center,Derch;
    public TerrainController terrainController;
    public GameManager gameManager;
   
    public int  dmgPoints = 1;

    public string state,facing;

    public Vector2 range;

    public float distance = 1.5f;
    private void Start()
    {
        state = "center";
        facing = "down";
    }

    void Update()
    {
        facingMiner();
        Move();
        Mine();
    }
    
    //Se aplica da�o al bloque al que apunta el minero
    void Mine()
    {

        //Dependiendo de hacia donde est� mirando (facing) hace da�o en una de las tres direcciones.
        if (Input.GetKeyDown(KeyCode.Insert) && facing == "down") 
        {
            applyDmgDown(); 
            print("Dmg Down"); 
            facing = "mineDown"; 
        } 

        if (Input.GetKeyDown(KeyCode.Insert) && facing == "left")
        {

            applyDmgLeft(); 
            print("Dmg Left");
            facing = "mineLeft";

        }
        if (Input.GetKeyDown(KeyCode.Insert) && facing == "right")
        { 
            
            applyDmgRight(); 
            print("Dmg Right"); 
            facing = "mineRight";
        }


    }

    //Cambia hacia donde est� encarando el minero
    void facingMiner()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))facing ="left";
        if (Input.GetKeyDown(KeyCode.RightArrow))facing = "right";
        if (Input.GetKeyDown(KeyCode.DownArrow))facing = "down";
    }

    //Se mueve el minero a nueva posici�n si no esta bloqueada
    void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, distance);
        RaycastHit2D hitRigth = Physics2D.Raycast(transform.position, Vector2.right, distance);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance);

        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && state == "center" && hitLeft.collider == null)
        {
            transform.position = Izq.transform.position;
            state = "izq";
            print(state);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && state == "derch" && hitLeft.collider == null)
        {

            transform.position = Center.transform.position;
            state = "center";
            print(state);


        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && state == "center" && hitRigth.collider == null)
        {
            transform.position = Derch.transform.position;
            state = "derch";
            print(state);

        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && state =="izq" && hitRigth.collider == null)
        {
            transform.position = Center.transform.position;
            state = "center";
            print(state);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && hit.collider == null)
        {
            terrainController.moveTiles();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            print("cant move");
        }


    }

    //Gestiona el da�o que se aplica a los bloques
    #region Damage
    void applyDmgDown()
    {
            //Rayo de alcance de la acci�n picar hacia abajo
            RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -Vector2.up, distance);
            
            //Aplica el da�o si el rayo detecta colisi�n.
            if (hitDown.collider != null)
            {
               
                hitDown.collider.GetComponent<Block>().vida -= dmgPoints;
                hitDown.collider.GetComponent<Block>().dmgDealer = true;

            }
            else
            {
                print("No element to hit");
            }
        
    }

    void applyDmgLeft()
    {
        //Rayo de alcance para picar hacia izquierda
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance);

        if (hitLeft.collider != null)
        {

            hitLeft.collider.GetComponent<Block>().vida -= dmgPoints;
            hitLeft.collider.GetComponent<Block>().dmgDealer = true;


        }
    }

    void applyDmgRight()
    {
        //Rayo de alcance para picar hacia la derecha
        RaycastHit2D hitRigth = Physics2D.Raycast(transform.position, Vector2.right, distance);

        if (hitRigth.collider != null)
        {

            hitRigth.collider.GetComponent<Block>().vida -= dmgPoints;
            hitRigth.collider.GetComponent<Block>().dmgDealer = true;


        }

    }
    #endregion

}
