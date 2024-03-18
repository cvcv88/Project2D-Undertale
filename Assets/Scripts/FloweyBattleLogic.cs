using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloweyBattleLogic : MonoBehaviour
{
	Vector3 startPos; // ÇöÀç
	Vector3 endPos; // Å¸°Ù

	Vector3 normalVector;

	[SerializeField] GameObject playerPos;

	[SerializeField] Rigidbody2D rigid;

	private void Awake()
	{
		startPos = gameObject.transform.position;
		endPos = playerPos.gameObject.transform.position;
	}

	public void FireBullet()
	{
		normalVector = (endPos - startPos).normalized;
		rigid.AddForce(normalVector * 100f);
	}

	public void CircleBullet()
	{

	}
}
