using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxLife = 3;
    public int life = 0;

    public float speed = 5f;
    public float speedIncrease = 0.5f;
    private Vector3 vectorVertical = Vector3.forward;
    private Vector3 vectorHorizontal = Vector3.left;
    private int anteriorR = 0, r = 0;
    public Rigidbody rb;

    private PathGenerator pathGenerator;
    
    void Start()
    {
        pathGenerator = FindObjectOfType<PathGenerator>();
        life = maxLife;
    }

    void Update()
    {
        Move();
    }

    #region movimientos
    private void Move()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        rb.velocity = vectorVertical * speed * z
            + vectorHorizontal * speed * x;
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

        if ( life <= 0 )
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.CompareTag("Object"))
            {
                Debug.Log("objetos");
                Objects obj = other.gameObject.GetComponent<Objects>();

                switch (obj.type)
                {
                    case ObjectType.cheese:
                        ChangeOrientation();
                        break;
                    case ObjectType.chili:
                        ResetOrientation();
                        TakeDamage(1);
                        break;
                    case ObjectType.poison:
                        TakeDamage(-1);
                        speed += speedIncrease;
                        break;

                    default:
                        break;
                }

                Destroy(obj.gameObject);
            }
            else if (other.gameObject.CompareTag("Floor"))
            {
                Floor fl = other.gameObject.GetComponent<Floor>();
                if (!fl.activated)
                {
                    fl.activated = true;
                    pathGenerator.Advance();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Object"))
            {
                Debug.Log("objetos");
                Objects obj = collision.gameObject.GetComponent<Objects>();

                switch (obj.type)
                {
                    case ObjectType.cheese:
                        ChangeOrientation();
                        break;
                    case ObjectType.chili:
                        ResetOrientation();
                        TakeDamage(1);
                        break;
                    case ObjectType.poison:
                        TakeDamage(-1);
                        speed += speedIncrease;
                        break;

                    default:
                        break;
                }

                Destroy(obj.gameObject);
            }
        }
    }
}
