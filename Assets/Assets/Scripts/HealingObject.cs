using UnityEngine;
using System.Linq;

public class HealingObject : MonoBehaviour
{
    public int healingAmount = 20; // Montant de guérison lorsque le joueur marche sur l'objet
    public ArrowDirection arrow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            // Le joueur a marché sur l'objet, déclencher la guérison
            other.transform.parent.GetComponent<PlayerHealth>().HealPlayer(healingAmount);


            Destroy(gameObject); // Détruire l'objet après utilisation

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
