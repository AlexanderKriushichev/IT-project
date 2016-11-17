using UnityEngine;
using UnityEngine.UI;

public class Destroy : MonoBehaviour
{
    public Text text;
    public float score = 0;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Man man = otherCollider.gameObject.GetComponent<Man>();
        if (man != null)
        {
            score += 100;
            text.text ="Score: "+ score.ToString();
            Destroy(man.gameObject);
        }
    }
}
