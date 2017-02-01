using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int cantColumnasEnemigos = 6;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private int cantFilasEnemigos = 6;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private List<GameObject> tiposDeEnemigos = new List<GameObject>();

    /// <summary>
    /// 
    /// </summary>
    private List<GameObject> listaEnemigos = new List<GameObject>();

    /// <summary>
    /// 
    /// </summary>
    private bool changingDirection = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(InicializarPosiciones());
	}

    private IEnumerator InicializarPosiciones()
    {
        yield return new WaitForEndOfFrame();

        if(tiposDeEnemigos.Count > 0)
        {
            float anchoEnemigo = tiposDeEnemigos[0].GetComponent<SpriteRenderer>().bounds.size.x;
            float altoEnemigo = tiposDeEnemigos[0].GetComponent<SpriteRenderer>().bounds.size.y;

            float sizeEnemigo = Mathf.Max(anchoEnemigo, altoEnemigo);

            IsOutOfBoundsCollision gameArea = GameObject.FindGameObjectWithTag(Literals.tagGameArea).GetComponent<IsOutOfBoundsCollision>();

            float separacionEntreEnemigos = ( gameArea.AnchoAreaDeJuego / (cantColumnasEnemigos * sizeEnemigo * 2.0f) ) - (gameArea.AnchoAreaDeJuego*0.05f);

            for (int i = 0; i < cantFilasEnemigos; i++)
            {
                for (int j = 0; j < cantColumnasEnemigos; j++)
                {
                    int enemigo = Random.Range(0, tiposDeEnemigos.Count);

                    GameObject go = Instantiate(tiposDeEnemigos[enemigo]) as GameObject;

                    go.transform.position = new Vector3(separacionEntreEnemigos-(gameArea.AnchoAreaDeJuego/2.0f), separacionEntreEnemigos - (gameArea.AltoAreaDeJuego/2.0f), 0) + new Vector3(j*separacionEntreEnemigos, i*separacionEntreEnemigos, 0);

                    go.GetComponent<EnemyController>().Init();

                    listaEnemigos.Add(go);
                }
            }
        }
        
        yield return null;
    }

    public void ChangeDirectionOfAllEnemies()
    {
        if (changingDirection == false)
        {
            StartCoroutine(Wait());
            
            for (int i = 0; i < listaEnemigos.Count; i++)
            {
                if (listaEnemigos[i].activeInHierarchy == true)
                    listaEnemigos[i].GetComponent<EnemyController>().ChangeDirection();
            }
        }
    }

    private IEnumerator Wait()
    {
        changingDirection = true;
        yield return new WaitForEndOfFrame();
        changingDirection = false;
    }
}
