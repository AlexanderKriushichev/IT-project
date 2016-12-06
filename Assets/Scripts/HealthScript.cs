using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float hp = 1;
    public Image lifes;
    public float CountDamage = 0.1f;
    private float maxHP;
    public GameObject menu;
    public Canvas canvas;
    public GameObject panel;
    private float timer = 0.1f;

    public void Start()
    {
        maxHP = hp;
    }

    public void Damage(float damageCount)
    {
        hp -= damageCount;
        lifes.fillAmount = hp / maxHP;
        if (hp <= 0)
        {
            Instantiate(menu, new Vector3(canvas.transform.position.x, 0, 0), Quaternion.Euler(0, 0, 0), canvas.gameObject.transform);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Rocket"))
        {
            panel.SetActive(true);
            Damage(CountDamage);
            Destroy(otherCollider.gameObject);
        }
    }

    void Update()
    {
        if (panel.activeSelf)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                panel.SetActive(false);
                timer = 0.1f;
            }
        }
    }
}