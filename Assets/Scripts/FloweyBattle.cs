using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloweyBattle : MonoBehaviour
{
	[SerializeField] PlayerMove playerMove;
	[SerializeField] GameObject Dialogue;
	[SerializeField] GameObject player;
	[SerializeField] SpriteRenderer playerSprite;

	private bool coroutineCheck = false;
	private bool dialogueCheck = false;

    RuinScene RuinScene = new RuinScene();

    private void Update()
	{
		DialogueCheck();
		if (!Dialogue.transform.GetChild(7).gameObject.activeInHierarchy && dialogueCheck)
		{
			StartCoroutine(HeartBlink());
			CoroutineCheckFunc();
            Dialogue.transform.GetChild(1).gameObject.SetActive(true);
		}
    }

	private IEnumerator HeartBlink()
	{
		dialogueCheck = true;
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
            AllCheck();
        }
	}

	public void CoroutineCheckFunc()
	{
		if (coroutineCheck)
			StopAllCoroutines();
	}

	public void DialogueCheck()
	{
		if (Dialogue.transform.GetChild(0).gameObject.activeInHierarchy)
			dialogueCheck = true;
    }

	public void AllCheck()
	{
        if (dialogueCheck && coroutineCheck)
        {
            RuinScene.SceneChange();
        }
    }
}
