using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainLine : MonoBehaviour
{
    //Genera una linea de bloques basándose en la funcion random de bloque.

    public GameObject izq, center, derch;

    public void Reset()
    {

        izq.SetActive(true);
        center.SetActive(true);
        derch.SetActive(true);

       izq.GetComponent<Block>().random();
       center.GetComponent<Block>().random();
       derch.GetComponent<Block>().random();

    }

}
