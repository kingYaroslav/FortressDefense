using UnityEngine;

public class Splash : MonoBehaviour
{
	public void SelfDestroy()//called from animation
	{
		Destroy(gameObject);
	}
}
