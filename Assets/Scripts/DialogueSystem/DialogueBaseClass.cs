using System.Collections; // IEnumerator
using UnityEngine;
using UnityEngine.UI; // Text

namespace DialogueSystem // 충돌 최소화하기 위해 namespace 사용
{
	public class DialogueBaseClass : MonoBehaviour
	{
		/*public bool finished { get; private set; }
		protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound, float delayBetweenLines)
		{
			textHolder.color = textColor;
			textHolder.font = textFont;

			for (int i = 0; i < input.Length; i++)
			{
				if (Input.GetKey(KeyCode.X))
				{
					for (int j = i; j < input.Length; j++)
					{
						textHolder.text += input[j];
					}
					i = input.Length - 1;

					textHolder.text += input[i];
					SoundManager1.instance.PlaySound(sound);
					yield return new WaitForSeconds(delay);
				}
				yield return new WaitForSeconds(delayBetweenLines);
			}
			yield return new WaitUntil(() => Input.GetKey(KeyCode.Z));

			finished = true;
		}*/

		public bool finished {get; private set; }
		protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont,
			float delay, AudioClip sound, float delayBetweenLine)
		{
			textHolder.color = textColor;
			textHolder.font = textFont;

			for(int i = 0; i < input.Length; i++)
			{
				textHolder.text += input[i];
				SoundManager.instance.PlaySound(sound);
				yield return new WaitForSeconds(delay);
			}
			yield return new WaitForSeconds(delayBetweenLine);

			finished = true;
		}
	}
}
