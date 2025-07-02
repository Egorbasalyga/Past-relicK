using UnityEngine;
public class DialogTriggerSY : DialogBase
{
    [SerializeField] private bool destroyOnFinish = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
       
            InitializeDialog();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !destroyOnFinish)
        {
           
            if (isActive)
            {
                StopAllCoroutines();
                panelInstance.HidePanel();
                isActive = false;
            }
        }
    }
    protected override void FinishDialog()
    {
        base.FinishDialog();
        if (destroyOnFinish) Destroy(this);
    }
}