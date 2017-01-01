using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
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
	
	void Update ()
    {
        Velocity = Input.GetAxis("Horizontal") * moveVelocity;
	}
}
