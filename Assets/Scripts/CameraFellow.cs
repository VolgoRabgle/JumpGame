using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFellow : MonoBehaviour {

	public GameObject target;

	private Vector3 _deviationFix;

	private Vector3 _cameraHight;

	void Start() {
		_deviationFix = transform.position - target.transform.position;
		_cameraHight.y = transform.position.y;
	}

	void Update() {
		Vector3 cameraPosition = target.transform.position + _deviationFix;
		cameraPosition.y = _cameraHight.y;
		transform.position = cameraPosition;
	}

}