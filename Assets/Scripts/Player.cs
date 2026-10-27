using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float tocdodichuyen = 10f;
    [SerializeField] private float lucnhay = 7.0f; 
    private Rigidbody2D khungxuong2D;
    private InputAction hanhdongdichuyen;
    private InputAction hanhdongnhay;
    private float nutdichuyen;
    private bool nhay;

    private void Awake()
    {
        hanhdongdichuyen=InputSystem.actions.FindAction("Move");
        hanhdongnhay=InputSystem.actions.FindAction("Jump");
        khungxuong2D=GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        nutdichuyen=hanhdongdichuyen.ReadValue<float>();
        if (hanhdongnhay.WasPressedThisFrame())
        {
            nhay=true;
        }
    }
    private void FixedUpdate()
    {
        Vector2 vantochientai = khungxuong2D.linearVelocity;
        vantochientai.x = nutdichuyen * tocdodichuyen;
        if (nhay)
        {
            vantochientai.y=lucnhay;
            nhay=false;
        }
        khungxuong2D.linearVelocity = vantochientai;
    }
}
