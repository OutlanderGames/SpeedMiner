using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public GameObject blockPre;
    public GameObject line;


    public List<GameObject> mineral1,mineral2;
    public GameObject position0, position1,position2,position3,position4,position5, position01, position11, position21, position31, position41, position51;
    public Block block;

    public char[] minuto3, minuto2, minuto1;

    public List<GameObject> floor = new List<GameObject>();

    private void Start()
    {

        createTiles1();
        createTiles2();
        fillRatio();
    }
    
    public void fillList()
    {

        foreach (GameObject mineral in GameObject.FindGameObjectsWithTag("mineral"))
        {
            floor.Add(mineral);
        }

    }

    public void move()
    {

        Vector3 height = new Vector3(0, blockPre.GetComponent<BoxCollider2D>().bounds.size.y,0);

        foreach (GameObject mineral in floor)
        {
            
            mineral.transform.position += height;

        }
    }

    public void emptyList1()
    {
        foreach (GameObject mineral in mineral1)
        {
            Destroy(mineral);
        }
        mineral1.Clear(); 
    }
    public void emptyList2()
    {
        foreach (GameObject mineral in mineral2)
        {
            Destroy(mineral);
        }
        mineral2.Clear();
    }
  
    public void createTiles1()
    {
        GameObject mineralLine;


        mineralLine = Instantiate(line, position1.transform.position, Quaternion.identity);
        mineral1.Add(mineralLine);

        mineralLine = Instantiate(line, position2.transform.position, Quaternion.identity);
        mineral1.Add(mineralLine);

        mineralLine = Instantiate(line, position3.transform.position, Quaternion.identity);
        mineral1.Add(mineralLine);

        mineralLine = Instantiate(line, position4.transform.position, Quaternion.identity);
        mineral1.Add(mineralLine);

        mineralLine = Instantiate(line, position5.transform.position, Quaternion.identity);
        mineral1.Add(mineralLine);


        

    }
    public void createTiles2()
    {
        GameObject mineralLine;

        //Línea 2
        mineralLine = Instantiate(line, position11.transform.position, Quaternion.identity);
        mineral2.Add(mineralLine);

        mineralLine = Instantiate(line, position21.transform.position, Quaternion.identity);
        mineral2.Add(mineralLine);

        mineralLine = Instantiate(line, position31.transform.position, Quaternion.identity);
        mineral2.Add(mineralLine);

        mineralLine = Instantiate(line, position41.transform.position, Quaternion.identity);
        mineral2.Add(mineralLine);

        mineralLine = Instantiate(line, position51.transform.position, Quaternion.identity);
        mineral2.Add(mineralLine);
    }



    public void fillRatio()
    {
        minuto1 = new char[100];
        minuto2 = new char[100];
        minuto3 = new char[100];

        //Rellenamos primer minuto de juego
        for (int i = 0; i < 30; i++)
        {
            minuto1[i] = 'v';
        }

        for (int i = 30; i < 50; i++)
        {
            minuto1[i] = 'e';
        }

        for (int i = 50; i < 65; i++)
        {
            minuto1[i] = 'c';
        }

        for (int i = 65; i < 78 ; i++)
        {
            minuto1[i] = 'h';
        }

        for (int i = 78; i < 90 ; i++)
        {
            minuto1[i] = 'o';
        }

        for (int i = 90; i < 100 ; i++)
        {
            minuto1[i] = 's';
        }


        //Rellenamos segundo minuto de juego
        for (int i = 0; i < 26; i++)
        {
            minuto2[i] = 'v';
        }

        for (int i = 26; i < 43; i++)
        {
            minuto2[i] = 'e';
        }

        for (int i = 43; i < 65; i++)
        {
            minuto2[i] = 'c';
        }

        for (int i = 65; i < 71; i++)
        {
            minuto2[i] = 'h';
        }

        for (int i = 71; i < 85; i++)
        {
            minuto2[i] = 'o';
        }

        for (int i = 85; i < 95; i++)
        {
            minuto2[i] = 's';
        }

        for (int i = 95; i < 100 ; i++)
        {
            minuto2[i] = 'd';
            
        }


        //Rellenamos tercer minuto de juego
        for (int i = 0; i < 25; i++)
        {
            minuto3[i] = 'v';
        }

        for (int i = 25; i < 28; i++)
        {
            minuto3[i] = 'e';

        }

        for (int i = 28; i < 43 ; i++)
        {
            minuto3[i] = 'c';

        }

        for (int i = 43; i < 60; i++)
        {
            minuto3[i] = 'h';

        }

        for (int i = 60; i < 77; i++)
        {
            minuto3[i] = 'o';
        }

        for (int i = 77; i < 90; i++)
        {
            minuto3[i] = 's';
        }

        for (int i = 90; i < 100 ; i++)
        {
            minuto3[i] = 'd';
        }


    }

    public void moveTiles()
    {
        //GameObject mineralLine;
        //Desplazamos los tiles
        foreach (GameObject mineral in mineral1)
        {
            //Comprobamos posicion y asignamos nueva posición
            if (mineral.transform.position == position0.transform.position) 
            { 
                mineral.transform.position = position5.transform.position;
                mineral.GetComponent<terrainLine>().Reset();
            }
            if (mineral.transform.position == position1.transform.position) mineral.transform.position = position0.transform.position;
            if (mineral.transform.position == position2.transform.position) mineral.transform.position = position1.transform.position;
            if (mineral.transform.position == position3.transform.position) mineral.transform.position = position2.transform.position;
            if (mineral.transform.position == position4.transform.position) mineral.transform.position = position3.transform.position;
            if (mineral.transform.position == position5.transform.position) mineral.transform.position = position4.transform.position;
        }

    }

    public void moveTiles2()
    {
        foreach (GameObject mineral in mineral2)
        {
            //Comprobamos posicion y asignamos nueva posición
            if (mineral.transform.position == position01.transform.position)
            {
                mineral.transform.position = position51.transform.position;
                mineral.GetComponent<terrainLine>().Reset();
            }
            if (mineral.transform.position == position11.transform.position) mineral.transform.position = position01.transform.position;
            if (mineral.transform.position == position21.transform.position) mineral.transform.position = position11.transform.position;
            if (mineral.transform.position == position31.transform.position) mineral.transform.position = position21.transform.position;
            if (mineral.transform.position == position41.transform.position) mineral.transform.position = position31.transform.position;
            if (mineral.transform.position == position51.transform.position) mineral.transform.position = position41.transform.position;
        }

    }
}
