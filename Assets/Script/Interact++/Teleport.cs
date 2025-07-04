using UnityEngine;

public class Teleport : InteractParent
{
    public Transform waypoint;
    public Rigidbody player;
    public override void Interact()
    {
        player.transform.position = waypoint.position;
        
    }
}
