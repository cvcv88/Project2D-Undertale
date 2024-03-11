using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class AudioController : MonoBehaviour
{
	public AudioClip changeAudioClip;

	[SerializeField] private Image image;
	[SerializeField] private Sprite sprite;

	private void Update()
	{
		if (image.sprite.name == sprite.name)
		{
			SoundManager.instance.ChangeSound(changeAudioClip);
		}
	}
}
