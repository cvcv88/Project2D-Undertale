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


	int objSize = 3;
	float circleR;
	float deg;
	float objSpeed;

	private void Awake()
	{
		startPos = gameObject.transform.position;
	}

	public void FireBullet()
	{
		endPos = playerPos.gameObject.transform.position;
		normalVector = (endPos - startPos).normalized;
		rigid.AddForce(normalVector * 200f);
	}

	public void ReadyBullet()
	{
		gameObject.transform.position = startPos;
	}

	public void Update()
	{
		CircleBullet();
	}
	public void CircleBullet()
	{
		deg += Time.deltaTime * objSpeed;
		if (deg < 360)
		{
			for (int i = 0; i < objSize; i++)
			{
				var rad = Mathf.Deg2Rad * (deg + (i * (360 / objSize)));
				var x = circleR * Mathf.Sin(rad);
				var y = circleR * Mathf.Cos(rad);
				transform.position = transform.position + new Vector3(x, y);
				transform.rotation = Quaternion.Euler(0, 0, (deg + (i * (360 / objSize))) * -1);
			}

		}
		else
		{
			deg = 0;
		}
	}
}
