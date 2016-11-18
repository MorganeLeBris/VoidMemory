using UnityEngine;
using System.Collections;

public class ScalingPlatform : MonoBehaviour {
    Vector2 startScale;
    Vector2 endScale = new Vector2(1, 1f);
    float t;
    bool grandir;
    public float scale;
    public bool right;
    public Vector2 init;
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
            t += 0.05f ;
            transform.localScale = Vector2.Lerp(endScale, startScale, t);

         //   if(right)
          //      transform.Translate(new Vector3(-t/10f, 0, 0));
         //   else
          //      transform.Translate(new Vector3(t/10f, 0, 0));
            if (t >= 1)
            {
                grandir = false;
                t = 1;
            }
                
        }else
        {
            t -=  0.05f;
            transform.localScale = Vector2.Lerp(endScale,startScale, t);

        //    if(right)
        //        transform.Translate(new Vector3(t/10f, 0, 0));
         //   else
         //       transform.Translate(new Vector3(-t/10f, 0, 0));
            if (t < 0)
            {
                grandir = true;
                transform.localPosition = new Vector3(init.x, init.y, 0);
                t = 0;
             }
         }
                
          
        
	}
}


