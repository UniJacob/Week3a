using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component moves its object when the player clicks the arrow keys.
 */
public class InputMover: MonoBehaviour {
    [Tooltip("Speed of movement, in meters per second")]
    [SerializeField] float speed = 10f;

    [SerializeField] InputAction move = new InputAction(
        type: InputActionType.Value, expectedControlType: nameof(Vector2));

    void OnEnable()  {
        move.Enable();
    }

    void OnDisable()  {
        move.Disable();
    }

    private void Start()
    {
        SetBorders();
    }

    void Update() {
        Vector2 moveDirection = move.ReadValue<Vector2>();
        Vector3 movementVector = new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime;
        transform.position += movementVector;
        //transform.Translate(movementVector);
        // NOTE: "Translate(movementVector)" uses relative coordinates - 
        //       it moves the object in the coordinate system of the object itself.
        // In contrast, "transform.position += movementVector" would use absolute coordinates -
        //       it moves the object in the coordinate system of the world.
        // It makes a difference only if the object is rotated.

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
}
