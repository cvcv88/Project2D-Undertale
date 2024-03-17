using UnityEngine;
using UnityEngine.UI; // Text

namespace DialogueSystem
{
	public class DialogueLine : DialogueBaseClass
	{
		[Header("Text Options")]
		private Text textHolder;
		[TextArea]
		[SerializeField] private string input;
		[SerializeField] private Color textColor;
		[SerializeField] private Font textFont;

		[Header("Time parameter")]
		[SerializeField] private float delay;
		[SerializeField] private float delayBetweenLine;

		[Header("Sound")]
		[SerializeField] private AudioClip sound;

		private void Awake()
		{
			textHolder = GetComponent<Text>();
			textHolder.text = "";
		}

		private void Start()
		{
			StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLine));
		}
    }
}

