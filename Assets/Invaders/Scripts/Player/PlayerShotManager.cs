using UnityEngine;
using System.Collections;

public class PlayerShotManager : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject shotModel;

    /// <summary>
    /// 
    /// </summary>
    private bool canShot = false;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float timeBetweenShots = 1.5f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private float shotAcceleration = 150;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Transform shotBarrelPoint;

	// Use this for initialization
	void Start ()
    {
        //obtengo el layer a traves del nombre
        LayerMask layerArmasJugador = LayerMask.NameToLayer(Literals.layerNamePlayerWeapon);

        //obtengo el layer a traves del nombre
        LayerMask layerPlayer = LayerMask.NameToLayer(Literals.layerNamePlayer);

        //Digo que ignore las colisiones entre las armas del jugador y el jugador
        Physics.IgnoreLayerCollision(layerArmasJugador, layerPlayer);

        //digo que ignore las colisiones entre todos los colliders del player
        Physics.IgnoreLayerCollision(layerPlayer, layerPlayer);

        StartCoroutine(InitialWait());
	}

    private IEnumerator InitialWait()
    {
        canShot = false;

        yield return new WaitForSeconds(Literals.timeToInitPlayerInput);

        canShot = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButton(Literals.fireButton) && canShot)
        {
            StartCoroutine(Shot());
        }
	}

    private IEnumerator Shot()
    {
        canShot = false;

        if (shotModel != null)
        {
            GameObject go = Instantiate(shotModel) as GameObject;

            Shot shot = go.GetComponent<Shot>();

            if (shot != null)
                shot.IniciarDisparo(shotAcceleration, shotBarrelPoint.position);
        }

        yield return new WaitForSeconds(timeBetweenShots);

        canShot = true;
    }
}
