using UnityEngine;

public class BoundsDirectionController : MonoBehaviour {

    /// <summary>
    /// 
    /// </summary>
    private EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = GameObject.FindGameObjectWithTag(Literals.tagEnemyManager).GetComponent<EnemyManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(Literals.tagEnemy))
        {
            enemyManager.ChangeDirectionOfAllEnemies();
        }

        if (other.CompareTag(Literals.tagEnemyShot))
        {
            other.gameObject.SetActive(false);
        }
    }
}
