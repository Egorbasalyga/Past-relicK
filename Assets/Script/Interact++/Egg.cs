using UnityEngine;
using UnityEngine.SceneManagement;

public class Egg : InteractParent
{
    public int nextscen;
    public override void Interact()
    {
        SceneManager.LoadScene(nextscen);
    }
}
