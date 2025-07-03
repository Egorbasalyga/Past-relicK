using UnityEngine;

public class DoorQuestLock : InteractParent
{
    public Quest quest;
    private Quaternion openRotation;
    private bool isOpening = false;
    public int questnum;
    private float rotationProgress = 0f;
    private Quaternion startRotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openRotation = Quaternion.Euler(transform.parent.eulerAngles + Vector3.up * 90);
        
    }

    void Update()
    {
        if (isOpening)
        {
           
            rotationProgress += Time.deltaTime * 0.5f;
            transform.parent.rotation = Quaternion.Slerp(
                startRotation, 
                openRotation, 
                rotationProgress
            );
            
          
            if (rotationProgress >= 1f)
            {
                Destroy(this);
            }
        }
    }

    public override void Interact()
    {
     
        if (isOpening || quest.id != questnum) return;
        quest.NextQuest(1);

      
        startRotation = transform.parent.rotation;
        isOpening = true;
    }
}
