using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class Dialogwithnextquest : MonoBehaviour
{
    [System.Serializable]
    public class Dialog
    {
        public string name;
        public string text;
        //test git
       
       
    }

    private Rigidbody palyers;
    public Quest quest;
    private PanelManage instancR;
    public List<Dialog> DialogTNs;
    public float Speed;
    public int lic = 0;
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
         if(instancR.UrlText.text == DialogTNs[lastline].text){
            NextLine();
         }else{
            StopAllCoroutines();
            instancR.UrlText.text = DialogTNs[lastline].text;
         }
        }
        
    }
    void NextLine(){
        instancR.UrlText.text = "";
        if(lastline < maxline){
            lastline++;
             instancR.UrlName.text = DialogTNs[lastline].name;
        StartCoroutine(TLine());
        }else{
            
             instancR.UrlName.text = "";
             instancR.HidePanel();
             quest.NextQuest(lic);
             Destroy(this);
        }
         
       
    }

    IEnumerator TLine(){
        foreach(char c in DialogTNs[lastline].text.ToCharArray()){
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
            maxline = DialogTNs.Count - 1;
            instancR.UrlText.text = "";
            lastline = 0;
            instancR.UrlName.text = DialogTNs[lastline].name;
            StartCoroutine(TLine());
           
        }
    }
   
}
