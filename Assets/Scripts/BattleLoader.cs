using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleLoader : MonoBehaviour
{
	public void LoadBattle()
	{
		SceneManager.LoadScene("Battle");
	}
}
