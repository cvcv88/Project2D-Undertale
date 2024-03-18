using System.Collections;
using UnityEngine;

namespace FloweyBattleDialogueClass
{
	public class FloweyBattleDialogueHolder : MonoBehaviour
	{
		FloweyBattleLogic floweyBattleLogic;
		private void Awake()
		{
			Debug.Log(floweyBattleLogic);
			floweyBattleLogic = GetComponent<FloweyBattleLogic>();
			Debug.Log(floweyBattleLogic);
			StartCoroutine(DialogueSequence());
		}

		private IEnumerator DialogueSequence()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				Deactivate();
				transform.GetChild(i).gameObject.SetActive(true);
				yield return new WaitUntil(() => transform.GetChild(i).GetComponent<FloweyBattleDialogueBaseClass>().finished);

				if (i == 8 || i == 12 || i == 15)
				{
					floweyBattleLogic.FireBullet();
				}
			}

			gameObject.SetActive(false);
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