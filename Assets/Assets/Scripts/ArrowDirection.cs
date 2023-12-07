using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    public Transform targetObject;  // Référence vers l'objet cible

    void Update()
    {
        // print(targetObject);
        if (targetObject != null)
        {
            Vector3 targetPosition = targetObject.transform.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
    }

    // Fonction pour changer l'objet cible de la flèche
    public void SetTargetObject(Transform newTarget)
    {
        targetObject = newTarget;
    }
}