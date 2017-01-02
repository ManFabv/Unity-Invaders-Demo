using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Shot : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Sprite shotSprite;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private string shotTag = Literals.tagPlayerShot;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Rigidbody2D rb;

    private float Acceleration
    {
        get; set;
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();

        this.gameObject.SetActive(false);
    }

    // Use this for initialization
    void OnEnable ()
    {
        this.tag = shotTag;

        this.GetComponent<SpriteRenderer>().sprite = shotSprite;

        Acceleration = 0;
	}

    public void IniciarDisparo(float aceleracion, Vector3 position)
    {
        this.gameObject.SetActive(true);

        Acceleration = aceleracion;

        this.transform.position = position;

        rb.WakeUp();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.AddForce(new Vector2(0, Acceleration) * Time.deltaTime, ForceMode2D.Force);
    }
}
