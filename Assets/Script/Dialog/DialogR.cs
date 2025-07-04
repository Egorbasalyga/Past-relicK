using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class DialogR : DialogBase
{
    [SerializeField] private Quest quest;
    [SerializeField] public RUN r;
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
       r.StartWalk();
        Destroy(this);
    }
}
