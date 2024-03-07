using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floweyglowTrigger : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider collider)
	{
		if(collider.name == "Trigger1")
		{
			transform.Translate(0, 0, 0);
		}
	}
}
