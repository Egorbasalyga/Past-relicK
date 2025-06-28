using UnityEngine;

public class DoorClick : InteractParent
{
    public float openAngle = 90f; 
    public float openSpeed = 2f; 
    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
 void Start()
    {
        
        closedRotation = transform.parent.rotation;
        openRotation = Quaternion.Euler(transform.parent.eulerAngles + Vector3.up * openAngle);
    }
    public override void Interact()
    {
      isOpen = !isOpen;
      
    }
      void Update()
    {
        
        if(isOpen)
        {
            transform.parent.rotation = Quaternion.Slerp(
                transform.parent.rotation, 
                openRotation, 
                openSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.parent.rotation = Quaternion.Slerp(
                transform.parent.rotation, 
                closedRotation, 
                openSpeed * Time.deltaTime
            );
        }
    }

}
