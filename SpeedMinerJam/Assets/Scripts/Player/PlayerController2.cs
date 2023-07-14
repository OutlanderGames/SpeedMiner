using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public GameObject Izq, Center, Derch;
    public Block block;
    public TerrainController terrainController;

    public int dmgPoints = 1;

    public string state,facing;

    public Vector2 range;

    public float distance = 1.5f;


    private void Start()
    {
        state = "center";
        facing = "down";
    }

    // Update is called once per frame
    void Update()
    {
        facingMiner();
        Move();
        Mine();
    }
    void Mine()
    {
        if (Input.GetKeyDown(KeyCode.U) && facing == "down")
        {
            applyDmgDown();
            print("Dmg Down");
            facing = "mineDown";
        }

        if (Input.GetKeyDown(KeyCode.U) && facing == "left")
        {

            applyDmgLeft();
            print("Dmg Left");
            facing = "mineLeft";

        }
        if (Input.GetKeyDown(KeyCode.U) && facing == "right")
        {

            applyDmgRight();
            print("Dmg Right");
            facing = "mineRight";
        }



    }
    void facingMiner()
    {
        if (Input.GetKeyDown(KeyCode.A)) facing = "left";
        if (Input.GetKeyDown(KeyCode.D)) facing = "right";
        if (Input.GetKeyDown(KeyCode.S)) facing = "down";
    }
    void Move()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, distance);
        RaycastHit2D hitRigth = Physics2D.Raycast(transform.position, Vector2.right, distance);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance);


        if (Input.GetKeyDown(KeyCode.A) && state == "center" && hitLeft.collider == null)
        {
            transform.position = Izq.transform.position;
            state = "izq";
            print(state);
        }
        else if (Input.GetKeyDown(KeyCode.A) && state == "derch" && hitLeft.collider == null)
        {

            transform.position = Center.transform.position;
            state = "center";
            print(state);


        }

        if (Input.GetKeyDown(KeyCode.D) && state == "center" && hitRigth.collider == null)
        {
            transform.position = Derch.transform.position;
            state = "derch";
            print(state);

        }
        else if (Input.GetKeyDown(KeyCode.D) && state == "izq" && hitRigth.collider == null)
        {
            transform.position = Center.transform.position;
            state = "center";
            print(state);

        }

        if (Input.GetKeyDown(KeyCode.S) && hit.collider == null)
        {
            terrainController.moveTiles2();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            print("cant move");
        }


    }

    #region Damage
    void applyDmgDown()
    {

        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -Vector2.up, distance);


        if (hitDown.collider != null)
        {

            hitDown.collider.GetComponent<Block>().vida -= dmgPoints;
            hitDown.collider.GetComponent<Block>().dmgDealer = false;

        }
        else
        {
            print("No element to hit");
        }

    }

    void applyDmgLeft()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, distance);

        if (hitLeft.collider != null)
        {

            hitLeft.collider.GetComponent<Block>().vida -= dmgPoints;
            hitLeft.collider.GetComponent<Block>().dmgDealer = false;


        }
    }

    void applyDmgRight()
    {
        RaycastHit2D hitRigth = Physics2D.Raycast(transform.position, Vector2.right, distance);

        if (hitRigth.collider != null)
        {

            hitRigth.collider.GetComponent<Block>().vida -= dmgPoints;
            hitRigth.collider.GetComponent<Block>().dmgDealer = false;


        }

    }
    #endregion
}
