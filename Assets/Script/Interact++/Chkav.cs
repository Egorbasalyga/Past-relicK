using UnityEngine;
using System.Collections.Generic;
public class Chkav : InteractParent
{
    public override void Interact()
    {
        if (playerHeldItem != null)
        {
            SuitMarker luggage = playerHeldItem.GetComponent<SuitMarker>();

            if (luggage != null &&
                acceptedTypes.Contains(luggage.luggageType) 
            {
              Debug.Log("true");
            }
        }
    }

}
