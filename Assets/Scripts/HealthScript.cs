using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float hp = 1;

    public float CountDamage = 0.1f;

    public void Damage(float damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Rocket"))
        {
            Damage(CountDamage);
            Destroy(otherCollider.gameObject);
        }
    }
}