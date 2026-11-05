using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    [SerializeField] private float lucnhay = 10f;
    [SerializeField] private float tocdoquay = 5f;
    [SerializeField] private Pipe pipeSpawner;

    private InputAction bamnhay; 
    private Rigidbody2D khungxuong2D;
    private bool nhay = false;
    private float trongluc;
    private bool batdau = false;

    void Awake()
    {
        bamnhay=InputSystem.actions.FindAction("Attack");
        khungxuong2D=GetComponent<Rigidbody2D>();
        trongluc = khungxuong2D.gravityScale;
        khungxuong2D.gravityScale = 0f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bamnhay.WasPressedThisFrame())
        {
            if (!batdau)
            {
                batdau = true;
                khungxuong2D.gravityScale = trongluc;
                pipeSpawner.StartSpawning();   
            }  
            nhay=true;
        }
    }
    void FixedUpdate()
    {
        Vector2 vantochientai = khungxuong2D.linearVelocity;
        vantochientai.x = 0;
        if (nhay)
        {
            vantochientai.y=lucnhay;
            nhay=false;
        }
        khungxuong2D.linearVelocity = vantochientai;
        transform.rotation = Quaternion.Euler(0, 0, khungxuong2D.linearVelocity.y * tocdoquay);
    }
}
