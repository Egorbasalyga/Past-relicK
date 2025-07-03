using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class Dialoge : DialogBase
{
   
    public void StartDialog()
    {
        if (!isActive) InitializeDialog();
    }

    protected override void FinishDialog()
    {
        base.FinishDialog();
        Destroy(this);
    }
}
