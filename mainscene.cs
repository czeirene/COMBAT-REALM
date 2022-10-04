using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mainscene : MonoBehaviour
{

     public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GOGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     public void NextScene(){
      SceneManager.LoadScene(2);
    }
    public void PreviousScene(){
      SceneManager.LoadScene(1);
    }

      public static mainscene scene1; 
   public TMP_InputField inputField1; 
   public TMP_InputField inputField2;
   public TMP_InputField inputField3;

   public string player_name1; 
   public string player_name2;
   public string player_health;

   private void Awake() 
   {
        if (scene1 == null)
        {
            scene1 = this;
            DontDestroyOnLoad(gameObject);
        }
   }
   
   public void SetPlayerName1 ()
   {
    player_name1 =  inputField1.text;
    SceneManager.LoadSceneAsync("mainscene");
   }

    public void SetPlayerName2 ()
   {
    player_name2 =  inputField2.text;
    SceneManager.LoadSceneAsync("mainscene");
   }
 
     public void SetPlayerHealth ()
   {
    player_health =  inputField3.text;
    SceneManager.LoadSceneAsync("mainscene");
   }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
