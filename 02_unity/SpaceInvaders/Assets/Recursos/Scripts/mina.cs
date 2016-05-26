using UnityEngine;
using System.Collections;

public class mina : MonoBehaviour {

    [Tooltip("Particle systems that must be manually started and will not be played on start.")]
    public ParticleSystem[] ManualParticleSystems;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    private void StartParticleSystems()
    {
        foreach (ParticleSystem p in gameObject.GetComponentsInChildren<ParticleSystem>())
        {
            if (ManualParticleSystems == null || ManualParticleSystems.Length == 0 ||
                System.Array.IndexOf(ManualParticleSystems, p) < 0)
            {
                if (p.startDelay == 0.0f)
                {
                    // wait until next frame because the transform may change
                    p.startDelay = 0.01f;
                }
                GetComponent<AudioSource>().Play();
                p.Play();
            }
        }
    }


    void OnCollisionEnter2D(Collision coll)
    {
        // Detectar la colisión

        // Necesitamos ver si es un enemigo
        if (coll.gameObject.tag == "enemy")
        {

            // Animacion y Sonido de explosión 
            StartParticleSystems();
            

            // La mina desaparece (hay que añadir un retraso, si no, no se oye la explosión)

            // Lo ocultamos...
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;

            // ... y lo destruímos al cabo de 1.5 segundos, para dar tiempo al efecto de sonido y explosion
            Destroy(gameObject, 1.5f);
        }
    }


}
