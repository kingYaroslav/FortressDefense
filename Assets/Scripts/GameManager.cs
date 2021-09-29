using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager _inst;

	[SerializeField] private GameFinishUIDisplay gameFinishUIDisplay;

	public List<Enemy> enemies = new List<Enemy>();
	public Fort fort;
	public static GameManager Instance => _inst;

	private void Awake()
	{
		_inst = this;
	}

	private void Start()
	{
		enemies.AddRange(FindObjectsOfType<Enemy>());
		fort = FindObjectOfType<Fort>();
	}

	public void EnemyDied(Enemy enemy)
	{
		enemies.Remove(enemy);
		if (enemies.Count == 0)
		{
			ShowVictoryUI();
		}
	}

	private void ShowVictoryUI()
	{
		EndBattle(true);
		gameFinishUIDisplay.ShowResult(fort.GetFortState());
	}

	public void ShowDefeatUI()
	{
		EndBattle();
		gameFinishUIDisplay.ShowResult(0);

	}
	private void EndBattle(bool KillEnemies = false)
	{
		foreach (var anim in FindObjectsOfType<Animator>())
		{
			anim.enabled = false;
		}
		foreach (var arch in FindObjectsOfType<Unit>())
		{
			arch.enabled = false;
		}
		foreach (var enemy in FindObjectsOfType<Enemy>())
		{
			if (KillEnemies)
				Destroy(enemy.gameObject);
			else
				enemy.enabled = false;
		}
	}
}
