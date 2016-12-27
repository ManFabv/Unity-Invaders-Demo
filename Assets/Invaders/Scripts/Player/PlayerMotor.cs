using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private PlayerController playerMotor;

    private Rigidbody rb;

    private void Awake()
    {
        //Esto se que siempre se cumplira porque requiero este componente
        //en la declaracion de la clase
        playerMotor = this.GetComponent<PlayerController>();
        rb = this.GetComponent<Rigidbody>();   
    }

    /// <summary>
    /// Metodo llamado a una cantidad fija de tiempo (manteniendo la cantidad de llamadas por segundo)
    /// </summary>
	void FixedUpdate ()
    {
        rb.AddForce(new Vector3(playerMotor.Velocity, 0, 0) * Time.deltaTime, ForceMode.Impulse);
	}
}
