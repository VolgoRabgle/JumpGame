using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	//PlayerControlValue
	private	Rigidbody _rb;
	private Vector3 _originalPosition;


	public float jumpForce = 350;
	public float moveForce = 180;
	private bool _onGround = true;
	
	//IncubatorValue
	public Transform CubeForSpawn;
	//public float spawnDistanceFix = 4;
	private bool _spawnReadyConfirm = false;
	private bool _cubeOnForward = false;
	private bool _cubeOnLeft = false;
	private bool _inComing = false;
	private Vector3 _cubePositionY = new Vector3(0.0f, 1.0f, 0.0f);


	private float _deadHight = 1.0f;

	void Start() {
		_rb = GetComponent<Rigidbody>();
		_originalPosition = transform.position;
		_cubeOnForward = true;
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("ButhArea")) {
			CheckToReset();
		}
		if(other.gameObject.CompareTag("Cube")) {
			_inComing = true;
		}
	}

	void OnCollisionEnter() {
		if(transform.position.y > 2.22){
			_onGround = true;
			//print("touched");

			if(_inComing == true){
				ReadyToSpawn();
				_inComing = false;
			}
		}
	}

	void Update() {
		if(_spawnReadyConfirm == true){
			SpawnCube();
		}
	}


	void FixedUpdate() {
		if(Input.GetButton("Jump")){
			Jump();
		}

	}


	void Jump() {
		if(_onGround == true){
			_rb.AddForce(Vector3.up * jumpForce);
			
			if(_cubeOnForward == true){
				_rb.AddForce(Vector3.forward * moveForce);
			}
			if(_cubeOnLeft == true){
				_rb.AddForce(Vector3.left * moveForce);
			}

			_onGround = false;
			//print("lefted");
		}
	}

	void SpawnCube() {
		Vector3 spawnPosition = getNewSpawnPosition();
		//print(spawnPosition);
		Instantiate(CubeForSpawn, spawnPosition, Quaternion.identity);

		_spawnReadyConfirm = false;
	}

	Vector3 getNewSpawnPosition() {
		float i = Random.Range(3.0f, 7.0f);
		//float i = (Random.value * 10) % 5 + spawnDistanceFix;
		//print(transform.position);
		//print(i);

		//spawn on z
		if(i%2 >= 1.0){
			_cubeOnForward = true;
			_cubeOnLeft = false;
			Vector3 newSpawnPositionZ = new Vector3(0.0f, 0.0f, i) + transform.position;
			newSpawnPositionZ.y = _cubePositionY.y;
			//print(newSpawnPositionZ);
			return newSpawnPositionZ;
		}
		//spawn on x
		else{
			_cubeOnLeft = true;
			_cubeOnForward = false;
			Vector3 newSpawnPositionX = new Vector3(-i, 0.0f, 0.0f) + transform.position;
			newSpawnPositionX.y = _cubePositionY.y;
			//print(newSpawnPositionX);
			return newSpawnPositionX;
		}
	}
	
	void ReadyToSpawn(){
		_spawnReadyConfirm = true;
	}

	void CheckToReset(){
		if(transform.position.y < _deadHight){
			transform.position = _originalPosition;
			_cubeOnForward = true;
			_cubeOnLeft = false;
		}
	}

}