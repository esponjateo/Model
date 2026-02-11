using UnityEngine;
using UnityEngine.InputSystem;

public class TREEDMoveAnim : MonoBehaviour
{
    [SerializeField] float roationFactorPerFrame;
    [SerializeField] SaveSystem SavePosition;

    PlayerInputSystem inputSystem;
    CharacterController Controller;
    Animator animator;

    Vector3 currentInputMovement;
    bool isMovementPressed;

    private void Awake()
    {
        inputSystem = new PlayerInputSystem();
        Controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        SavePosition.Load();

        inputSystem.PlayerMovement.Move.performed += OnMovementInputs;
        inputSystem.PlayerMovement.Move.performed += SavePlayerDetails;
    }


    private void OnEnable() => inputSystem.PlayerMovement.Enable();

    private void OnDisable() => inputSystem.PlayerMovement.Disable();

    private void Update()
    {
        HandleRotation();
        HandleAnimation();
        Controller.Move(currentInputMovement * Time.deltaTime);
    }

    private void OnMovementInputs(InputAction.CallbackContext context)
    {
        Vector2 inputMovement = context.ReadValue<Vector2>();
        currentInputMovement.x = inputMovement.x;
        currentInputMovement.z = inputMovement.y;
        isMovementPressed = inputMovement.x !=0 || inputMovement.y !=0;
    }


    private void HandleRotation()
    {
        if (isMovementPressed)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);
    }

    private void HandleAnimation()
    {
        Vector3 positionToLookAt;

        positionToLookAt.x = currentInputMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentInputMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovementPressed)
        {
            Quaternion targetRot = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRot, roationFactorPerFrame * Time.deltaTime); 
        }
    }



    private void SavePlayerDetails(InputAction.CallbackContext context)
    {
        SavePosition.Save(transform.position, transform.rotation);
    }

}
