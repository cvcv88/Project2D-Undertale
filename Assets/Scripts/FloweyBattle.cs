using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloweyBattle : MonoBehaviour
{
	[SerializeField] PlayerMove playerMove;
	[SerializeField] Canvas backGroundCanvas;
	[SerializeField] GameObject player;
	[SerializeField] SpriteRenderer playerSprite;

	private bool coroutineCheck = false;

	private void Update()
	{
		if (backGroundCanvas.transform.GetChild(0).gameObject.activeInHierarchy)
		{
			StartCoroutine(HeartBlink());
			CoroutineCheckFunc();
			backGroundCanvas.transform.GetChild(1).gameObject.SetActive(true);
		}
	}
	private IEnumerator HeartBlink()
	{
		yield return new WaitForSeconds(0.1f);
		playerMove.transform.GetChild(1).gameObject.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		playerMove.transform.GetChild(1).gameObject.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		playerMove.transform.GetChild(1).gameObject.SetActive(true);
		coroutineCheck = true;

		if (player.transform.GetChild(1).gameObject.activeInHierarchy)
		{
			playerSprite.enabled = false;
		}
	}

	void CoroutineCheckFunc()
	{
		if (coroutineCheck)
			StopAllCoroutines();
	}
}
