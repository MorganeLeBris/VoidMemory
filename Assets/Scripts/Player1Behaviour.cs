using UnityEngine;
using UnityEngine.UI;

public class Player1Behaviour : MonoBehaviour {

    public float speed;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text question;
    public Text reponse;
    public GameObject masque;
    public bool canMove = true;
    private int num = 1;
    private string str;
    private int i = 0;



    void Start()
    {
        question.gameObject.SetActive(false);
    }
   void FixedUpdate()
    {
        if(canMove)
            Movement();
        if (num == 4)
        {
            question.gameObject.SetActive(true);
            masque.SetActive(false);
            canMove = false;
            Ecriture();
        }
    }
    //private void Put_KeyDown(KeyEventArgs e)
   // {
     //   Debug.Log("Bouh");
    //    if (!canMove)
    //    {
    //        reponse.text = reponse.text + e.KeyValue;
   //     }
  //  }

    void Ecriture()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            str = "a";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            str = "b";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            str = "c";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            str = "d";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            str = "e";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            str = "f";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            str = "g";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            str = "h";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            str = "i";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            str = "j";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            str = "k";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            str = "l";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            str = "m";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            str = "n";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            str = "o";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            str = "p";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            str = "q";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            str = "r";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            str = "s";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            str = "t";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            str = "u";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            str = "v";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            str = "w";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            str = "x";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            str = "y";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            str = "z";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            str = " ";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.Quote))
        {
            str = "\'";
            reponse.text = reponse.text + str;
            i++;
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            i--;
            reponse.text = reponse.text.Substring(0, i);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if(reponse.text.Trim() =="terre" || reponse.text.Trim() == "la terre")
            {
                reponse.text = reponse.text + "   SUCCES";
            }else
            {
                reponse.text = " ";
            }
        }
    }

    void Movement()
    {

		if (Input.GetKey(KeyCode.Z))
		{
			transform.Translate(Vector2.up * speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.Q))
		{
			transform.Translate(Vector2.left * speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (num == 1)
        {
            if (other.gameObject.GetComponent<Text>() != null)
            {
                str = other.gameObject.GetComponent<Text>().text;
                animateText(str);
                Destroy(other.gameObject);
                num++;
            }
              
        }
        else if (num == 2)
        {
            str = other.gameObject.GetComponent<Text>().text;
            int i = 0;
            text2.text = "";
            while (i < str.Length)
            {
                text2.text += str[i++];
                new WaitForSeconds(0.5F);
            }
            Destroy(other.gameObject);
            num++;
        }
        else if (num == 3)
        {
            str = other.gameObject.GetComponent<Text>().text;
            int i = 0;
            text3.text = "";
            while (i < str.Length)
            {
                text3.text += str[i++];
                new WaitForSeconds(0.5F);
            }
            Destroy(other.gameObject);
            num++;

        }
    }
    public void animateText(string strComplete)
    {
        int i = 0;
        while (i < strComplete.Length)
        {
            text1.text += strComplete[i++];
            new WaitForSeconds(0.5f);
        }
    }

}

