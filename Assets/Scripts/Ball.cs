using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private void OnCollisionEnter2D ( Collision2D collision ) {

		if ( collision.gameObject.CompareTag ( "peg" ) ) {
			collision.gameObject.GetComponent<Peg> ( ).Tocar ( );
		}
		else if ( collision.gameObject.CompareTag ( "catcher" ) ) {
			Pontaria.p.activeBall = null;
			Pontaria.p.score += 50;
			Destroy ( gameObject );
		}
		else if ( collision.gameObject.CompareTag ( "fora" ) ) {
			Pontaria.p.activeBall = null;
			Destroy ( gameObject );
		}

	}

}
