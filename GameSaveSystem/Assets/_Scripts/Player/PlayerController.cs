using UnityEngine;

public class PlayerController : MonoBehaviour, ISaveable
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;

    private float verticalRotation = 0f;
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Hide and lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Player movement
        float moveForward = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        float moveSide = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        Vector3 movement = transform.forward * moveForward + transform.right * moveSide;
        characterController.Move(movement);

        // Player rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player horizontally
        transform.Rotate(0f, mouseX, 0f);

        // Rotate the camera vertically
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
    }
}