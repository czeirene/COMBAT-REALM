using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class fightscript : MonoBehaviour
{   
    public TextMeshProUGUI playerOneName;
    public TextMeshProUGUI playerTwoName;
    public TextMeshProUGUI playerOneHPUI;
    public TextMeshProUGUI playerTwoHPUI;

    public Button specialOne;
    public Button specialTwo;

    public int playerOneHP;
    public int playerTwoHP;

    // VIDEO CLIPS / SOURCE
    public VideoPlayer idleAnimSr;
    public VideoPlayer attackSr;
    public GameObject rawAttack;

    public VideoClip idle;
    // PLAYER ONE
    public VideoClip P1lowkick;
    public VideoClip P1highkick;
    public VideoClip P1lowpunch;
    public VideoClip P1highpunch;
    public VideoClip P1special;

    public VideoClip P2lowkick;
    public VideoClip P2highkick;
    public VideoClip P2lowpunch;
    public VideoClip P2highpunch;
    public VideoClip P2special;

    // MISSED ATK CLIPS

    public VideoClip mp1lowkick;
    public VideoClip mp1highkick;
    public VideoClip mp1lowpunch;
    public VideoClip mp1highpunch;
    public VideoClip mp1special;

    public VideoClip mp2lowkick;
    public VideoClip mp2highkick;
    public VideoClip mp2lowpunch;
    public VideoClip mp2highpunch;
    public VideoClip mp2special;

    void Awake()
    {
        playerOneName.text = nameshandler.displayer.playerName1;
        playerTwoName.text = nameshandler.displayer.playerName2;
        playerOneHP = nameshandler.displayer.playerHealth;
        playerTwoHP = nameshandler.displayer.playerHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        idleAnimSr.gameObject.GetComponent<VideoPlayer>().clip = idle;
        idleAnimSr.gameObject.GetComponent<VideoPlayer>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        playerOneHPUI.text = playerOneHP + "";
        playerTwoHPUI.text = playerTwoHP + "";
        StartCoroutine(healthChecker());
    }

    public void dealDamage(int playerNum, int playerHP, int damage)
    {
        if (playerNum == 1)
            {
                playerHP -= damage;
                playerTwoHP = playerHP;
                rawAttack.SetActive(false);
            }

        else
            {
                playerHP -= damage;
                playerOneHP = playerHP;
                rawAttack.SetActive(false);
            }
    }

    // PLAYER ONE BUTTON ATTACKS
    public void playerOneLowPunch()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1lowpunch;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        rawAttack.SetActive(true);
        StartCoroutine(delayProcess(1,75,1));
        Debug.Log("clack");
    }

    public void playerOneHighPunch()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1highpunch;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,55,2));
        Debug.Log("clack");
    }

    public void playerOneLowKick()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1lowkick;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,65,3));
        Debug.Log("clack");
    }

    public void playerOneHighKick()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1highkick;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,45,4));
        Debug.Log("clack");
    }

    public void playerOneSpecial()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1special;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(1,90,5));
        specialOne.interactable = false;
        Debug.Log("clack");
    }
    
    // PLAYER TWO BUTTON ATTACKS

    public void playerTwoLowPunch()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2lowpunch;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,75,1));
        Debug.Log("clack");
    }

    public void playerTwoHighPunch()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2highpunch;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,55,2));
        Debug.Log("clack");
    }

    public void playerTwoLowKick()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2lowkick;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,65,3));
        Debug.Log("clack");
    }

    public void playerTwoHighKick()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2highkick;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,45,4));
        Debug.Log("clack");
    }

    public void playerTwoSpecial()
    {
        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2special;
        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
        StartCoroutine(delayProcess(2,90,5));
        specialTwo.interactable = false;
        Debug.Log("clack");
    }

    public IEnumerator delayProcess(int playerNumber, int accuracy,int attackNumber)
    {   
        int x = Random.Range(0,101);
        // PLAYER 1 ATK AND MISS
        if (playerNumber == 1)
        {   
            if (x <= accuracy)
            {
                    switch (attackNumber)
                    {
                    case 1:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1lowpunch;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(2);
                    dealDamage(1,playerTwoHP,3);
                    Debug.Log("ting");
                    break;

                    case 2:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1highpunch;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(3);
                    dealDamage(1,playerTwoHP,8);
                    break;

                    case 3:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1lowkick;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(2);
                    dealDamage(1,playerTwoHP,6);
                    break;

                    case 4:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1highkick;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(3);
                    dealDamage(1,playerTwoHP,12);
                    break;

                    case 5:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = P1special;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(5);
                    dealDamage(1,playerTwoHP,25);
                    break;
                }
            }

            // miss p1
            else
            {
                switch (attackNumber)
                {
                    case 1:
                    Debug.Log("ting");
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1lowpunch;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(2);
                    rawAttack.SetActive(false);
                    break;

                    case 2:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1highpunch;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(3);
                    rawAttack.SetActive(false);
                    break;

                    case 3:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1lowkick;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(2);
                    rawAttack.SetActive(false);
                    break;

                    case 4:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1highkick;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(3);
                    rawAttack.SetActive(false);
                    break;

                    case 5:
                    attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp1special;
                    attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                    rawAttack.SetActive(true);
                    yield return new WaitForSeconds(5);
                    rawAttack.SetActive(false);
                    break;
                }
            }
        }
        // PLAYER 2 ATK AND MISS
        else
        {
           if (x <= accuracy)
                {
                    switch (attackNumber)
                    {
                        case 1:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2lowpunch;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        dealDamage(2,playerOneHP,3);
                        break;

                        case 2:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2highpunch;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        dealDamage(2,playerOneHP,8);
                        break;

                        case 3:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2lowkick;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        dealDamage(2,playerOneHP,6);
                        break;

                        case 4:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2highkick;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        dealDamage(2,playerOneHP,12);
                        break;

                        case 5:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = P2special;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(5);
                        dealDamage(2,playerOneHP,25);
                        break;
                    }
                }
            // MISS p2
            else
                {
                    switch (attackNumber)
                    {
                        case 1:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2lowpunch;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        rawAttack.SetActive(false);
                        break;

                        case 2:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2highpunch;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        rawAttack.SetActive(false);
                        break;

                        case 3:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2lowkick;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(2);
                        rawAttack.SetActive(false);
                        break;

                        case 4:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2highkick;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(3);
                        rawAttack.SetActive(false);
                        break;

                        case 5:
                        attackSr.gameObject.GetComponent<VideoPlayer>().clip = mp2special;
                        attackSr.gameObject.GetComponent<VideoPlayer>().Play();
                        rawAttack.SetActive(true);
                        yield return new WaitForSeconds(5);
                        rawAttack.SetActive(false);
                        break;
                    }
                }
          

        }
    }

    IEnumerator healthChecker()
    {
        if (playerOneHP <= 0)
        {
            nameshandler.displayer.winner = 2;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(2);
        }

        if (playerTwoHP <= 0)
        {
            nameshandler.displayer.winner = 1;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(2);
        }

    }

}