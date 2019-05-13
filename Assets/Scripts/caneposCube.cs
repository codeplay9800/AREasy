using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caneposCube : MonoBehaviour {
	public GameObject webCamPlane;

	Vector3 pos; // from OpenCV
	public Camera cam;
	public float rotoffset;
	float rotx,roty,rotz;
	float pos_x,pos_y,pos_z;
	public Vector3 initialScale;
	
	float iniposx,finalposx,iniposy,finalposy,iniposz,finalposz;
	ImageSend sd;
	Vector2 cparams;
	// Use this for initialization
	void Start () {
		cparams= new Vector2(336.028f,217.193f);
		Vector2 fparams= new Vector2(576.24f,551.223f);
		float vfov =  2.0f * Mathf.Atan(0.5f * 480 / fparams.y) * Mathf.Rad2Deg;
		initialScale=this.transform.localScale;
		sd= webCamPlane.GetComponent<ImageSend>();
		cam.fieldOfView = vfov;
		cam.aspect = 640 / 480;
		
	}
	
	// Update is called once per frame
	void Update () {
		rotx=(float)sd._faces[0].RX;
		roty=(float)sd._faces[0].RY;
		rotz=(float)sd._faces[0].RZ;
		float theta = (float)(Mathf.Sqrt(rotx*rotx + roty*roty + rotz*rotz)*180/Mathf.PI);
		Vector3 axis = new Vector3 (-rotx, roty, -rotz);
		Quaternion rot = Quaternion.AngleAxis (theta, axis);
		gameObject.transform.rotation=rot;
/*

		pos = new Vector3((float)sd._faces[0].DX, -(float)sd._faces[0].DY, (float)sd._faces[0].DZ);
		
		//Debug.Log(roty);
		
		Debug.Log(pos.z);
		 
		 // from OpenCV (calibration parameters Cx and Cy = optical center shifts from image center in pixels)
		Vector3 imageCenter = new Vector3(0.5f, 0.5f, pos.z); // in viewport coordinates
		Vector3 opticalCenter = new Vector3(0.5f + cparams.x / 640, 0.5f + cparams.y / 480, pos.z); // in viewport coordinates
		pos += cam.ViewportToWorldPoint(imageCenter) - cam.ViewportToWorldPoint(opticalCenter); // position is set as if physical camera's optical axis went exactly through image center
		//gameObject.transform.position=pos*50;
		//Debug.Log(pos);
		*/
	}
}
