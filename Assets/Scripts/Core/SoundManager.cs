using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance { get; private set; }

	private AudioSource source;
	private AudioClip changeAudioClip;

	private void Awake()
	{
		instance = this;
		source = GetComponent<AudioSource>();
	}

	public void PlaySound(AudioClip sound)
	{
		source.PlayOneShot(sound);
	}

	public void PauseSound()
	{
		source.Pause();
	}
	public void ChangeSound(AudioClip changeAudioClip)
	{
		source.clip = changeAudioClip;
	}
}
