using System.Runtime.CompilerServices;
using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Cài đặt người chơi")]
    [SerializeField] private float tocdodichuyen = 10f;
    [SerializeField] private float lucnhay = 7.0f; 
    [SerializeField] private int gioihanlannhay = 1;
    [Header("Cài đặt kiểm tra mặt đất")]
    [SerializeField] private Transform kiemtramatdat;
    [SerializeField] private float dorongvongkiemtra= 0.5f;
    [SerializeField] private LayerMask groundlayer;

    private Rigidbody2D khungxuong2D;
    private InputAction hanhdongdichuyen;
    private InputAction hanhdongnhay;
    private int lannhayconlai;
    private float nutdichuyen;
    private bool dungtrenmatdat;
    private bool nhay;

    private void Awake()
    {
        hanhdongdichuyen=InputSystem.actions.FindAction("Move");
        hanhdongnhay=InputSystem.actions.FindAction("Jump");
        khungxuong2D=GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        lannhayconlai=gioihanlannhay;
    }
    private void Update()
    {
        kiemtracodungtrenmatdatkhong();

        nutdichuyen=hanhdongdichuyen.ReadValue<float>();
        if (hanhdongnhay.WasPressedThisFrame()&&lannhayconlai>0)
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

    private void kiemtracodungtrenmatdatkhong()
    {
        bool dachamdat = dungtrenmatdat;
        Collider2D hit = Physics2D.OverlapCircle(kiemtramatdat.position, dorongvongkiemtra, groundlayer);
        dungtrenmatdat = hit != null;
        if (dungtrenmatdat)
        {
            lannhayconlai = gioihanlannhay;
        }
        else if (dachamdat && lannhayconlai == gioihanlannhay)
        {
            lannhayconlai = gioihanlannhay - 1;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(kiemtramatdat.position, dorongvongkiemtra);
    }
}