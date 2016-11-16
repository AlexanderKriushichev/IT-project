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
    Rocket shot = otherCollider.gameObject.GetComponent<Rocket>();
    if (shot != null)
    {
        Damage(CountDamage);
        Destroy(shot.gameObject);
    }
  }
}