﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ResultUI : MonoBehaviour {
	public Text userName;
	public Text howToReturnLobby;
	private Player winner;

	public void Set(Player player)
	{
		this.winner = player;
		gameObject.SetActive(true);
		userName.text = "\"" + player.key + "\"";
		howToReturnLobby.text = "로비로 돌아가려면\n\"" + player.key + "\" 누르기";
		StartCoroutine(EndCheck());
	}

	IEnumerator EndCheck()
	{
		Tween ();

		yield return new WaitForSeconds(1.0f);

		while (true)
		{
			if (Input.GetKeyUp(winner.key))
			{
				break;
			}
			yield return null;
		}

		SceneManager.LoadScene("Intro");
	}

	private void Tween()
	{
		transform.localScale = 0.1f * Vector3.one;
		transform.DOScale (Vector3.one, 1.0f).SetEase(Ease.OutBack);
	}
}
