using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
	public class DialogueHolder : MonoBehaviour
	{
		[SerializeField] Animator animator;
		[SerializeField] AudioSource audioSource;

		private void Awake()
		{
			StartCoroutine(DialogueSequence());
		}

		static int i = 0;

        private IEnumerator DialogueSequence()
		{
			for (i = 0; i < transform.childCount; i++)
			{
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
				yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);

				animator.SetTrigger("Next");

				if (i == 0)
				{
					audioSource.enabled = true;
					audioSource.Play();
				}
				if (i == transform.childCount - 2)
					audioSource.Stop();
            }
        }

		private void Update()
		{
			if (Input.GetKey(KeyCode.Z))
			{
                animator.SetTrigger("Skip");
                transform.GetChild(i).gameObject.SetActive(false);
                transform.GetChild(12).gameObject.SetActive(true);
            }
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