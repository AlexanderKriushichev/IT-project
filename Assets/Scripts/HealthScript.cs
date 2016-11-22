using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float hp = 1;
	public Image lifes;
    public float CountDamage = 0.1f;
	private float maxHP;
	public void Start()
	{
		maxHP = hp;
	}

    public void Damage(float damageCount)
    {
        hp -= damageCount;
	    lifes.fillAmount = hp/maxHP;
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