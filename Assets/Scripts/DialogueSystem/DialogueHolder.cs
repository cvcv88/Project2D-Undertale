using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
	public class DialogueHolder : MonoBehaviour
	{
		[SerializeField] Animator animator;

		private void Awake()
		{
			StartCoroutine(DialogueSequence());
		}
		private void Start()
		{
			animator = GetComponent<Animator>();
		}
		private IEnumerator DialogueSequence()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				Deactivate();
				transform.GetChild(i).gameObject.SetActive(true);
				yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
			}
			gameObject.SetActive(false);
			animator.SetTrigger("Next");
		}
		private void Deactivate()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}