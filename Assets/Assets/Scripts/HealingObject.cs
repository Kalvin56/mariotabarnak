using UnityEngine;
using System.Linq;

public class HealingObject : MonoBehaviour
{
    public int healingAmount = 75; // Montant de guérison lorsque le joueur marche sur l'objet
    public ArrowDirection arrow;
    public AudioClip pickupSound; // Son à jouer lors du ramassage de l'objet

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            // Le joueur a marché sur l'objet, déclencher la guérison
            other.transform.parent.GetComponent<PlayerHealth>().HealPlayer(healingAmount);

            GameObject audioObject = new GameObject("TempAudioObject");
            AudioSource tempAudioSource = audioObject.AddComponent<AudioSource>();
            tempAudioSource.clip = pickupSound;

            // Jouer le son
            tempAudioSource.Play();

            // Détacher le son de l'objet principal
            tempAudioSource.transform.parent = null;

            Destroy(gameObject); // Détruire l'objet après utilisation

            // Détruire l'objet audio après la fin du son
            Destroy(audioObject, pickupSound.length);

            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("PickUp");
            objectsWithTag = objectsWithTag.Where(obj => obj != gameObject).ToArray();

            if (objectsWithTag.Length > 0){
                int randomIndex = Random.Range(0, objectsWithTag.Length);
                GameObject randomObject = objectsWithTag[randomIndex];
                arrow.SetTargetObject(randomObject.transform);
            }else{
                Destroy(arrow);
            }
        }
    }
}
