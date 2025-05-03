using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFlipL: MonoBehaviour, IInteractable
{

	public Animator FlipL;
	public bool open;

	void Start (){
		open = false;
	}

    public void Interact(PlayerInteract player)
    {

        if (open == false)
            StartCoroutine(opening());
        else

            StartCoroutine(closing());
    }

    IEnumerator opening(){
        FlipL.Play ("Lup");
		open = true;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator closing(){
        FlipL.Play ("Ldown");
		open = false;
		yield return new WaitForSeconds (.5f);
	}


}

