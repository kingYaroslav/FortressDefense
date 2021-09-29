using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinishUIDisplay : MonoBehaviour
{
	[SerializeField] private SpriteRenderer StarDisplay;
	[SerializeField] private Sprite[] starSprites;
	[SerializeField] private GameObject GameOver;
	[SerializeField] private GameObject LevelCleared;



	public void ShowResult(int starCount)
	{
		var spriteRenderer  = Instantiate(StarDisplay);
		spriteRenderer.sprite = starSprites[starCount];
		if(starCount > 0)
		{
			Instantiate(LevelCleared);
		}
		else
		{
			Instantiate(GameOver);
		}
	}
}
