using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor1 : MonoBehaviour, IInteractable
	{

		public Animator openandclose1;
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
			openandclose1.Play("Opening 1");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			openandclose1.Play("Closing 1");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
