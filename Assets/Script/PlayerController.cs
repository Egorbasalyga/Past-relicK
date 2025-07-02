using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
	[SerializeField] private float gamepadSensitivity = 100f;
	[SerializeField] private float verticalLookLimit = 80f;
	[SerializeField] private Transform playerCamera;
	public float walkSpeed = 5;
    public float runSpeed = 10;
    public float gravity = -9;
    private bool wasTriggerPressedLastFrame = false;
	public Transform holdPosition;
    public float interactDistance = 3f;
	public float throwForce = 3f;
    public GameObject heldObject = null;
    public Rigidbody heldRigidbody;
    private float triggerThreshold = 0.9f;
    private CharacterController controller;
    public TextMeshProUGUI Info;
    private Vector3 velocity;
    private float rotationX = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


   void Update()
    {
        HandleLook();
        HandleMovement();
        Check();
        if (heldObject == null)
        {
            heldRigidbody = null;
        }
         if (Input.GetMouseButtonDown(0))
        {
            if (!TryInteract())
            {
                if (heldObject == null)
                {
                    TryPickUp();
                


                }
                else
                {
                    DropObject();
                }
            }
           
        }

       float triggerValue = Input.GetAxis("RightTrigger");
    bool isPressed = triggerValue >= triggerThreshold;

    if (isPressed && !wasTriggerPressedLastFrame)
    {
        if (!TryInteract())
        {
            if (heldObject == null)
            {
                TryPickUp();
                


            }
            else
            {
                DropObject();
            }
        }

    }

    wasTriggerPressedLastFrame = isPressed;
         if (heldObject != null)
        {
            heldObject.transform.position = holdPosition.position;
        }
    }
     void TryPickUp()
    {
        
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.CompareTag("Pickup"))
            {
                heldObject = hit.collider.gameObject;
                heldRigidbody = heldObject.GetComponent<Rigidbody>();

                if (heldRigidbody != null)
                {
                    heldObject.transform.localScale = heldObject.transform.localScale/4;
                    heldRigidbody.useGravity = false;
                    heldRigidbody.linearVelocity = Vector3.zero;
                    heldRigidbody.angularVelocity = Vector3.zero;
                    heldRigidbody.freezeRotation = true;
                }

                heldObject.transform.SetParent(holdPosition);
                heldObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }

   void DropObject() 
	{
   		if (heldObject != null) {
        	heldObject.transform.SetParent(null);
      	 	if (heldRigidbody != null)
      	    {
				heldObject.transform.localScale = heldObject.transform.localScale*4;
      	        heldRigidbody.useGravity = true;
      	        heldRigidbody.freezeRotation = false;
       	        heldRigidbody.linearVelocity = playerCamera.forward * throwForce;
    		}
       	 	heldObject = null;
       	 	heldRigidbody = null;
   		 }
	}
     private bool TryInteract()
    {
        
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            InteractParent interactable = hit.collider.GetComponent<InteractParent>();
            if (interactable != null)
            {
			
                interactable.Interact();
				
                return true;
            }
            else
            {
                return false;
            }
        } else
        {
            return false;
        }
    }
    private void Check()
{
    Ray ray = new Ray(playerCamera.position, playerCamera.forward);
    if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
    {
        InteractParent interactable = hit.collider.GetComponent<InteractParent>();
        bool isPickup = hit.collider.CompareTag("Pickup");

        if (interactable != null || isPickup)
        {
            Info.text = "Use";
        }
        else if (heldObject == null)
        {
            Info.text = "";
        }
    }
    else if(heldObject == null)
    {
        Info.text = "";
    }
}

  private void HandleLook()
{
    float lookX = 0f;
    float lookY = 0f;

    bool isGamepadActive = Mathf.Abs(Input.GetAxis("RightStickHorizontal")) > 0.1f || Mathf.Abs(Input.GetAxis("RightStickVertical")) > 0.1f;

    if (isGamepadActive)
    {
        // Управление с геймпада
        lookX = Input.GetAxis("RightStickHorizontal") * gamepadSensitivity * Time.deltaTime;
        lookY = Input.GetAxis("RightStickVertical") * gamepadSensitivity * Time.deltaTime;
    }
    else
    {
        // Управление с мыши
        lookX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        lookY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }

    rotationX -= lookY;
    rotationX = Mathf.Clamp(rotationX, -verticalLookLimit, verticalLookLimit);

    playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    transform.Rotate(Vector3.up * lookX);
}



    private void HandleMovement()
    {
        bool isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
