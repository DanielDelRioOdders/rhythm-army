using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Odders;
using RythmMonsters;

public class GameManager : MonoBehaviour
{
	public int humanHealth = 3;
	public int iaHealth = 3;
	public float delay = 5f;
	public AudioSource endAudio;
	public AudioSource music;

	public GameObject controllers;
	public GameObject winLabel;
	public GameObject loseLabel;
	public GameObject logo;

	private void Start() => Invoke(nameof(StartGame), delay);

	private void StartGame()
	{
		logo.SetActive(false);
		controllers.SetActive(true);
	}
	private void StopGame()
	{
		controllers.SetActive(false);
		endAudio.Play();
		music.Stop();
	}

	public void TakeDamageHuman()
	{
		humanHealth -= 1;

		if (humanHealth <= 0)
		{
			loseLabel.SetActive(true);
			StopGame();
		}
	}
	public void TakeDamageIA()
	{
		humanHealth -= 1;

		if (humanHealth <= 0)
		{
			winLabel.SetActive(true);
			StopGame();
		}
	}

	public void Restart()
	{
		if (controllers.activeSelf == false)
			SceneManager.LoadScene(0);
	}
}