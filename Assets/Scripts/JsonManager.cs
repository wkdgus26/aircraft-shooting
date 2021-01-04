using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class ScoreData
{
	public int[] scoreArray;
}
public class JsonManager : MonoBehaviour {
	public static JsonManager instance;
	public ScoreData scoreData;
	// Use this for initialization
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
		DataLoad();
	}
	public void DataAdd(int data) {	// score 값을 받아서 배열에 넣으면서 정렬
		for (int i = 0; i < scoreData.scoreArray.Length; i++)
		{
			if (scoreData.scoreArray[i] <= data) {
				for (int j = scoreData.scoreArray.Length-1; j > i; j--)
				{
					scoreData.scoreArray[j] = scoreData.scoreArray[j - 1];
				}
				scoreData.scoreArray[i] = data;
				DataSave();
				break;
			}
		}
	}
	public void DataSave() { // 저장처리
		File.WriteAllText(Application.dataPath + "/Resources/ScoreData.json", JsonUtility.ToJson(scoreData));
	}

	public void DataLoad() {
		string dataFilePath = Application.dataPath + "/Resources/ScoreData.json";
		FileInfo fileInfo = new FileInfo(dataFilePath);
		if (fileInfo.Exists) // 기존에 json파일이 있으면 load
		{
			string dataFile = File.ReadAllText(dataFilePath); // json 파일 읽어서 저장
			scoreData = JsonUtility.FromJson<ScoreData>(dataFile); // json파일 정보를 scoreData에 입력
		}
		else // 기존에 json파일이 없으면 creat
		{
			scoreData.scoreArray = new int[] { 1000, 300, 100, 50, 20, 10 };
			DataSave();
		}
	}
}
