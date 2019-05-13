using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransforms : MonoBehaviour {
	ImageSend sd;
	public GameObject referenceObject;
	public GameObject webcamPlane;
	float posx,posy,posz;
	float rotx,roty,rotz,rotxi,rotyi,rotzi;
	Vector3 rotationMaskx= new Vector3(1,0,0);
	// Use this for initialization
	void Start () {
		sd= webcamPlane.GetComponent<ImageSend>();		
	}
	
	// Update is called once per frame
	void Update () {
		posx=(float)sd._faces[0].DX;
		posy=(float)sd._faces[0].DY;
		posz=(float)sd._faces[0].DZ;
		gameObject.transform.position= new Vector3(-posx*80,posy*100,(-posz)*60);

	}
}
