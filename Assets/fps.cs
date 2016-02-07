using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fps : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		text.text = "FPS: " + (1f / Time.deltaTime).ToString("F0");
	}
}
