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
			Debug.Log("�ö���");
			transform.position = new Vector3(12, 8, 0);
		}

		if (collider.gameObject.name == "Trigger2")
		{
			Debug.Log("�丮������ �� �� ���� ����Ʈ");
			// transform.position = new Vector3();
		}
	}
}
