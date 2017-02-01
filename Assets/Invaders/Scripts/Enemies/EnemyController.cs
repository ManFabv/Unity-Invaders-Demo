using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyController : MonoBehaviour {

    private enum DIRECTION
    {
        LEFT,
        RIGHT,
        NONE
    }

    private DIRECTION direction;

    /// <summary>
    /// 
    /// </summary>
    private Rigidbody2D rb;

    /// <summary>
    /// 
    /// </summary>
    private Animator anim;

    /// <summary>
    /// 
    /// </summary>
    private ParticleSystem particles;

    private void Awake()
    {
        anim = this.GetComponent<Animator>();

        particles = this.GetComponent<ParticleSystem>();

        rb = this.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Literals.tagPlayerShot))
        {
            particles.Play();
            anim.SetBool(Literals.animatorNameToStartEnemyDeath, true);
            other.gameObject.SetActive(false);
        }
    }

    void Death()
    {
        this.gameObject.SetActive(false);
    }

    public void Init()
    {
        rb.velocity = new Vector2(0.5f, 0);
        direction = DIRECTION.LEFT;
    }

    public void ChangeDirection()
    {
        if (direction == DIRECTION.LEFT)
        {
            direction = DIRECTION.RIGHT;
            rb.velocity = new Vector2(-0.5f, 0);
        }

        else if (direction == DIRECTION.RIGHT)
        {
            direction = DIRECTION.LEFT;
            rb.velocity = new Vector2(0.5f, 0);
        }
    }
}
