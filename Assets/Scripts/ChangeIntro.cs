using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIntro : MonoBehaviour
{
    public Image Img_Renderer;
    public Sprite[] sprite;

	private void Start()
	{
		StartCoroutine(ChangeIntroImages());
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			StopCoroutine(ChangeIntroImages());
			Img_Renderer.sprite = sprite[sprite.Length - 1];
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
