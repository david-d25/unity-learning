using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private GameInput gameInput;

    private bool isWalking = false;

    private void Update() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new(inputVector.x, 0, inputVector.y);

        isWalking = moveDirection != Vector3.zero;

        float rotationSpeed = 10;

        transform.position += moveDirection * Time.deltaTime * moveSpeed;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
    }

    public bool IsWalking() {
        return isWalking;
    }
}
