using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class escript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void jugar()
    {

        SceneManager.LoadScene("nivel00");

    }

    public void retro()
    {

        SceneManager.LoadScene("Nivel1");

    }
}
