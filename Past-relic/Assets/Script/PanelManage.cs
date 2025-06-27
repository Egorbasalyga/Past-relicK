using UnityEngine;
using TMPro;
public class PanelManage : MonoBehaviour
{
    
public static PanelManage instance;
public TextMeshProUGUI UrlText;
public TextMeshProUGUI UrlName;
private void Awake(){
    instance = this;
      instance.HidePanel();
} 
   public void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public void ShowPanel()
    {
        gameObject.SetActive(true);
    }
}
