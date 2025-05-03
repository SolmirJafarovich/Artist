using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class BRGlassDoor : MonoBehaviour, IInteractable
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
                StartCoroutine(opening());
            else

                StartCoroutine(closing());
        }

		IEnumerator opening()
		{
			openandclose.Play("BRGlassDoorOpen");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			openandclose.Play("BRGlassDoorClose");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
