using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class GUIControlScript : MonoBehaviour
{
    private Behaviour halo;
    private Blur blur;
    private ColorCorrectionCurves colorcorrection;
    private VignetteAndChromaticAberration vignette; 

    public GameObject skillsGUI;
    public float detectionRadius;

    private bool _GUIactive;
    public bool GUIactive { get
        {
            return _GUIactive;
        }
        set
        {
            _GUIactive = value;
            halo.enabled = value;
            skillsGUI.SetActive(value);
            blur.enabled = value;
            colorcorrection.enabled = value;
            vignette.enabled = value;
            //TODO: When GUIactive, do not detect
        }
    }

	// Use this for initialization
	void Start () {
        halo = (Behaviour)gameObject.GetComponent("Halo"); //will replace with other visual affects
        blur = Camera.main.GetComponent<Blur>();
        Debug.Log(blur.name);
        vignette = Camera.main.GetComponent<VignetteAndChromaticAberration>();
        colorcorrection = Camera.main.GetComponent<ColorCorrectionCurves>();
        halo.enabled = false;
        GUIactive = false;
        skillsGUI.SetActive(GUIactive);
    }

    void Update() {
        if (GUIactive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;
                Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
                if (Vector3.Distance(mousePosition, objectPosition) > detectionRadius)
                {
                    GUIactive = false; 
                } 
            }
        }
    }

    void OnMouseDown()
    {
        GUIactive = !GUIactive;
    }

   
    //void OnMouseUp()
    //{
    //    //mouseup
    //    halo.enabled = false;

    //    //disable the GUI
    //    skillsGUI.SetActive(false);
    //}

}
