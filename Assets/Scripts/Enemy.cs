using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{

	public Animator animator;
	[SerializeField] private Vector3 targetPos;
	[SerializeField] private int Health = 100;
	[SerializeField] private float timeToGetToTargetPos = 5;
	[SerializeField] private Splash hitSplash;
	[SerializeField] private int damage = 15;
	//[SerializeField] private 
	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
		transform.DOMove(targetPos, timeToGetToTargetPos).
			OnComplete(() => { animator.SetBool("CanAttack", true); });
	}

	public void GetHit(int damage)
	{
		Health -= damage;
		Instantiate(hitSplash, transform.position, Quaternion.identity);
		if (Health <= 0)
		{
			animator.SetTrigger("Death");
			GameManager.Instance.EnemyDied(this);
		}
	}

	public void SelfDestroy()// called from death animation
	{
		Destroy(gameObject);

	}


	public void Damage()// called from attack animation
	{
		GameManager.Instance.fort.GetHit(Random.Range(0,damage));
	}
}
