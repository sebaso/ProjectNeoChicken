using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    // Use this for initialization
    public Transform[] backgrounds;
    private float[] parralaxScales;
    public float parralaxSmooth = 1f;
    private Transform cam;
    private Vector3 previouscampos;

    void Awake()
    {
        cam = Camera.main.transform;
    }
 
	void Start () {
        previouscampos = cam.position;
        parralaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parralaxScales[i] = backgrounds[i].position.z * -1;
        }
	
	}

	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previouscampos.x - cam.position.x) * parralaxScales[i];
            float backgroundtargetposx= backgrounds[i].position.x + parallax;
            Vector3 backgroundtargetpos = new Vector3(backgroundtargetposx, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundtargetpos, parralaxSmooth*Time.deltaTime);

        }
        previouscampos = cam.position;

    }


}
