using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeIntro : MonoBehaviour
{
	public Image Img_Renderer;
	public Sprite[] sprite;

	public Image Portrait1;
	public Sprite portraitImage1;

	public float scrollSpeed = 10.0f;
	public Renderer backgroundRenderer;

	public Image Portrait2;
	public Sprite portraitImage2;

	Coroutine coroutine;
	private void Start()
	{
		coroutine = StartCoroutine(ChangeIntroImages());
		backgroundRenderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		if (sprite.Length == 10)
		{
			float offset = Time.time * scrollSpeed;
			// backgroundRenderer.material.mainTextureOffset = new Vector2(0, offset);
			backgroundRenderer.material.SetTextureOffset("Introduction_10", new Vector2(0, offset));
		}
	}

	IEnumerator ChangeIntroImages()
	{
		for (int i = 0; i < sprite.Length; i++)
		{
			yield return new WaitForSeconds(5f);
			Img_Renderer.sprite = sprite[i];
			/*if (i == sprite.Length - 2)
			{
				Portrait1.sprite = portraitImage1;
				RectTransform rect1 = (RectTransform)Portrait1.transform;
				rect1.sizeDelta = new Vector2(319, 345);
			}*/
		}
	}
}
