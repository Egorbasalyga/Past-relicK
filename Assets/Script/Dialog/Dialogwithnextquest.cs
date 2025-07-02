using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class Dialogwithnextquest : DialogBase
{
    [SerializeField] private Quest quest;
    [SerializeField] private int questStage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            InitializeDialog();
        }
    }
    protected override void FinishDialog()
    {
        base.FinishDialog();
         Debug.Log("fdf");
        quest.NextQuest(questStage);
        Destroy(this);
    }
}
