using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class exitt : MonoBehaviour
{
    public void pressQuit()
    {
        
    IEnumerator quit(){
        yield return new WaitForSeconds(1);
        Application.Quit();
    }


    }

    public void retry()
    {
        SceneManager.LoadScene(1);
    }

}
