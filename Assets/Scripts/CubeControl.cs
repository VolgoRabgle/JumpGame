using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {

	public float _buthHight = -3.0f;

	public float risingSpeed = 5.0f;
	public float sinkSpeed = 3.0f;

	private bool _removeConfirm = false;


	void Start() {
		Buth();
	}


	void OnTriggerExit(Collider other) {
		if(other.gameObject.CompareTag("Player")){
			_removeConfirm = true;
		}
	}
	
	void Update () {
		if(_removeConfirm == true){
			transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
			if(transform.position.y < _buthHight){
				Destroy(gameObject);
			}
		}


		if(_removeConfirm == true){
			transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
			if(transform.position.y < _buthHight){
				Destroy(gameObject);
			}
		}
		else{
			if(transform.position.y <= 1.0f){
				transform.Translate(Vector3.up * risingSpeed * Time.deltaTime);
			}
		}
		
	}

	void Buth() {
		Vector3 position = transform.position;
		position.y = _buthHight;
		transform.position =  position;
	}

}

