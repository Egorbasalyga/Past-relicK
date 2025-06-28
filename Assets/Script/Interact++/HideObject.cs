using UnityEngine;

public class HideObject : InteractParent
{
    public bool ishide = true;
    public bool one = false;
   public GameObject objectToHide;
   void Start()
    {
         objectToHide.SetActive(ishide);
         ishide = !ishide; 
    }
   public override void Interact()
    {
        
         objectToHide.SetActive(ishide);
         ishide = !ishide;
         if(one){
            Destroy(this);
         }
    }
}
