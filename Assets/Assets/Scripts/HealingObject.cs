using UnityEngine;

public class HealingObject : MonoBehaviour
{
    public int healingAmount = 20; // Montant de guérison lorsque le joueur marche sur l'objet

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        if (other.CompareTag("PlayerBody"))
        {
            // Le joueur a marché sur l'objet, déclencher la guérison
            other.transform.parent.GetComponent<PlayerHealth>().HealPlayer(healingAmount);
            Destroy(gameObject); // Détruire l'objet après utilisation
        }
    }
}
