using UnityEngine;
using System.Collections;

public class ScalingPlatform : MonoBehaviour {
    Vector2 startScale;
    Vector2 endScale = Vector2.one;
    float t;
    bool grandir;
    public float scale;
    // Use this for initialization
    void Start () {
        t = 0;
        startScale = new Vector2(scale, 1);
        grandir = true;

    }
	
	// Update is called once per frame
	void Update () {

        if (grandir)
        {
            t += Time.deltaTime * 0.3f ;
            transform.localScale = Vector2.Lerp(endScale, startScale, t);
            transform.Translate(new Vector3(-Time.deltaTime, 0, 0));
            if (t > 1)
            {
                grandir = false;
            
            }
                
        }else
        {
            t -= Time.deltaTime * 0.3f;
            transform.localScale = Vector2.Lerp( endScale,startScale, t);
            transform.Translate(new Vector3(Time.deltaTime, 0, 0));
            if (t < 0)
                grandir = true;
        }
          
        
	}
}


