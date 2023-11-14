using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Référence au transform du personnage à suivre
    public float distance = 3f; // Distance entre la caméra et le personnage
    public float height = 1f; // Hauteur de la caméra par rapport au personnage
    public float smoothSpeed = 0.925f; // Vitesse de suivi de la caméra

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Aucune cible définie pour la caméra de suivi.");
            return;
        }

        // Calculer la rotation souhaitée de la caméra en fonction de la rotation du personnage
        Quaternion desiredRotation = target.rotation;

        // Appliquer la rotation souhaitée de la caméra
        transform.rotation = desiredRotation;

        // Calculer la position souhaitée de la caméra
        Vector3 desiredPosition = target.position - target.forward * distance + target.up * height;

        // Interpoler doucement entre la position actuelle et la position souhaitée
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Définir la position de la caméra
        transform.position = smoothedPosition;
    }
}