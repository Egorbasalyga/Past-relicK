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
        if (other.CompareTag("Player") && !isActive && quest.id == questStage-1)
        {
            InitializeDialog();
        }
    }
    protected override void FinishDialog()
    {
        base.FinishDialog();
        quest.NextQuest(questStage);
        Destroy(this);
    }
}
