using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseDoor : MonoBehaviour, IInteractable
	{

		public Animator openandclose;
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
			print("you are opening the door");
			openandclose.Play("Opening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
