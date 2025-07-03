using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DiIalogBlack : DialogBase
{
    [SerializeField] private Quest quest;
    public Image lio;
    public int nextscen;
    public int questequal;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive && questequal == quest.id)
        {
             lio.gameObject.SetActive(true);
            InitializeDialog();
        }
    }
    protected override void FinishDialog()
    {
        base.FinishDialog();
        SceneManager.LoadScene(nextscen);
        
    }
}
