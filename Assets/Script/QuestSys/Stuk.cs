using UnityEngine;
using UnityEngine.UI;

public class Stuk : InteractParent
{
    public AudioSource audioSource;
    public Quaternion openRotation;
    public Image lio;
    public Quest quest;
    private bool isOpening = false;
    private float rotationProgress = 0f;
    private Quaternion startRotation;

    void Start()
    {
        openRotation = Quaternion.Euler(transform.parent.eulerAngles + Vector3.up * 90);
        lio.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isOpening)
        {
            // Плавное вращение в течение времени
            rotationProgress += Time.deltaTime * 0.5f; // Скорость открытия
            transform.parent.rotation = Quaternion.Slerp(
                startRotation, 
                openRotation, 
                rotationProgress
            );
            
          
            if (rotationProgress >= 1f)
            {
                lio.gameObject.SetActive(false);
                Destroy(this);
            }
        }
    }

    public override void Interact()
    {
     
        if (isOpening || quest.id != 1) return;
        
        audioSource.Play();
        lio.gameObject.SetActive(true);
        
        // Сохраняем начальное вращение
        startRotation = transform.parent.rotation;
        isOpening = true;
    }
}