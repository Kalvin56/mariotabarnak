using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float walkSpeed = 2.0f;
    public float runSpeed = 6.0f;
    public float jumpForce = 8.0f;
    public float rotationSpeed = 2.0f;
    public float backwardSpeed = 1.0f;

    private Animator animator;
    private Rigidbody rigidbody;
    private bool isGrounded;
    private bool isJumping;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Verrouiller le curseur au centre de l'écran
    }

    void Update()
    {
        // Vérifier si le personnage est au sol
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red, 1.0f);
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Gérer les mouvements
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0.0f, vertical).normalized;

        // Gérer la vitesse en fonction de la touche de course
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : vertical < 0 ? backwardSpeed : walkSpeed;

        // Appliquer le mouvement
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Gérer les animations
        float moveMagnitude = new Vector2(horizontal, vertical).magnitude;
        animator.SetFloat("Speed", moveMagnitude);

        // Gérer le saut
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Jump());
        }

        // Gérer la rotation de la caméra avec la souris
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(Vector3.up, mouseX);

        // Gérer le recul
        bool isMovingBackward = vertical < 0;
        animator.SetBool("IsMovingBackward", isMovingBackward);
    }

    IEnumerator Jump()
    {
        // Démarrer l'animation de saut
        animator.SetTrigger("JumpTrigger");
        isJumping = true;

        // Appliquer la force de saut
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Attendre jusqu'à ce que le personnage ne soit plus en l'air
        yield return new WaitUntil(() => isGrounded);

        // Le saut est terminé, désactiver le paramètre de saut
        isJumping = false;
        animator.SetBool("IsJumping", isJumping);
    }
}