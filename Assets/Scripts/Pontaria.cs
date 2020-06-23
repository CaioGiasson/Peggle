using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pontaria : MonoBehaviour {

	public static Pontaria p;
	private void Awake ( ) { p = this; }

	public GameObject ball;
	public GameObject pontoLancamento;
	public float forcaDisparo;
	public Text scoreText;

	public Text GameOverText;
	public GameObject RestartButton;

	public int score = 100;

	public GameObject activeBall;

	private void Start ( ) {
		GameOverText.enabled = false;
		RestartButton.SetActive ( false );
	}

	void FixedUpdate ( ) {
		Vector3 pos = new Vector3 ( Input.mousePosition.x, Input.mousePosition.y, 0 );
		Vector3 posConvert = Camera.main.ScreenToWorldPoint ( pos );
		Vector3 direcao = posConvert;
		Vector3 diferencaAngular = Vet.Subtrai ( direcao, transform.position );
		float anguloNovo = Mathf.Atan2 ( diferencaAngular.y, diferencaAngular.x ) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler ( new Vector3 ( 0, 0, anguloNovo ) );

		if ( activeBall == null && Input.GetMouseButtonUp ( 0 ) && score >= 50 ) {
			score -= 50;

			GameObject b = Instantiate ( ball );
			b.transform.position = pontoLancamento.transform.position;
			b.GetComponent<Rigidbody2D> ( ).AddForce ( direcao * forcaDisparo );
			activeBall = b;
		}

		scoreText.text = "Pontos: " + score;

		if ( score < 50 && activeBall == null ) {
			GameOver ( );
		}
	}

	public void GameOver ( ) {
		GameOverText.enabled = true;
		RestartButton.SetActive ( true );
		Time.timeScale = 0;
	}

	public void Restart ( ) {
		Time.timeScale = 1;
		SceneManager.LoadScene ( SceneManager.GetActiveScene ( ).buildIndex );
	}
}
