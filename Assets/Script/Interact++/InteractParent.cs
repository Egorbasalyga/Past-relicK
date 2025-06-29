using UnityEngine;

public abstract class InteractParent : MonoBehaviour
{
   public GameObject playerHeldItem; 
   public abstract void Interact();
}
