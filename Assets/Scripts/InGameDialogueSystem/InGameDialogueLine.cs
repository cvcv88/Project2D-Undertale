using UnityEngine;
using UnityEngine.UI; // Text

namespace InGameDialogueSystem
{
	public class InGameDialogueLine : InGameDialogueBaseClass
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

		[Header("Character Image")]
		[SerializeField] private Sprite characterSprite;
		[SerializeField] private Image imageHolder;

		[Header("Sound")]
		[SerializeField] private AudioClip sound;

		private void Awake()
		{
			textHolder = GetComponent<Text>();
			textHolder.text = "";

			imageHolder.sprite = characterSprite;
			imageHolder.preserveAspect = true;
		}

		private void Start()
		{
			StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound, delayBetweenLine));
		}

		private void Update()
		{
			if (Input.GetKey(KeyCode.Z) || input == "-")
			{

			}
		}
	}
}

