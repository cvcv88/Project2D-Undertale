using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FloweyBattleDialogueClass
{
	public class FloweyBattleDialogueBaseClass : MonoBehaviour
	{
		static int i;
		public bool finished { get; private set; }
		protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont,
			float delay, AudioClip sound)
		{
			textHolder.color = textColor;
			textHolder.font = textFont;

			for (i = 0; i < input.Length; i++)
			{
				textHolder.text += input[i];
				if (Input.GetKey(KeyCode.X))
				{
					for (int j = i + 1; j < input.Length; j++)
					{
						textHolder.text += input[j];
					}
					i = input.Length - 1;
				}
				SoundManager.instance.PlaySound(sound);
				yield return new WaitForSeconds(delay);
			}
			if (i != 4)
				yield return new WaitUntil(() => Input.GetKey(KeyCode.Z));
			else
				yield return new WaitForSeconds(3f);


			finished = true;
		}
	}
}

