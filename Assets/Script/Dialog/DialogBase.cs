using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public abstract class DialogBase : MonoBehaviour
{
    [System.Serializable]
    public class Dialog
    {
        public string name;
        public string text;
    }

    protected PanelManage panelInstance;
    protected int currentLine;
    protected int maxLine;
    protected bool isActive = false;
    [SerializeField] protected List<Dialog> dialogs = new List<Dialog>();
    [SerializeField] protected float speed = 0.05f;

    
    protected PlayerController playerMovement;

   
    protected virtual void DisablePlayerMovement()
    {
        if (playerMovement != null)
        {
            playerMovement.enabled = false; 
        }
        else
        {
            Debug.LogWarning("PlayerMovement не найден! Убедитесь, что он назначен в инспекторе.");
        }
    }

   
    protected virtual void EnablePlayerMovement()
    {
        
        if (playerMovement != null)
        {
            playerMovement.enabled = true; 
        }
    }

    protected virtual void Update()
    {
        if (isActive && (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton0)))
        {
            if (panelInstance.UrlText.text == dialogs[currentLine].text)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                panelInstance.UrlText.text = dialogs[currentLine].text;
            }
        }
    }

    protected void InitializeDialog()
    {
        panelInstance = PanelManage.instance;
        panelInstance.ShowPanel();
        currentLine = 0;
        maxLine = dialogs.Count - 1;
        panelInstance.UrlText.text = "";
        panelInstance.UrlName.text = dialogs[currentLine].name;
        StartCoroutine(TypeLine());
        isActive = true;

        
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerController>();
            DisablePlayerMovement();
        }
        else
        {
            Debug.LogError("Игрок с тегом 'Player' не найден на сцене!");
        }
    }

    protected IEnumerator TypeLine()
    {
        panelInstance.UrlText.text = "";
        foreach (char c in dialogs[currentLine].text.ToCharArray())
        {
            panelInstance.UrlText.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    protected void NextLine()
    {
        currentLine++;
        if (currentLine <= maxLine)
        {
            panelInstance.UrlName.text = dialogs[currentLine].name;
            StartCoroutine(TypeLine());
        }
        else
        {
            FinishDialog();
        }
    }

    protected virtual void FinishDialog()
    {
        panelInstance.UrlName.text = "";
        panelInstance.HidePanel();
        isActive = false;

       
        EnablePlayerMovement();
    }
}