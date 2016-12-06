using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public Text text;
    public float score = 0;
    public int CountManForBonus = 10;
    private int CountBonus = 0;
    private float maxHP;
    private float scoreBonus = 0;
    public GameObject panel;
    private float timer = 0.1f;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Man man = otherCollider.gameObject.GetComponent<Man>();
        if (man != null)
        {
            score += 100;
            scoreBonus += 100;
            Destroy(man.gameObject);
            if (scoreBonus % (CountManForBonus * 100) == 0)
            {
                CountBonus++;
                panel.SetActive(true);
                scoreBonus -= CountManForBonus * 100;
                text.text = "Score: " + score.ToString() + " | Bonuses: " + CountBonus.ToString();
            }
            if ((CountBonus > 0) && (GetComponent<HealthScript>().hp < 1))
            {
                GetComponent<HealthScript>().hp += GetComponent<HealthScript>().CountDamage;
                GetComponent<HealthScript>().lifes.fillAmount = GetComponent<HealthScript>().hp / maxHP;
                CountBonus--;
                text.text = "Score: " + score.ToString() + " | Bonuses: " + CountBonus.ToString();
            }
            else
            {
                text.text = "Score: " + score.ToString() + " | Bonuses: " + CountBonus.ToString();
            }
        }
    }

    void Start()
    {
        text.text = "Score: " + score.ToString() + " | Bonuses: " + CountBonus.ToString();
        maxHP = GetComponent<HealthScript>().hp;
    }

    void Update()
    {
        if ((CountBonus > 0) && (GetComponent<HealthScript>().hp < 1))
        {
            GetComponent<HealthScript>().hp += GetComponent<HealthScript>().CountDamage;
            GetComponent<HealthScript>().lifes.fillAmount = GetComponent<HealthScript>().hp / maxHP;
            CountBonus--;
            text.text = "Score: " + score.ToString() + " | Bonuses: " + CountBonus.ToString();
        }
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
