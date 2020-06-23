using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour {

	public int vidas = 2;

	public void Tocar ( ) {
		vidas--;

		if ( vidas == 1 ) {
			Pontaria.p.score += 5;
			GetComponent<SpriteRenderer> ( ).color = Color.gray;
		}
		else if ( vidas == 0 ) {
			Pontaria.p.score += 25;
			GetComponent<SpriteRenderer> ( ).color = Color.red;
			Destroy ( gameObject, 1f );
		}
		else {
			Pontaria.p.score -= 50;
		}

	}

}
