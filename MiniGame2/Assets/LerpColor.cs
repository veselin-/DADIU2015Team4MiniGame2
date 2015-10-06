using UnityEngine;
using System.Collections;

public class LerpColor : MonoBehaviour {

    public Color FromColor = Color.white;
    public Color ToColor = Color.red;
    private Renderer rend;
    private bool fromWhiteToRed = true;
    public float ColorSpeed = 5f;

     private float t = 0; // lerp control variable


    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");
    }

    void Update()
    {

        if (t < 1)
        { // while t below the end limit...
          // increment it at the desired rate every update:
            t += Time.deltaTime / ColorSpeed;
        }
        else
        {
            t = 0;
        }

        if (fromWhiteToRed)
        {
            if (rend.material.color != Color.red)
            {
                rend.material.SetColor("_Color", Color.Lerp(FromColor, ToColor, t));
            }
            else
            {
                fromWhiteToRed = false;
            }
        }
       else
        {
            if (rend.material.color != Color.white)
            {
                rend.material.SetColor("_Color", Color.Lerp(ToColor, FromColor, t));
            }
            else
            {
                fromWhiteToRed = true;
            }
        }


      
    }

 
	

}
