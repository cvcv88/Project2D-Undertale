using System.Collections;
using UnityEngine;

namespace FloweyBattleDialogueClass
{
	public class FloweyBattleDialogueHolder : MonoBehaviour
	{
		[SerializeField] FloweyBattleLogic floweyBattleLogic1;
		[SerializeField] FloweyBattleLogic floweyBattleLogic2;
		[SerializeField] FloweyBattleLogic floweyBattleLogic3;
		[SerializeField] FloweyBattleLogic floweyBattleLogic4;
		[SerializeField] FloweyBattleLogic floweyBattleLogic5;
		[SerializeField] Animator animator;
		private void Awake()
		{
			StartCoroutine(DialogueSequence());
		}

		private IEnumerator DialogueSequence()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				Deactivate();
				transform.GetChild(i).gameObject.SetActive(true);
				yield return new WaitUntil(() => transform.GetChild(i).GetComponent<FloweyBattleDialogueBaseClass>().finished);

				switch (i)
				{
					case 4:
						animator.Play("FloweyWink");
						break;
					case 8:
					case 12:
					case 15:
						floweyBattleLogic1.GetComponent<FloweyBattleLogic>().FireBullet();
						floweyBattleLogic2.GetComponent<FloweyBattleLogic>().FireBullet();
						floweyBattleLogic3.GetComponent<FloweyBattleLogic>().FireBullet();
						floweyBattleLogic4.GetComponent<FloweyBattleLogic>().FireBullet();
						floweyBattleLogic5.GetComponent<FloweyBattleLogic>().FireBullet();
						break;
					case 9:
						animator.Play("FloweySassy");
						break;
					case 13:
						animator.Play("FloweyPissed");
						break;
					case 16:
						animator.Play("FloweyGrin");
						break;
					case 19:
						floweyBattleLogic1.GetComponent<FloweyBattleLogic>().CircleBullet();
						break;
					/*case 9:
					case 13:
					case 16:
						gameObject.SetActive(true);
						break;*/
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