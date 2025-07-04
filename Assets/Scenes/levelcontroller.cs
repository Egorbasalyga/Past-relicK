using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcontroller : MonoBehaviour
{
	void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
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
