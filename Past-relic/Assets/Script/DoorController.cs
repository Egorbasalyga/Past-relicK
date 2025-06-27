using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f; 
    public float openSpeed = 2f; 
    private bool isOpen = false;
    private bool inTrigger = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        
        closedRotation = transform.parent.rotation;
        openRotation = Quaternion.Euler(transform.parent.eulerAngles + Vector3.up * openAngle);
    }

    void Update()
    {
        
        if(inTrigger && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton2)))
        {
            isOpen = !isOpen;
        }

        
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

    void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player")) 
        {
            inTrigger = true;
            
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}