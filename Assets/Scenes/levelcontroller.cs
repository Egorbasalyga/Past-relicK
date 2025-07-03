using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcontroller : MonoBehaviour
{
	public void ChangeScenes(int numberScenes)
	{
		SceneManager.LoadScene(numberScenes);
	}
	public void OnClickExit()
	{
		Debug.Log("Exit");
		Application.Quit();
	}
}
