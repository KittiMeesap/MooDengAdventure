using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private PlayerInput playerInput;
    private CharacterController controller;
    private Transform cameraTransform;
    private Vector3 playerVelocity;
    private bool groundPlayer;
    private Animator animator;
    private Transform currentItem;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        groundPlayer = controller.isGrounded;

        if (groundPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0.0f;

        controller.Move(move*Time.deltaTime*playerSpeed);

        if (playerInput.actions["Jump"].triggered && groundPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (playerInput.actions["Get Item"].triggered && currentItem != null)
        {
            currentItem.GetComponent<CollectibleItem>().Collect();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            currentItem = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            currentItem = null;
        }
    }

}
