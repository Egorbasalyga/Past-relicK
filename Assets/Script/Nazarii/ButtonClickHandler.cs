using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public Button myButton; 

    void Start()
    {
        
        if (myButton == null)
        {
            Debug.LogError("������ �� ���������! ����������, ���������� ������ �� ������ � ����������.");
            return; 
        }

        
        myButton.onClick.AddListener(TaskOnClick);
    }

    
    void TaskOnClick()
    {
        Debug.Log("������ ������!"); 
    }
}