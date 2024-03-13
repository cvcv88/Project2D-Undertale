using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerSceneChanger : MonoBehaviour
{
	[SerializeField] GameObject dialogue;
	[SerializeField] Animator animator;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "Trigger1")
		{
			Debug.Log("플라위");
			transform.position = new Vector3(12, 8, 0);
		}

		if (collider.gameObject.name == "Trigger2")
		{
			Debug.Log("토리엘등장 후 집 가는 게이트");
			// transform.position = new Vector3();
		}
	}
}
