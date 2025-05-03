using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class OvenFlip: MonoBehaviour, IInteractable
	{

		public Animator openandcloseoven;
		public bool open;

		void Start()
		{
			open = false;
		}

        public void Interact(PlayerInteract player)
        {
            if (open == false)
            {
                StartCoroutine(opening());
            }
            else
            {
                StartCoroutine(closing());
            }
        }
    

		IEnumerator opening()
		{
			openandcloseoven.Play("OpenOven");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{;
			openandcloseoven.Play("ClosingOven");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
