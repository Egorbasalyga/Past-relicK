using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

[System.Serializable]
public class Dialog
{
    public string name;
    public string text;
          
       
       
}
public class DialogTrigerSY : MonoBehaviour
{
    private PanelManage instancR;
    public List<Dialog> DialogTN;
    public float Speed;
    public bool one = true; 
    private bool ind = true;
    private int lastline;
    private int maxline;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton0))&&!ind){
         if(instancR.UrlText.text == DialogTN[lastline].text){
            NextLine();
         }else{
            StopAllCoroutines();
            instancR.UrlText.text = DialogTN[lastline].text;
         }
        }
        
    }
    void NextLine(){
        instancR.UrlText.text = "";
        if(lastline < maxline){
            lastline++;
             instancR.UrlName.text = DialogTN[lastline].name;
        StartCoroutine(TLine());
        }else if(one){
            
             instancR.UrlName.text = "";
             instancR.HidePanel();
             Destroy(this);
        }else{
             instancR.UrlName.text = "";
             instancR.HidePanel();
        }
         
       
    }

    IEnumerator TLine(){
        foreach(char c in DialogTN[lastline].text.ToCharArray()){
            instancR.UrlText.text += c;
            yield return new WaitForSeconds(Speed);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player") && ind) 
        {
            ind = false;
            instancR = PanelManage.instance;
            instancR.ShowPanel();
            maxline = DialogTN.Count - 1;
            instancR.UrlText.text = "";
            lastline = 0;
            instancR.UrlName.text = DialogTN[lastline].name;
            StartCoroutine(TLine());
           
        }
    }
    void OnTriggerExit(Collider other)
    {
        
        if(other.CompareTag("Player")) 
        {
            ind = true;
            StopAllCoroutines();
            instancR.UrlName.text = "";
            instancR.HidePanel();
           
        }
    }
}
 