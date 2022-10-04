using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class nameshandler : MonoBehaviour
{

     public static nameshandler displayer;
    public string playerName1;
    public string playerName2;
    public int playerHealth;

    public TMP_InputField p1Name;
    public TMP_InputField p2Name;
    public TMP_InputField pHealth;



   public void setVariables()
    {
        nameshandler.displayer.playerName1 = p1Name.text;
        nameshandler.displayer.playerName2 = p2Name.text;
        nameshandler.displayer.playerHealth = System.Convert.ToInt32(pHealth.text);
        SceneManager.LoadScene(1);
    }

     private void Awake()
    {
        if (displayer == null)
        {
            displayer = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

}
}
