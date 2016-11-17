using UnityEngine;
using System.Collections;

public class ScalingPlatform3D : MonoBehaviour {

    Vector3 startScale;
    Vector3 endScale = new Vector3(1, 1,1);
    float t;
    bool grandir;
    public float scale;
    // Use this for initialization
    void Start()
    {
        t = 0;
        startScale = new Vector3(scale, 1,1);
        grandir = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (grandir)
        {
            print(startScale + endScale);
            t += Time.deltaTime * 0.3f;
            transform.localScale = Vector3.Lerp(endScale, startScale, t);
            transform.Translate(new Vector3(-Time.deltaTime/3, 0, 0));
            if (t > 1)
            {
                grandir = false;

            }

        }
        else
        {
            t -= Time.deltaTime * 0.3f;
            transform.localScale = Vector3.Lerp(endScale, startScale, t);
            transform.Translate(new Vector3(Time.deltaTime/3, 0, 0));
            if (t < 0)
                grandir = true;
        }


    }
}
