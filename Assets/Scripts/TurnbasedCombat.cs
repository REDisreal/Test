using UnityEngine;
using UnityEngine.InputSystem;
[System.Serializable]

public class nhanvat
{
    public string Name;
    public float HP;
    public float ATK;    

    public nhanvat(string charName, float Health, float Attack) 
    {
        Name = charName;
        HP = Health;
        ATK = Attack;
    }

    public virtual void Attack()
    {
        Debug.Log(Name + " Tancong!");
    }
    public void Takedamage(float damage)
    {
        HP-=damage;
        if (HP >= 50)
        {
            Debug.Log(Name + " còn " + HP + " máu");
            Debug.Log("Fine");
        }
        else if (HP < 50 && HP > 0)
        {
            Debug.Log(Name + " còn " + HP + " máu");
            Debug.Log("Low HP");
        }
        else
        {
            HP = 0;
            Debug.Log(Name + " còn " + HP + " máu");
            Debug.Log("Death");
        }
    }
}
class nguoichoi : nhanvat {
    public nguoichoi(string name, float hp, float atk)
        : base(name, hp, atk)
    {
        
    }
    public override void Attack() {
        Debug.Log("Sword Attack");
    }
}

public class TurnbasedCombat : MonoBehaviour
{
    public nhanvat nguoi = new nguoichoi("Player", 100, 40);
    public nhanvat kethu = new nhanvat("Enemy", 100, 20);
    private InputAction tancong; 
    private bool luot=true;
    private void Start()
    {
        tancong = InputSystem.actions.FindAction("Attack");
    }
    private void Update()
    {
        if (tancong.WasPressedThisFrame()&&nguoi.HP>0&&kethu.HP>0){
            if (luot){
                nguoi.Attack();
                kethu.Takedamage(nguoi.ATK);
                luot=false;
            }
            else
            {
                kethu.Attack();
                nguoi.Takedamage(kethu.ATK);
                luot=true;
            }
        }
    }
}