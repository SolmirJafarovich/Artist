using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class opencloseWindowApt : MonoBehaviour, IInteractable
	{

		public Animator openandclosewindow;
		public bool open;

		void Start()
		{
			open = false;
		}

        public void Interact(PlayerInteract player)
        {
            if (open == false)
                StartCoroutine(opening());
            else
                StartCoroutine(closing());
        }


        

		IEnumerator opening()
		{
			openandclosewindow.Play("Openingwindow");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			openandclosewindow.Play("Closingwindow");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
