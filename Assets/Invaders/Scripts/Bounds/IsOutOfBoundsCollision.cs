using UnityEngine;

public class IsOutOfBoundsCollision : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Literals.tagPlayerShot) || other.CompareTag(Literals.tagEnemyShot))
        {
            other.gameObject.SetActive(false);
        }
    }
}
