using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Player : MonoBehaviour
{
    enum ENUM_ANIMATOR
    {
        move,
        flight,
        hitPhysic,
        hitFire,
        hitElectro,
    }

    [SerializeField] float speed;
    [SerializeField] float forceUp;

    Rigidbody2D rb;
    
    ParticleSystem particle;
    bool statePart = false;
    
    Animator anim;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        particle = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        Move();
        Jump();
    }
    void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    void Jump()
    {
        if (Input.GetMouseButton(0))
        {
            if (statePart == false)
            {
                particle.Play();
                statePart = true;
            }
            rb.AddForce(Vector2.up * forceUp);
        }
        else
        {
            if (statePart == true)
            {
                particle.Stop();
                statePart = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "floor") { 
            anim.SetInteger("state", (int)ENUM_ANIMATOR.move);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "floor") { 
            anim.SetInteger("state", (int)ENUM_ANIMATOR.flight);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            anim.SetInteger("state", (int)ENUM_ANIMATOR.hitFire);
            Debug.Log("end game");
        }
    }
}
