using System.Collections;
using UnityEngine;

namespace InGameDialogueSystem
{
	public class InGameDialogueHolder : MonoBehaviour
	{
		private void Awake()
		{
			StartCoroutine(DialogueSequence());
		}

        private IEnumerator DialogueSequence()
		{
			for (int i = 0; i < transform.childCount - 1; i++)
			{
				Deactivate();
				transform.GetChild(i).gameObject.SetActive(true);
				yield return new WaitUntil(() => transform.GetChild(i).GetComponent<InGameDialogueLine>().finished);
			}
			gameObject.SetActive(false);
		}
		private void Deactivate()
		{
			for (int i = 0; i < transform.childCount - 1; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}