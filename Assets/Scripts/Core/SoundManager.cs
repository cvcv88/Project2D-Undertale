using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance { get; private set; }

	private AudioSource source;

	private void Awake()
	{
		instance = this;
		source = GetComponent<AudioSource>();
	}

	public void PlaySound(AudioClip sound)
	{
		source.PlayOneShot(sound);
	}
}
