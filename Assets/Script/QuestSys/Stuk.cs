using UnityEngine;

public class Stuk : MonoBehaviour
{
    [SerializeField] private AudioClip soundClip; // Ссылка на аудиофайл
    
    private AudioSource audioSource;

    void Start()
    {
    
        audioSource = gameObject.AddComponent<AudioSource>();
        

        audioSource.playOnAwake = false;
        audioSource.volume = 0.8f;
    }

    // Вызовите этот метод для проигрывания
    public void PlaySoundOnce()
    {
        if (soundClip != null)
        {
            // Проигрывает звук ОДИН раз без привязки к источнику
            audioSource.PlayOneShot(soundClip);
        }
        else
        {
            Debug.LogError("Sound clip is missing!");
        }
    }
}
