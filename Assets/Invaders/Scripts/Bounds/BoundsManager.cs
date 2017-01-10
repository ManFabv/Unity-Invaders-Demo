using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BoundsManager : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject rightBound;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject leftBound;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject gameAreaBound;

    // Use this for initialization
    void Start ()
    {
        BoxCollider2D bc_temp_L;
        BoxCollider2D bc_temp_R;

        bc_temp_L = leftBound.GetComponent<BoxCollider2D>();
        bc_temp_R = rightBound.GetComponent<BoxCollider2D>();

        bc_temp_L.size = bc_temp_R.size = new Vector2(1, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y*2.0f);

        leftBound.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(-bc_temp_L.size.x, Screen.height/2.0f, 0));

        rightBound.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + bc_temp_R.size.x, Screen.height / 2.0f, 0));

        rightBound.transform.Translate(bc_temp_R.size.x/2.0f, 0, 0);
        leftBound.transform.Translate(-bc_temp_L.size.x/2.0f, 0, 0);

        BoxCollider2D bc_temp_gameArea = gameAreaBound.GetComponent<BoxCollider2D>();

        /*
         * es la distancia entre los colliders laterales, y el alto de cualquiera de los dos colliders
         */
        Vector2 vec_temp = new Vector2(rightBound.transform.position.x - leftBound.transform.position.x, bc_temp_L.size.y);

        vec_temp.x -= bc_temp_L.size.x; //en X ajusto quitandole la mitad del ancho de los dos colliders laterales y me queda y solo size

        bc_temp_gameArea.transform.position = Vector3.zero; //lo coloco en el origen
        bc_temp_gameArea.size = new Vector2(vec_temp.x, vec_temp.y); //asigno las nuevas dimensiones del collider
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
