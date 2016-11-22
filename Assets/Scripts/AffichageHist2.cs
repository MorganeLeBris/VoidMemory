using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AffichageHist2 : MonoBehaviour
{

    public Text Text;
    private int i = 0;
    private int j = 2;
    private string strComplete;
    public AudioSource voix;
    void Start()
    {
        voix.Play();
        strComplete = "Alors que Buzz admirait paisiblement le ciel, une météorite passa droit devant ses yeux. C'était magnifique et à la fois inquiétant. La curiosité était une des plus grandes qualités de Buzz et à la fois son plus grand défaut. Sans perdre une minute il enfila ses chaussures et partit en direction de la météorite qui à la vue de sa grosseur dans le ciel n'avait pas du tomber bien loin. Ce n'est qu'après une heure de marche qu'un cratère au loin commençait à prendre forme.";
    }


    void Update()
    {
        if (j == 2)
        {
            if (i < strComplete.Length)
            {
                Text.text += strComplete[i++];
            }
            j = 0;
        }
        else
        {
            j++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(i< strComplete.Length)
            {
                Text.text = strComplete;
                voix.Stop();
                i = strComplete.Length;
            }else
            {
                SceneManager.LoadScene(2);
            }
            
        }

    }

}

