using Unity.Netcode;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(ITeleportAction))]
[DefaultExecutionOrder(1)] 
public class PCClientPlayerMovement : PlayerMovement
{

    [SerializeField]
    private Camera _playerCamera;

    [Space]
    [Header("settings")]
    [SerializeField]
    private float _sensivity = 100f;
    [SerializeField]
    private float _speed = 12f;

    private CharacterController _controller;
    private ITeleportAction _teleportAction;
    private float _xRotation;
    private Transform _camera;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _teleportAction = GetComponent<ITeleportAction>();
        _camera = _playerCamera.transform;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        enabled = IsClient;
        if (!IsOwner)
        {
            _playerCamera.gameObject.SetActive(false);
            enabled = false;
            return;
        }
    }


    [ClientRpc]
    public override void SetPlayerPositionClientRpc(Vector3 position)
    {
        _controller.enabled = false;
        transform.position = position;
        _controller.enabled = true;
    }


    private void FixedUpdate()
    {
        Rotate();
        Movement();
      
    }

    private void Update()
    {
        Teleport();
    }

    protected void Teleport()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _teleportAction.OnTeleportHandlerServerRpc();
        }
    }

    protected override void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.SimpleMove(move * _speed * Time.deltaTime);
    }

    protected override void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);

        _camera.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        transform.Rotate(Vector3.up * mouseX);
    }
}





