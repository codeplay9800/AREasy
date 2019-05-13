using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
public class ChangeText : MonoBehaviour {
    [DllImport ("ARPlugin.dll")]
	static extern int add(int a, int b); 
    public GameObject checktext;

    // Use this for initialization
    void Start () {
		Text texty= checktext.GetComponent<Text>();
		//texty.text= .ToString(); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
