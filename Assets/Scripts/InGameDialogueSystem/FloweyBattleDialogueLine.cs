using UnityEngine;
using UnityEngine.UI;

namespace FloweyBattleDialogueClass
{
	public class FloweyBattleDialogueLine : FloweyBattleDialogueBaseClass
	{
		[Header("Text Options")]
		private Text textHolder;
		[TextArea]
		[SerializeField] private string input;
		[SerializeField] private Color textColor;
		[SerializeField] private Font textFont;

		[Header("Time parameter")]
		[SerializeField] private float delay;

		[Header("Sound")]
		[SerializeField] private AudioClip sound;

		private void Awake()
		{
			textHolder = GetComponent<Text>();
			textHolder.text = "";
		}

		private void Start()
		{
			StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound));
		}
	}
}


