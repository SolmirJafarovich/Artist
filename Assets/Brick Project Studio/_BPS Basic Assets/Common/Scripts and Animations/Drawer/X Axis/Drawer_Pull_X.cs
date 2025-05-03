using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{

	public class Drawer_Pull_X : MonoBehaviour, IInteractable
	{

		public Animator pull_01;
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
			pull_01.Play("openpull_01");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			pull_01.Play("closepush_01");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
