using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController1 : MonoBehaviour
{

    public PlayerController2 playerController;
    public Animator animator;

    private void Update()
    {
        //Controla las animaciones encarar y picar
        switch (playerController.facing)
        {
            case "down":
                animator.SetInteger("facing", 0);
                break;
            case "left":
                animator.SetInteger("facing", 4);

                break;
            case "right":
                animator.SetInteger("facing", 3);

                break;
            case "mineDown":
                animator.SetInteger("facing", 2);
                StartCoroutine(Blink() );

                break;
            case "mineLeft":
                animator.SetInteger("facing", 1);
                StartCoroutine(Blink2());

                break;
            case "mineRight":
                animator.SetInteger("facing", 5);
                StartCoroutine(Blink3());

                break;
        }
        
    }

    //Timers introducidos tras picar para que en un breve instante tras hacer la acci�n se quede mirando hacia el �ltimo sitio que pic�.
    IEnumerator Blink()
    {

        yield return new WaitForSeconds(0.3f);
        playerController.facing = "down";

    }
    IEnumerator Blink2()
    {

        yield return new WaitForSeconds(0.3f);
        playerController.facing = "left";

    }

    IEnumerator Blink3()
    {

        yield return new WaitForSeconds(0.3f);
        playerController.facing = "right";

    }

}
