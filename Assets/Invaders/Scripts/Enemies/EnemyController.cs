using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ParticleSystem))]
public class EnemyController : MonoBehaviour {

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
        GameObject.Destroy(this.gameObject);
    }
}
