using UnityEngine;

public class Destroy : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D otherCollider)
  {
    Man man = otherCollider.gameObject.GetComponent<Man>();
    if (man != null)
    {
        Destroy(man.gameObject);
      }
    }
  }
