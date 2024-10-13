using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxLife = 5;
    public int life = 0;
    
    public float speed = 5f;
    public float speedIncrease = 0.5f;
    private Vector3 vectorVertical = Vector3.forward;
    private Vector3 vectorHorizontal = Vector3.left;
    private int anteriorR = 0, r = 0;
    public Rigidbody rb;

	public Animator animator;

	private PathGenerator pathGenerator;
    private GameControllerManager gcm;

    public AudioClip BuffSound;
    public AudioClip DebuffSound;
    public AudioClip DeadSound;

    public float deadTime = 3f;
    private bool canMove = true;
    
    void Start()
    {
        pathGenerator = FindObjectOfType<PathGenerator>();
        gcm = FindAnyObjectByType<GameControllerManager>();
        life = maxLife;
    }

    void Update()
    {
        if (canMove)
            Move();
    }

    #region movimientos
    private void Move()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        if(x> 0 || x<0  || z> 0 || z <0) animator.SetBool("isMove", true);
        else animator.SetBool("isMove", false);

        Vector3 direccionMovimiento = vectorVertical * z + vectorHorizontal * x;
        rb.velocity = direccionMovimiento * speed;

        if (direccionMovimiento != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direccionMovimiento);
        }
    }

    public void ChangeOrientation()
    {
        do
        {
            r = Random.Range(1, 8);
        }
        while (anteriorR != 0 && r == anteriorR);

        switch (r)
        {
            case 1:
                vectorVertical = Vector3.forward;
                vectorHorizontal = Vector3.right;
                break;
            case 2:
                vectorVertical = Vector3.right;
                vectorHorizontal = Vector3.back;
                break;
            case 3:
                vectorVertical = Vector3.back;
                vectorHorizontal = Vector3.left;
                break;
            case 4:
                vectorVertical = Vector3.left;
                vectorHorizontal = Vector3.forward;
                break;
            case 5:
                vectorVertical = Vector3.forward;
                vectorHorizontal = Vector3.left;
                break;
            case 6:
                vectorVertical = Vector3.left;
                vectorHorizontal = Vector3.back;
                break;
            case 7:
                vectorVertical = Vector3.back;
                vectorHorizontal = Vector3.right;
                break;
            case 8:
                vectorVertical = Vector3.right;
                vectorHorizontal = Vector3.forward;
                break;
        }

    }

    public void ResetOrientation()
    {
        vectorVertical = Vector3.forward;
        vectorHorizontal = Vector3.left;
    }
    #endregion

    public void TakeDamage(int amount)
    {
        life -= amount;

        if (life > maxLife) life = maxLife;
        if (life < 0) life = 0;

        gcm.ChangeLife(life, maxLife);

        if ( life == 0 )
        {
            canMove = false;

            AudioManager.instance.PlaySFX(DeadSound);
            animator.SetBool("isDead", true);
            FindObjectOfType<backWall>().canMove = false;
            FindObjectOfType<ObjectGenerator>().canSpawn = false;
            StartCoroutine(Morir());
        }
    }

    IEnumerator Morir()
    {
        yield return new WaitForSeconds(deadTime);

        FindObjectOfType<MenuManager>().GoGameOverScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.CompareTag("Floor"))
            {
                Floor fl = other.gameObject.GetComponent<Floor>();
                if (!fl.activated)
                {
                    fl.activated = true;
                    pathGenerator.Advance();
                }
            }
            else if (other.gameObject.CompareTag("BackWall"))
            {
                TakeDamage(999);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Object"))
            {
                Objects obj = collision.gameObject.GetComponent<Objects>();

                switch (obj.type)
                {
                    case ObjectType.cheese:
                        ChangeOrientation();
                        TakeDamage(1);
                        gcm.ChangeCordureImage(true);
                        AudioManager.instance.PlaySFX(DebuffSound);
                        break;
                    case ObjectType.chili:
                        ResetOrientation();
                        gcm.ChangeCordureImage(false);
                        speed += speedIncrease;
                        AudioManager.instance.PlaySFX(BuffSound);
                        break;
                    case ObjectType.poison:
                        TakeDamage(-1);
                        gcm.AddPoint();
                        AudioManager.instance.PlaySFX(BuffSound);
                        break;

                    default:
                        break;
                }

                Destroy(obj.gameObject);
            }
        }
    }
}
