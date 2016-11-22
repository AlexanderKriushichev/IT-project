using UnityEngine;
using System.Collections;

public class DestroyUselessBots : MonoBehaviour
{
	public void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("fsdfsd");
		Destroy(other.gameObject);
	}
}
