using UnityEngine;
using System.Collections;

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

    /// <summary>
    /// 
    /// </summary>
    private bool canMove = false;

    private void Awake()
    {
        this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2.0f, 0, this.transform.position.z));

        BoxCollider2D bc_temp;

        bc_temp = this.GetComponent<BoxCollider2D>();

        this.transform.Translate(0, bc_temp.size.y + 1, 0);

        StartCoroutine(InitialWait());
    }

    private IEnumerator InitialWait()
    {
        canMove = false;

        yield return new WaitForSeconds(Literals.timeToInitPlayerInput);

        canMove = true;
    }

    void Update ()
    {
        if(canMove)
            Velocity = Input.GetAxis(Literals.horizontalAxis) * moveVelocity;
	}
}
