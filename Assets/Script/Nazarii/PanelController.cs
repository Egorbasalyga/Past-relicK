using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panelToToggle; 
    public Button openButton; 
    public Button closeButton; 

    void Start()
    {
       
        panelToToggle.SetActive(false);

        
        openButton.onClick.AddListener(TogglePanel);
        closeButton.onClick.AddListener(ClosePanel);
    }

    
    public void TogglePanel()
    {
        panelToToggle.SetActive(!panelToToggle.activeSelf);
    }

    
    public void ClosePanel()
    {
        panelToToggle.SetActive(false);
    }
}