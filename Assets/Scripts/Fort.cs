using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fort : MonoBehaviour
{
	[SerializeField] private int health;
	[SerializeField] private int healthPerState;
	[SerializeField] private Sprite[] fortStates;
	private SpriteRenderer spriteRenderer;
	private void Start()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	public void GetHit(int damage)
	{
		health -= damage;
		int fortState = GetFortState();
		spriteRenderer.sprite = fortStates[Mathf.Min(fortState, fortStates.Length - 1)];
		if(fortState == 0)
		{
			GameManager.Instance.ShowDefeatUI();
		}
	}

	public int GetFortState()
	{
		return health / healthPerState;
	}

}
