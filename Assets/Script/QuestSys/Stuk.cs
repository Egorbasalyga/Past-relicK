using UnityEngine;

public class Stuk : InteractParent
{
    public AudioSource audioSource;

    // Метод для проигрывания звука
    public override void Interact()
    {
        audioSource.Play();
    }
   
}
