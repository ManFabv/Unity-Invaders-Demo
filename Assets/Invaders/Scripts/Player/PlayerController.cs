using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float moveVelocity = 5;

    /// <summary>
    /// 
    /// </summary>
    public float Velocity
    {
        get; private set;
    }

    private void Awake()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2.0f, 0, this.transform.position.z));

        BoxCollider2D bc_temp;

        bc_temp = this.GetComponent<BoxCollider2D>();

        this.transform.Translate(0, bc_temp.size.y + 1, 0);
    }

    void Update ()
    {
        Velocity = Input.GetAxis("Horizontal") * moveVelocity;
	}
}
