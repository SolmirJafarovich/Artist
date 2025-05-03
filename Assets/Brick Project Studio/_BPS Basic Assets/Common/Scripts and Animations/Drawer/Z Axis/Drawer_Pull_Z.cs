using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class Drawer_Pull_Z : MonoBehaviour, IInteractable
	{

		public Animator pull;
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
			pull.Play("openpull");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			pull.Play("closepush");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
