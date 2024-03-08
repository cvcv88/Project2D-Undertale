using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Collections;
using UnityEngine;

public class ScriptController : MonoBehaviour
{
#if UNITY_EDITOR
	private string path = $"{Application.dataPath}/Data";
#else
	private string path = $"{Application.persistentDataPath}/Data";
#endif

	public GameData1 gameData;

	public Coroutine coroutine;

	public bool a = false;

	public TextMeshProUGUI textComponent;
	public string[] lines;

	private void Start()
	{
		StartCoroutine(TypeLine1(gameData));
		textComponent.text = string.Empty;
	}

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			coroutine = StartCoroutine(TypeLine1(gameData));
		}
		StopCoroutine(coroutine);
	}

	[ContextMenu("Save")]
	public void Save()
	{
		Debug.Log(path);
		if (Directory.Exists(path) == false)
		{
			Directory.CreateDirectory(path);
		}

		string filePath = Path.Combine(path, "Test.txt");
		string json = JsonUtility.ToJson(gameData, true); // json 규칙에 맞게 바꾸기
														  // File.WriteAllText(path, "abcdefg");
		File.WriteAllText(filePath, json);
	}

	[ContextMenu("Load")]
	public void Load()
	{
		string filePath = Path.Combine(path, "Test.txt");
		if (File.Exists(filePath))
		{
			string json = File.ReadAllText(filePath);
			gameData = JsonUtility.FromJson<GameData1>(json);
			TypeLine1(gameData);
		}
		else
		{
			Debug.Log("저장한 데이터 없음");
		}
	}
	IEnumerator TypeLine1(GameData1 gamedata)
	{
		yield return new WaitForSeconds(0.1f); 
		// print(gameData.scripts1);

		yield return new WaitForSeconds(1f);
		print(gameData.scripts2);
		yield return new WaitForSeconds(1f);
		print(gameData.scripts3);
		yield return new WaitForSeconds(1f);
		a = true;
	}
}

[Serializable]
public class GameData1
{
	public string scripts1 = "1";
	public string scripts2 = "2";
	public string scripts3 = "3";
}
