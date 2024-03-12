using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIntro : MonoBehaviour
{
	public Image Img_Renderer;
	public Sprite[] sprite;

	public GameObject scrollImage;

	Coroutine coroutine;
	private void Start()
	{
		coroutine = StartCoroutine(ChangeIntroImages());
	}

	IEnumerator ChangeIntroImages()
	{
		for (int i = 0; i < sprite.Length; i++)
		{
			yield return new WaitForSeconds(1f);
			Img_Renderer.sprite = sprite[i];

			if(i == sprite.Length - 2)
			{
				scrollImage.SetActive(true);
				while (scrollImage.transform.position.y < 400)
				{
					scrollImage.transform.Translate(Vector2.up * 400f * Time.deltaTime);
					yield return null;
				}
				scrollImage.SetActive(false);
			}
		}
	}
}
