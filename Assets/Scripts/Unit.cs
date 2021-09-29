using UnityEngine;

public class Unit : MonoBehaviour
{
	[SerializeField] private float sqrRange;
	[SerializeField] private int damage;
	public Animator animator;
	private Enemy target;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}

	private void Update()
	{
		foreach(Enemy enemy in GameManager.Instance.enemies)
		{
			if(Vector3.SqrMagnitude(enemy.transform.position - transform.position) < sqrRange)
			{
				animator.SetBool("CanShoot", true);
				target = enemy;
				return;
			}
		}
		target = null;
		animator.SetBool("CanShoot", false);

	}

	public void Damage()//called from animation
	{
		if(target != null)
		{
			target.GetHit(Random.Range(0, damage));
		}
	}
}
