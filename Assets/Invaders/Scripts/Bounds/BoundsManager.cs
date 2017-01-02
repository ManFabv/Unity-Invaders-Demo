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
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
