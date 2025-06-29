using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
public class Quest : MonoBehaviour
{
int id = 0;
public TextMeshProUGUI UrlText;
public List<string> quest;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UrlText.text = quest[id];
    }

    // Update is called once per frame
    void Update()
    {
        
        if(UrlText.text != quest[id]){
            UrlText.text = quest[id];
        }
    }

    public void NextQuest(int i)
    {
        if(i == id+1)
        {
            id++;
        }
    }
}
