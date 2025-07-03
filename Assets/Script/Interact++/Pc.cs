using UnityEngine;
using UnityEngine.UI;
public class Pc : InteractParent
{
    public PlayerController player;
    public Canvas lio;
    public Collider box;
    void Start()
    {
        lio.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        lio.gameObject.SetActive(true);
      box.enabled = false;
      player.Rcam = false;
      player.nond = false;
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;

    }
    void Update()
    {
        
    }
}
