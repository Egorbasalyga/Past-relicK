using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public Button myButton; 

    void Start()
    {
        
        if (myButton == null)
        {
            Debug.LogError("Кнопка не назначена! Пожалуйста, перетащите ссылку на кнопку в инспекторе.");
            return; 
        }

        
        myButton.onClick.AddListener(TaskOnClick);
    }

    
    void TaskOnClick()
    {
        Debug.Log("Кнопка нажата!"); 
    }
}