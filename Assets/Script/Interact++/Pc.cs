using UnityEngine;
using UnityEngine.UI;
public class Pc : InteractParent
{
    public Quest quest;
    public PlayerController player;
    public Canvas lio;
    public Collider box;
    private bool open = false;
    void Start()
    {
        lio.gameObject.SetActive(false);
    }

    public void off()
    {
        lio.gameObject.SetActive(false);
        box.enabled = true;
        player.Rcam = true;
        player.nond = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        quest.NextQuest(1);
        Destroy(this);
    }
    public override void Interact()
    {
        lio.gameObject.SetActive(true);
      box.enabled = false;
      player.Rcam = false;
      player.nond = false;
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
        open = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton0)&&open)
        {
            off();
        }
    }
}
