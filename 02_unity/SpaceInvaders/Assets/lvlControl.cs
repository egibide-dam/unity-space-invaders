using UnityEngine;
using System.Collections;

public class lvlControl : MonoBehaviour {
    public GeneradorAliens gar;

    // Use this for initialization
    void Start () {

        if (Application.loadedLevelName.Equals("bossRetro"))
        {

        }
        else if (Application.loadedLevelName.Equals("Nivel1"))
        {
            gar.activar();
        }
    
}
	
	// Update is called once per frame
	void Update () {
	
	}
}
