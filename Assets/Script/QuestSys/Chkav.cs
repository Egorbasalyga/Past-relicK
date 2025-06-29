using UnityEngine;
using System.Collections.Generic;
public class Chkav : InteractParent
{
    public GameObject player;
    public Quest quest;
    private int l = 0;

    void Update()
    {
        if (l == 4)
        {               
            quest.NextQuest(1);
            Dialoge dscript = GetComponent<Dialoge>();
            if (dscript != null)
            {
                dscript.DStart(); 
            }
            Destroy(this);
        }
    }
    public override void Interact()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController.heldObject != null)
        {
            
            if (playerController.heldObject.GetComponent<SuitMarker>() != null)
            {
                l++;
                Destroy(playerController.heldObject);
                playerController.heldObject = null;
                playerController.heldRigidbody = null;
            }
            
        }
    }
}
