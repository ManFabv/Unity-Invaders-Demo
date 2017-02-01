using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class IsOutOfBoundsCollision : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private float anchoGameArea;

    /// <summary>
    /// 
    /// </summary>
    private float altoGameArea;

    /// <summary>
    /// 
    /// </summary>
    private BoxCollider2D bc;

    /// <summary>
    /// 
    /// </summary>
    public float AnchoAreaDeJuego
    {
        private set
        {
            anchoGameArea = value;
        }

        get
        {
            if (bc == null)
            {
                bc = this.GetComponent<BoxCollider2D>();
                anchoGameArea = bc.size.x;
            }

            return anchoGameArea;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public float AltoAreaDeJuego
    {
        private set
        {
            altoGameArea = value;
        }

        get
        {
            if (bc == null)
            {
                bc = this.GetComponent<BoxCollider2D>();
                altoGameArea = bc.size.y;
            }

            return altoGameArea;
        }
    }

    void Awake()
    {
        BoxCollider2D bc = this.GetComponent<BoxCollider2D>();

        AnchoAreaDeJuego = bc.size.x;
        AltoAreaDeJuego = bc.size.y;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Literals.tagPlayerShot) || other.CompareTag(Literals.tagEnemyShot))
        {
            other.gameObject.SetActive(false);
        }
    }
}
