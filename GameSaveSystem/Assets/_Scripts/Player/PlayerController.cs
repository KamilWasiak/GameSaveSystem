using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour, ISaveable
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float mouseSensitivity = 2f;

    private float verticalRotation = 0f;
    private CharacterController characterController;

    [SerializeField]
    private Vector3 playerPosition;
    private string playerPositionKey;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Hide and lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerPositionKey = ("PlayerPosition");
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

        playerPosition = transform.position;

        Debug.Log(playerPosition);
    }

    public void LoadData(GameData data)
    {
        data.playerPosition.TryGetValue(playerPositionKey, out playerPosition);
        transform.position = playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        if (data.playerPosition.ContainsKey(playerPositionKey))
        {
            data.playerPosition.Remove(playerPositionKey);
        }
        data.playerPosition.Add(playerPositionKey, playerPosition);
    }
}