using UnityEngine;
using System.Collections;

public class DestroyUselessBots : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(other.gameObject);
	}
}
