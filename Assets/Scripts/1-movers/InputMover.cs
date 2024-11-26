using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover : MonoBehaviour
{
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField]
    InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    [SerializeField]
    InputAction RotateLeft = new InputAction(type: InputActionType.Button);

    [SerializeField]
    InputAction RotateRight = new InputAction(type: InputActionType.Button);

    [SerializeField] public float RotationDegrees;

    [HideInInspector] public float StartingRotation;

    void OnEnable()
    {
        move.Enable();
        RotateLeft.Enable();
        RotateRight.Enable();
    }

    void OnDisable()
    {
        move.Disable();
        RotateLeft.Disable();
        RotateRight.Disable();
    }

    private void Start()
    {
        SetBorders();
        StartingRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        transform.position += movementVector;

        rotate();
        EnsureInBorders();
    }

    private Vector3 bottomLeftBorder, topRightBorder, spriteBounds;
    private void SetBorders()
    {
        bottomLeftBorder = SceneBorders.BottomLeft();
        topRightBorder = SceneBorders.TopRight();
        spriteBounds = GetComponent<SpriteRenderer>().bounds.size;

        bottomLeftBorder.x += spriteBounds.x / 2;
        bottomLeftBorder.y += spriteBounds.y / 2;
        topRightBorder.x -= spriteBounds.x / 2;
        topRightBorder.y -= spriteBounds.y / 2;
    }

    private void EnsureInBorders()
    {
        Vector3 position = transform.position;
        //position.x = Mathf.Clamp(position.x, bottomLeftBorder.x, topRightBorder.x);
        position.y = Mathf.Clamp(position.y, bottomLeftBorder.y, topRightBorder.y);
        transform.position = position;
    }

    private void rotate()
    {
        Vector3 currentRotation = transform.eulerAngles;
        if (RotateLeft.ReadValue<float>() > 0)
        {
            currentRotation.z = StartingRotation + RotationDegrees;
        }
        else if (RotateRight.ReadValue<float>() > 0)
        {
            currentRotation.z = StartingRotation - RotationDegrees;
        }
        else
        {
            currentRotation.z = StartingRotation;
        }
        transform.eulerAngles = currentRotation;
    }
}
