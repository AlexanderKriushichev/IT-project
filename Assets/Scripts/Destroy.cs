using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public Text text;
    public float score = 0;
    public int CountManForBonus = 5;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Man man = otherCollider.gameObject.GetComponent<Man>();
        if (man != null)
        {
            score += 100;
            Destroy(man.gameObject);
            if (score % (CountManForBonus * 100) == 0)
            {
                GetComponent<HealthScript>().hp = 1;
                GetComponent<HealthScript>().lifes.fillAmount = 1;
                score -= CountManForBonus * 100;
                text.text = "Score: " + score.ToString();
            }
            else
            {
                text.text = "Score: " + score.ToString();
            }
        }
    }
}
