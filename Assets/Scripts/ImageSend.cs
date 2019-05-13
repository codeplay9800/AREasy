using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;

internal static class OpenCVInterop
{
    [DllImport("ARPlugin")]
    internal unsafe static extern int startWebcamMonitoring(Color32[] raw, int width, int height, myValues* outFaces);
}
[StructLayout(LayoutKind.Sequential, Size = 48)]
public struct myValues
{
    public double DX, DY, DZ, RX, RY, RZ ;
}

public class ImageSend : MonoBehaviour {
	WebCamTexture webcam;
	public string[] rotval; 
	public int xrot,yrot,zrot;
	
	public int xpos,ypos,zpos;
	public int ox=0,oy=0,oz=0;
    
	public myValues[] _faces;
    void Start()
    {	rotval= new string[6];

		WebCamDevice[] devices = WebCamTexture.devices;
		_faces = new myValues[1];
		webcam = new WebCamTexture(WebCamTexture.devices [0].name, 640, 480, 60);
        if (devices.Length > 0)
        {
            webcam.deviceName = devices[0].name;
            GetComponent<Renderer>().material.mainTexture=webcam;
			webcam.Play();
        }

		
    }
	
	// Update is called once per frame
	void Update () {
		 if (webcam.isPlaying) {
			Color32[] rawImg = webcam.GetPixels32 ();
			//rntStr = new StringBuilder(100);
			//System.Array.Reverse (rawImg);
			  unsafe
        {	 fixed(myValues* outFaces = _faces)
            {
                OpenCVInterop.startWebcamMonitoring(rawImg, webcam.width, webcam.height, outFaces);
			}
        }
			//Debug.Log(_faces[0].DX+","+_faces[0].DY+","+_faces[0].DZ);
			//Debug.Log(_faces[0].DX);
			/* rotval= rntStr.ToString().Split(',');
			//Debug.Log(rntStr.ToString());
			if(rotval[0]=="")
			{return;}
			else
			Debug.Log(rntStr);
			*/
			/* 
			 if(ox==0 && oy==0 && oz==0){
				if(int.TryParse(rotval[3],out ox) && int.TryParse(rotval[4],out oy) && int.TryParse(rotval[5],out oz)){}
			}
			
			if(int.TryParse(rotval[0],out xrot) && int.TryParse(rotval[1],out yrot) && int.TryParse(rotval[2],out zrot)
			&& int.TryParse(rotval[3],out xpos) && int.TryParse(rotval[4],out ypos) && int.TryParse(rotval[5],out zpos))
			{	
				xpos-=ox;
				ypos-=oy;
				zpos-=oz;
				
				//Debug.Log(xrot+","+yrot+","+zrot);

			}*/		
	}
	}

}
