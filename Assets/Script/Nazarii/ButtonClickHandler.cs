using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public Pc pc;
    public Button myButton; 

    void Start()
    {
        myButton.onClick.AddListener(TaskOnClick);
    }

    
    void TaskOnClick()
    {
        pc.off();
    }
}