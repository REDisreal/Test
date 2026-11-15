using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveWASD : MonoBehaviour
{
    [Header("Cài đặt người chơi")]
    [SerializeField] private float tocdodichuyen = 10f;

    private Rigidbody2D khungxuong2D;
    private InputAction hanhdongdichuyen;
    private Vector2 nutdichuyen;

    private void Awake()
    {
        hanhdongdichuyen=InputSystem.actions.FindAction("Move(WASD)");
        khungxuong2D=GetComponent<Rigidbody2D>();
        khungxuong2D.gravityScale = 0f;
        khungxuong2D.freezeRotation = true;
    }
    private void Update()
    {
        nutdichuyen=Vector2.ClampMagnitude(hanhdongdichuyen.ReadValue<Vector2>(),1f);
    }
    private void FixedUpdate()
    {
        khungxuong2D.linearVelocity = nutdichuyen * tocdodichuyen;
    }
}