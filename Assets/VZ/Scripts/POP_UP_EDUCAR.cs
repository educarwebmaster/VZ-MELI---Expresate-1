using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

public class POP_UP_EDUCAR : MonoBehaviour {

    string URL = "http://www.educar.com.co/publicidadvz/popup.png";
    public RawImage imagenWeb;
    public Color color;
    private WWW www;
    [Header("URL")]
    string url_link = "http://www.educar.com.co/publicidadvz/link.php";
    string url = "";
    private WWW Link;
    string[] s;

	// Use this for initialization
	IEnumerator Start () {
        www = new WWW(URL);
        yield return www;
        imagenWeb.texture = www.texture;
        imagenWeb.color = color;
        StartCoroutine("LinkWeb");
    }

    public IEnumerator LinkWeb()
    {
        Link = new WWW(url_link);
        yield return Link;
        s = Link.text.Split(new string[] { "+" }, StringSplitOptions.None);
        url = s[0];
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void URL_()
    {
        Application.OpenURL(url);
    }

}
