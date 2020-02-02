using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
	public Sprite[] story;
	private Image frame;
	private int frameCounter = 0;

	IEnumerator playerStory()
	{
		if (frameCounter < story.Length)
		{
			frame.sprite = story[frameCounter];
			yield return new WaitForSeconds(5);
			frameCounter++;
			StartCoroutine(playerStory());
		}
		else
		{
			SceneManager.LoadScene("Menu");
		}

	}
	// Start is called before the first frame update
	void Start()
	{
		frame = GetComponent<Image>();
		StartCoroutine(playerStory());
	}

}
