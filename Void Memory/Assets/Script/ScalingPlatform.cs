using UnityEngine;
using System.Collections;

public class ScalingPlatform : MonoBehaviour {
    Vector2 startScale;
    Vector2 endScale = new Vector2(1, 1f);
    float t;
    bool grandir;
    public float scale;
    public bool right;
    // Use this for initialization
    void Start () {
        t = 0;
        startScale = new Vector2(scale, 1f);
        grandir = true;

    }
	
	// Update is called once per frame
	void Update () {

        if (grandir)
        {
            t += Time.deltaTime * 0.3f ;
            transform.localScale = Vector2.Lerp(endScale, startScale, t);

           // if(right)
          //      transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
          //  else
          //      transform.Translate(new Vector3(Time.deltaTime, 0, 0));
            if (t > 1)
            {
                grandir = false;
            
            }
                
        }else
        {
            t -= Time.deltaTime * 0.3f;
            transform.localScale = Vector2.Lerp( endScale,startScale, t);

         //   if(right)
          //      transform.Translate(new Vector3(Time.deltaTime, 0, 0));
          //  else
          //      transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
            if (t < 0)
                grandir = true;
        }
          
        
	}
}


