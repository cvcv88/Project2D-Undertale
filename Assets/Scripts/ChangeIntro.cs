using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIntro : MonoBehaviour
{
    public Image Img_Renderer;
    public Sprite[] sprite;

	Coroutine coroutine;
	private void Start()
	{
		coroutine = StartCoroutine(ChangeIntroImages());
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			Img_Renderer.sprite = sprite[sprite.Length - 1];
			StopCoroutine(coroutine);
		}
	}

	IEnumerator ChangeIntroImages()
	{
		for (int i = 0; i < sprite.Length; i++)
		{
			yield return new WaitForSeconds(3f);
			Img_Renderer.sprite = sprite[i];
			Debug.Log(sprite[i]);
		}
	}
}
