using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject gameMenu;
    public GameObject shopMenu;
    public GameObject missionsMenu;
    public GameObject gamePlayObj;
    public GameObject alarmClock;

    public  AudioSource audioSource;
    public  AudioClip buttonChangeClip;
    public  AudioClip buttonClickClip;
    public  AudioClip loadingClip;
    public  AudioClip hackingEntered;
    


    public TMP_Text responseText;

    public TMP_Text informationBoxText;

    public TMP_InputField writenCodeInput;
    public GameObject writenCodeInputGbj;

    float delay = 0.01f;
    public string fullText;
    public string fullTextTwo;

    public bool textDone = true;
    public float delayTextTime;
    public float delayCurrentTime;


    [Header("Options")]

    const string help = "help()";
    const string leaveMission = "leaveMission()";
    const string commands = "commands()";
    const string commandsHacking = "commands(hacking)";

    float restartCooldownTime = 2;
    float currenRestartTimer;



    [Header("Codes")]

    string currentCode;

    const string securityScan = "securityScan()";
    const string hackSecurity = "hack(security)";
    const string stealDataCode = "steal(data)";
    const string hackit = "hackit()";


    [Header("GamePlayOriented")]

    public static int money = 0;

    string mission;
    const string poorMission = "poorMission";
    const string accountMission = "accountMission";
    const string storeMission = "storeMission";


    bool firstTime = true;
    bool hackingMode = false;
    int detectionRiskInt;
    string detectionRisk;
    bool securityHacking;
    bool waitingForInputAndWaitingForGameplay;
    bool waitingForInput;
    bool furtherHack;
    bool noFurtherHack;

    bool timeWasSet = false;
    int timeToHack;
    int timeToHackOne = 300;
    int timeToHackTwo = 150;

    int arrowsLeftLvlOne = 21;
    int arrowsLeftLvlTwo = 45;

    int arrowsLeft;
    bool arrowGameCompletedOne;
    bool arrowGameTwoStarted;
    bool arrowGameTwoEnded;

    bool mainInterfaceActive = true;

    int moneyToGive = 0;
    int moneyToGiveNone = 20;
    int moneyToGiveOne = 500;
    int moneyToGiveTwo = 2500;

    bool dataStolen;

    [Header("SecuritySystem")]


    bool hasSecurity;
    bool hasSC_PRO;

    string securityInfo;
    int securityNum;

    string modelLevel;
    string modelLevelNone = "Null";
    string modelLevelOne = "X9000";
    string modelLeveTwo = "X9125";

    int securityLevel;
    int securityLevelNone = 0;
    int securityLevelOne = 1;
    int securityLevelTwo = 2;

    string securityCode;
    string securityCodeNone = "Null";
    int securityCodeOne = 323;
    int securityCodeTwo = 9134;

    string hackingDifficulty;
    string hackingDifficultyNone = "Very easy";
    string hackingDifficultyOne = "Easy";
    string hackingDifficultyTwo = "Medium";

    string securityBrand;
    string securityBrandNone = "Null";
    string securityBrandOne = "FireLax";
    string securityBrandTwo = "Unten101";

    string securityPassColor;
    string securityPassColorNone = "Null";
    string securityPassColorOne = "Green";
    string securityPassColorTwo = "Yellow";

    string arrowDirection;
    const string arrowUp = "Arrow up";
    const string arrowDown = "Arrow down";
    const string arrowLeft = "Arrow left";
    const string arrowRight = "Arrow right";
    int arrowDirectionInt;


    bool securityIsHacked;
    bool securityIs50Hacked;

    void Start()
    {
       
    }

    void Update()
    {
       
        restartMethod();

        timeAndDetection();

        controlRestriction();

        fieldActivateTrueAndFalse();

        #region

        if (waitingForInputAndWaitingForGameplay == true || waitingForInput == true)
        {
            writenCodeInput.DeactivateInputField();
        }

        if (securityIsHacked == true)
        {
            mainInterfaceActive = true;
        }
        #endregion;

        FurtherHack_();

     
       
        
        if(Input.GetKeyDown(KeyCode.Return) && textDone == true && mainInterfaceActive == true)
        {
            currentCode = writenCodeInput.text;
            if (hackingMode == true && securityHacking == true && arrowGameCompletedOne == false)
            {
              

                if (currentCode.ToLower() == securityInfo.ToLower() && waitingForInputAndWaitingForGameplay == false)
                {
               
                    waitingForInputAndWaitingForGameplay = true;
                    fullText = "!!HACKING STARTS....!\n\n" + "(PRESS SPACE TO PROCEED)\n\n";
                    delayCurrentTime = 2f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                    

                }

                else if (currentCode.ToLower() != securityInfo.ToLower() && waitingForInputAndWaitingForGameplay == false)
                {
                    detectionRiskInt++;
                    fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper();
                    delayCurrentTime = 2f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                    
                }

                writenCodeInput.text = "";
            }


        }

        if (waitingForInputAndWaitingForGameplay == true)

        {

            if (Input.GetKeyDown(KeyCode.Space))
            {



                if (firstTime == true && waitingForInput == false)
                {
                    arrowDirectionInt = Random.Range(1, 5);
                    switch (arrowDirectionInt)
                    {
                        case 1:
                            arrowDirection = arrowUp;
                            break;
                        case 2:
                            arrowDirection = arrowDown;
                            break;
                        case 3:
                            arrowDirection = arrowLeft;
                            break;
                        case 4:
                            arrowDirection = arrowRight;
                            break;

                        default:
                            break;
                    }

                    fullText = "<<NOW IT IS TIME TO HACK IT<<\n\n" + "<<PRESS THE SAME BUTTONS AS SHOWN IN THE CONSOLE<<\n\n" + arrowDirection.ToUpper() + "\n\n";
                    delayCurrentTime = 0.5f;
                    StartCoroutine("ShowText");

                    currentCode = "";
                    waitingForInput = true;




                }
                else if (firstTime == false & waitingForInput == false)
                {
                    arrowDirectionInt = Random.Range(1, 5);
                    switch (arrowDirectionInt)
                    {
                        case 1:
                            arrowDirection = arrowUp;
                            break;
                        case 2:
                            arrowDirection = arrowDown;
                            break;
                        case 3:
                            arrowDirection = arrowLeft;
                            break;
                        case 4:
                            arrowDirection = arrowRight;
                            break;

                        default:
                            break;
                    }

                    fullText = arrowDirection.ToUpper() + "\n\n";

                    StartCoroutine("ShowText");
                    currentCode = "";
                    waitingForInput = true;


                }

            }

            arrowQuickAction();

        }

        if (Input.GetKeyDown(KeyCode.Return) && textDone == true && mainInterfaceActive == true)
        {
            currentCode = writenCodeInput.text;

            if (hackingMode == false)
            {
                switch (currentCode)
                {

                    case help:
                        fullText = "help()\n\n" + ">>>You have several hacking commands that you must write to be able to " +
                        "hack into the system\n <<< Remember to scan the security before hacking it\n " + "<<Use this command to enter hacking" +
                        " mode >>> " + " " + hackit + " \n" + "There is no turning back when you enter hacking mode<<\n" + ">>> Use " +
                        "this command: " + " " + commandsHacking + " " + " to see all available hacking commands\n >>> Use this command: " + " " + commands + " " + " to see all<<< " +
                        "available non-hacking commands\n" + "<<Press left alt>>" + " to restart the mission\n" + "  /// You can buy more hacking commands in the shop<<\n\n";

                        delayCurrentTime = 8f;

                        StartCoroutine("ShowText");
                        currentCode = "";


                        break;

                    case commands:
                        fullText = commands + "\n\n" + "<<commands>>:\n" + help + "\n " + leaveMission + "\n " +  "\n" + commandsHacking + "\n\n";

                        StartCoroutine("ShowText");

                        delayCurrentTime = 1f;
                        currentCode = "";
                        break;


                    case leaveMission:

                        leaveMission_();


                        break;


                    case commandsHacking:


                        fullText = commandsHacking + "\n\n" + "<<Available hacking commands>>:\n" + securityScan + "\n " + hackSecurity + "\n " + stealDataCode + "\n" + hackit + "\n\n";
                        delayCurrentTime = 1f;
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;


                    case securityScan:

                        securityScan_();

                        break;

                    case stealDataCode:

                        fullText = "<<Error You need to enter hacking mode to use this command<<\n\n";
                        delayCurrentTime = 1f;
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;

                    case hackSecurity:

                        fullText = "<<Error You need to enter hacking mode to use this command<<\n\n";
                        delayCurrentTime = 1f;
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;

                    case hackit:

                        responseText.text = "";

                        if (firstTime == true)
                        {
                            fullText = ">>NOW YOU HAVE ENTERED HACKING MODE>\n <<YOU NEED TO HACK THE SYSTEM!! TYPE " + "<" + commandsHacking + ">" + " \nTO SEE ALL THE HACKING COMMANDS>>\n >>>YOU " +
                                "HAVE LIMITED TIME!!!\n\n" + "<<WARNING>> YOU ENTERED HACKING MODE <<WARNING>>\n\n" + ">!!>>>!!>DONT WASTE YOUR TIME AND START HACKING!!!>>>!!!>\n\n";
                            delayCurrentTime = 3.5f;
                            StartCoroutine("ShowText");
                            currentCode = "";

                            hackingMode = true;

                        }
                        else if (firstTime == false)
                        {
                            fullText = "<<WARNING>> YOU ENTERED HACKING MODE <<WARNING>>\n\n" + ">!!>>>!!>DONT WASTE YOUR TIME AND START HACKING!!!>>>!!!>\n\n";
                            delayCurrentTime = 1f;
                            StartCoroutine("ShowText");
                            currentCode = "";

                            hackingMode = true;
                        }

                        break;



                    default:

                        delayCurrentTime = 0.5f;
                        fullText = "<<Error wrong code input>>\n\n";
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;


                }
              

            }
            else if (hackingMode == true && securityHacking == false)
            {

                switch (currentCode)
                {
                    case help:

                        break;


                    case commands:
                        fullText = commands + "\n\n" + "<<commands>>:\n".ToUpper() + help + "\n " + leaveMission + "\n " + "\n" + commandsHacking + "\n\n";

                        StartCoroutine("ShowText");

                        delayCurrentTime = 1f;
                        currentCode = "";
                        break;


                    case leaveMission:

                        leaveMission_();
                        break;

                    case commandsHacking:

                        fullText = commandsHacking + "\n\n" + "<<!!YOUR HACKING LIST!!>:\n" + hackSecurity + "\n " + stealDataCode + "\n\n";
                        delayCurrentTime = 1f;
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;

                    case securityScan:

                        fullText = "<<!!ERROR SCAN FAILD!!>>\n\n";
                        delayCurrentTime = 0.5f;
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;

                    case hackSecurity:

                        if (securityIsHacked == false)
                        {
                            hackSecurity_();

                        }
                        else
                        {
                            fullText = ">>!!!ALREADY HACKED>>!!!\n\n";
                            delayCurrentTime = 0.5f;
                            StartCoroutine("ShowText");
                            currentCode = "";
                        }



                        break;


                    case stealDataCode:

                        dataSteal();

                        break;


                    case hackit:

                        fullText = ">>!!!ALREADY ENTERED>>!!!\n\n";
                        delayCurrentTime = 0.5f;
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;


                    default:

                        delayCurrentTime = 0.5f;
                        fullText = "<<ERROR NOTHING FOUND!!!>>\n\n";
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;
                }

              

                
            }

            writenCodeInput.text = "";

        }
        
    }

    public void changeSceneToOptionMenu()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }
    public void changeSceneToMainMenu()
    {
        mainMenu.SetActive(true);
        optionMenu.SetActive(false);
        gameMenu.SetActive(false);
    }
    public void changeSceneToMissonsMenu()
    {
        missionsMenu.SetActive(true);
        gameMenu.SetActive(false);
        mainMenu.SetActive(false);
    }
    public void changeSceneToShopMenu()
    {
        shopMenu.SetActive(true);
        gameMenu.SetActive(false);
    }
    public void changeSceneToGameMenu()
    {
        shopMenu.SetActive(false);
       
        missionsMenu.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }

    IEnumerator ShowText()
    {
        for(int i = 0; i < fullText.Length; i++)
        {
            responseText.text += fullText[i];
                 
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator ShowTextInfoBox()
    {
        for (int i = 0; i < fullTextTwo.Length; i++)
        {
                informationBoxText.text += fullTextTwo[i];
            

                yield return new WaitForSeconds(delay);
        }
    }


    public void poorMission_()
    {
        missionsMenu.SetActive(false);
        gamePlayObj.SetActive(true);

        mission = poorMission;
        moneyToGive = moneyToGiveNone;
        alarm.alarmTimer = 0;
        alarmClock.GetComponent<alarm>().DisplayTimer();

        tutorial();

        hasSecurity = false;
        securityLevel = securityLevelNone;
        modelLevel = modelLevelNone;
        hackingDifficulty = hackingDifficultyNone;
        securityCode = securityCodeNone;
        securityPassColor = securityPassColorNone;
        securityBrand = securityBrandNone;
        hasSC_PRO = false;



       



    }
    public void accountMission_()
    {
        missionsMenu.SetActive(false);
        gamePlayObj.SetActive(true);

        mission = accountMission;
        moneyToGive = moneyToGiveOne;
        alarm.alarmTimer = timeToHackOne;
        alarmClock.GetComponent<alarm>().DisplayTimer();

        tutorial();


        hasSecurity = true;
        securityLevel = securityLevelOne;
        modelLevel = modelLevelOne;
        hackingDifficulty = hackingDifficultyOne;
        securityCode = securityCodeOne.ToString();
        securityPassColor = securityPassColorOne;
        securityBrand = securityBrandOne;
        hasSC_PRO = false;

        arrowsLeft = arrowsLeftLvlOne;
    }
    public void storeMission_()
    {
        missionsMenu.SetActive(false);
        gamePlayObj.SetActive(true);

        mission = storeMission;
        moneyToGive = moneyToGiveTwo;
        alarm.alarmTimer = timeToHackTwo;
        alarmClock.GetComponent<alarm>().DisplayTimer();

        tutorial();


        hasSecurity = true;
        securityLevel = securityLevelTwo;
        modelLevel = modelLeveTwo;
        hackingDifficulty = hackingDifficultyTwo;
        securityCode = securityCodeTwo.ToString();
        securityPassColor = securityPassColorTwo;
        securityBrand = securityBrandTwo;
        hasSC_PRO = true;

        arrowsLeft = arrowsLeftLvlTwo;
    }
    public void auctionMission_()
    {
        missionsMenu.SetActive(false);
        gamePlayObj.SetActive(true);


    }
    public void bankMission_()
    {
        missionsMenu.SetActive(false);
        gamePlayObj.SetActive(true);

    }
    public void tutorial()
    {
        if (firstTime == true)
        {
            fullText = "Read this carefully\n <<< You will help us get some money. You will be assigned to " +
                "hack companies and individuals\n <>>> Remember that this job is dangerous and " +
                "can lead to a life sentence in jail <<<\n << Always start the job by scanning " +
                "the security " + " " + securityScan + " " + " and deactivate it " + " " + hackSecurity + "  " + "\n" + "Type " + " " + hackit + "  " +
                "to enter hacking mode\n" + "There is no turning back when you enter hacking mode\n" + " << Steal the data you need  " +
                "by using this command: " + " " + stealDataCode + " " + " <<\n " +
                "<<>You can type the command " + " " + help + " " + " to get more information\n" +
                "<><Type " + " " + commands + " " + " to see all non-hacking commands\n" + "<<Press left alt>>" + " to restart the mission\n\n";
           
            delayCurrentTime = 8f;
            StartCoroutine("ShowText");

        }
    }
    public void securityScan_()
    {
        if(firstTime == true)
        {
            fullText = securityScan +"\n\n" + "Pay close attention to security information <<< You will need it later! >> Once you start " +
                "hacking, you will not be able to scan the security>>\n\n " + "Has security = " + hasSecurity + "\n Has SC_PRO = " + hasSC_PRO + "\n  Security  " +
              "model = " + modelLevel + "\n    Security Brand = " + securityBrand + "\n    Security Pass Color = "
             + securityPassColor + "\n   Security Code = " + securityCode + "\n  Security level = " + securityLevel + "\n Hacking difficulty = " + hackingDifficulty + "\n\n";

            delayCurrentTime = 5f;
            StartCoroutine("ShowText");
            currentCode = "";
        }
        else
        {
      fullText = securityScan +"\n\n" + "Has security = " + hasSecurity + "\n Has SC_PRO = " + hasSC_PRO + "\n  Security  " +
      "model = " + modelLevel + "\n    Security Brand = " + securityBrand + "\n    Security Pass Color = "
      + securityPassColor + "\n   Security Code = " + securityCode + "\n  Security level = " + securityLevel + "\n Hacking difficulty = " + hackingDifficulty + "\n\n";

            delayCurrentTime = 4f;
            StartCoroutine("ShowText");
            currentCode = "";
        }
       
    }
    public void hackSecurity_()
    {

        if (hasSecurity == true)
        {
            securityNum = Random.Range(1, 4);
            switch (securityNum)
            {
                case 1:
                    securityInfo = securityPassColor;
                    fullText = "__TYPE THE SECURITY PASS COLOR__\n\n";
                    delayCurrentTime = 1f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                    securityHacking = true;
                    break;
                case 2:
                    securityInfo = securityCode;
                    fullText = "__TYPE THE SECURITY CODE__\n\n";
                    delayCurrentTime = 1f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                    securityHacking = true;
                    break;
                case 3:
                    securityInfo = modelLevel;
                    fullText = "__TYPE THE SECURITY MODEL NAME__\n\n";
                    delayCurrentTime = 1f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                    securityHacking = true;
                    break; 
            }

        }
        else if (hasSecurity == false)
        {
            fullText = "<<<Error no security found<<<\n\n";
            delayCurrentTime = 2f;
            StartCoroutine("ShowText");
            currentCode = "";
        }


    }
    public void arrowChanger()
    {

        arrowsLeft--;
        arrowDirectionInt = Random.Range(1, 5);
        switch (arrowDirectionInt)
        {
            case 1:
                arrowDirection = arrowUp;
                break;
            case 2:
                arrowDirection = arrowDown;
                break;
            case 3:
                arrowDirection = arrowLeft;
                break;
            case 4:
                arrowDirection = arrowRight;
                break;

            default:
                break;
        }

        fullText = arrowDirection.ToUpper() + "\n" + "<ARROWS REMAINING:" + arrowsLeft + "\n\n";

        StartCoroutine("ShowText");
        currentCode = "";
      
    }
    public void arrowQuickAction()
    {

        if(arrowsLeft > 0)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && textDone == true)
            {
                if (arrowDirection == arrowDown)
                {
                    arrowChanger();
                }
                else
                {
                    detectionRiskInt++;
                    fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper() + "\n" + arrowDirection.ToUpper() + "\n\n" ;
                    delayCurrentTime = 1f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && textDone == true)
            {
                if (arrowDirection == arrowUp)
                {
                    arrowChanger();
                }
                else
                {
                    detectionRiskInt++;
                    fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper() + "\n" + arrowDirection.ToUpper() + "\n\n" ;
                    delayCurrentTime = 1.5f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && textDone == true)
            {
                if (arrowDirection == arrowLeft)
                {
                    arrowChanger();
                }
                else
                {
                    detectionRiskInt++;
                    fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper() + "\n" + arrowDirection.ToUpper() + "\n\n";
                    delayCurrentTime = 1.5f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && textDone == true)
            {
                if (arrowDirection == arrowRight)
                {
                    arrowChanger();
                }
                else
                {
                    detectionRiskInt++;
                    fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper() + "\n" + arrowDirection.ToUpper() + "\n\n";
                    delayCurrentTime = 1.5f;
                    StartCoroutine("ShowText");
                    currentCode = "";

                }
            }
           
        }
        else if (arrowsLeft <= 0 && arrowGameTwoStarted == true & arrowGameTwoEnded == false)
        {
            StopAllCoroutines();
            securityIsHacked = true;
            alarm.timerStarted = false;
            securityHacking = false;
            responseText.text = "";
            fullText = "SECURITY IS 100% HACKED\n\n";
            delayCurrentTime = 1f;
            StartCoroutine("ShowText");
            arrowGameTwoEnded = true;

        }
        else if (arrowsLeft <= 0 && arrowGameCompletedOne == false)
        {
            StopAllCoroutines();
            arrowGameCompletedOne = true;
            waitingForInput = false;
            waitingForInputAndWaitingForGameplay = false;
            hackMoreOrNot();

        }
       

    }
   
    public void hackMoreOrNot()
    {
        responseText.text = "";
        fullText = "STOP HACKING NOW WITH 50% SECURITY HACKED OR HACK TO 100%\n\n" + "50%()\n" + "100%()\n\n";
        delayCurrentTime = 0.5f;
        StartCoroutine("ShowText");
    }
    public void dataSteal()
    {

        if(securityIsHacked == true)
        {
            if (dataStolen == false)
            {
                if (securityIsHacked == true && securityIs50Hacked == true)
                {
                    moneyToGive /= 2;
                    money += moneyToGive;
                    responseText.text = "";
                    fullText = "TRANSFERRING: " + moneyToGive + "$ TO YOUR ACCOUNT\n\nTYPE  " + leaveMission + "  TO LEAVE THE MISSION\n\n";
                    delayCurrentTime = 1f;
                    StartCoroutine("ShowText");
                    firstTime = false;
                    dataStolen = true;
                }
                if (securityIsHacked == true && securityIs50Hacked == false)
                {
                    responseText.text = "";
                    money += moneyToGive;
                    fullText = "TRANSFERRING: " + moneyToGive + "$ TO YOUR ACCOUNT\n\nTYPE  " + leaveMission + "  TO LEAVE THE MISSION\n\n";
                    delayCurrentTime = 1f;
                    StartCoroutine("ShowText");
                    firstTime = false;
                    dataStolen = true;
                }
            }
            else
            {
                fullText = ">>!!ERROR DATA ALREADY STOLEN>>!!\n\n";
                delayCurrentTime = 0.5f;
                StartCoroutine("ShowText");
            }
        }
        else if (hasSecurity == false)
        {
            money += moneyToGive;
            responseText.text = "";
            fullText = "TRANSFERRING: " + moneyToGive + "$ TO YOUR ACCOUNT\n\nTYPE  " + leaveMission + "  TO LEAVE THE MISSION\n\n";
            delayCurrentTime = 0.5f;
            StartCoroutine("ShowText");
            dataStolen = true;
        }
        else
        {
            fullText = ">>!!ERROR CAN'T STEAL DATA>>!!\n\n";
            delayCurrentTime = 0.5f;
            StartCoroutine("ShowText");
        }

      

       
    }
    public void leaveMission_()
    {
        
           
            gamePlayObj.SetActive(false);
            missionsMenu.SetActive(true);

            securityIsHacked = false;
            securityIs50Hacked = false;
            waitingForInput = false;
            waitingForInputAndWaitingForGameplay = false;
            alarm.alarmTimer = 0;
            alarm.timerStarted = false;
            dataStolen = false;
            hackingMode = false;
            furtherHack = false;
            noFurtherHack = false;
            timeWasSet = false;
            securityHacking = false;

            detectionRiskInt = 0;

            alarmClock.GetComponent<alarm>().DisplayTimer();


            arrowGameCompletedOne = false;
            arrowGameTwoStarted = false;
            arrowGameTwoEnded = false;

            mainInterfaceActive = true;

            responseText.text = "";
            currentCode = "";
            fullText = "";
        
     
    }

    public void gameOver()
    {
        gamePlayObj.SetActive(false);
        missionsMenu.SetActive(true);

        securityHacking = false;
        securityIsHacked = false;
        securityIs50Hacked = false;
        waitingForInput = false;
        waitingForInputAndWaitingForGameplay = false;
        alarm.alarmTimer = 0;
        alarm.timerStarted = false;
        alarmClock.GetComponent<alarm>().DisplayTimer();
        dataStolen = false;
        hackingMode = false;
        furtherHack = false;
        noFurtherHack = false;
        timeWasSet = false;

        detectionRiskInt = 0;

        arrowGameCompletedOne = false;
        arrowGameTwoStarted = false;
        arrowGameTwoEnded = false;

        mainInterfaceActive = true;

        responseText.text = "";
        currentCode = "";
        fullText = "";
    }

    public void restart_()
    {
        securityHacking = false;
        securityIsHacked = false;
        securityIs50Hacked = false;
        waitingForInput = false;
        waitingForInputAndWaitingForGameplay = false;
        alarm.alarmTimer = 0;
        alarm.timerStarted = false;
        alarmClock.GetComponent<alarm>().DisplayTimer();
        dataStolen = false;
        hackingMode = false;
        furtherHack = false;
        noFurtherHack = false;
        timeWasSet = false;

        detectionRiskInt = 0;

        arrowGameCompletedOne = false;
        arrowGameTwoStarted = false;
        arrowGameTwoEnded = false;

        mainInterfaceActive = true;

        responseText.text = "";
        currentCode = "";
        fullText = "";

        switch (mission)
        {
            case poorMission:
                poorMission_();
                break;

            case accountMission:
                accountMission_();
                break;
            case storeMission:
                storeMission_();
                break;

            default:
                break;
        }
    }

    void restartMethod()
    {

        currenRestartTimer -= Time.deltaTime;
        delayCurrentTime -= Time.deltaTime;

        if (delayCurrentTime <= 0)
        {
            textDone = true;
        }
        else
        {
            textDone = false;
        }


        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (currenRestartTimer <= 0 && textDone == true)
            {
                restart_();
                currenRestartTimer = restartCooldownTime;
            }

        }

    }
    void timeAndDetection()
    {

        if (hackingMode == true)
        {
            switch (securityLevel)
            {
                case 1:
                    if (timeWasSet == false)
                    {
                        alarm.timerStarted = true;
                        timeWasSet = true;
                      
                    }
                    break;
                case 2:
                    if (timeWasSet == false)
                    {
                        alarm.timerStarted = true;
                        timeWasSet = true;
                    }

                    break;
            }
        }
        else if (hackingMode == false)
        {
            alarm.timerStarted = false;
        }


        if (alarm.alarmTimer < 1)
        {

            alarm.alarmTimer = 0;

            if (mission != poorMission && hackingMode == true)
            {
                gameOver();

            }


        }
        if (detectionRiskInt > 3)
        {
            gameOver();
        }

        switch (detectionRiskInt)
        {

            case 0:
                detectionRisk = "Low\n\n";
                break;
            case 1:
                detectionRisk = "Medium\n\n";
                break;
            case 2:
                detectionRisk = "High\n\n";
                break;
            case 3:
                detectionRisk = "Extreme\n\n";
                break;
            case 4:
                detectionRisk = "DETECTED!!\n\n";
                break;

            default:
                break;
        }
    }
    void controlRestriction()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && textDone == true || Input.GetKeyDown(KeyCode.RightControl) && textDone == true)
        {
            writenCodeInput.text = "";
            currentCode = "";

            fullTextTwo = "Error <<< No permission to use control<<<\n\n";
            delayCurrentTime = 0.5f;
            StartCoroutine("ShowTextInfoBox");
        }
    }
    void fieldActivateTrueAndFalse()
    {

        if (textDone == true && waitingForInputAndWaitingForGameplay == false)
        {
            writenCodeInput.ActivateInputField();

        }
        else if (textDone == false)
        {
            writenCodeInput.DeactivateInputField();

        }
    }
    void FurtherHack_()
    {

        if (arrowGameCompletedOne == true && Input.GetKeyDown(KeyCode.Return) && furtherHack == false && securityIsHacked == false)
        {
            mainInterfaceActive = false;
            currentCode = writenCodeInput.text;
            writenCodeInput.text = "";

            switch (currentCode)
            {
                case "50%()":
                    noFurtherHack = true;
                    currentCode = "";
                    break;
                case "100%()":
                    furtherHack = true;
                    currentCode = "";
                    break;

                default:
                    fullText = "WRONG CODE INPUT\n\n";
                    delayCurrentTime = 1f;
                    StartCoroutine("ShowText");
                    currentCode = "";
                    break;
            }
        }




        if (furtherHack == true)
        {
            if (arrowGameTwoStarted == false)
            {
                arrowsLeft = arrowsLeftLvlOne;


                arrowDirectionInt = Random.Range(1, 4);
                switch (arrowDirectionInt)
                {
                    case 1:
                        arrowDirection = arrowUp;
                        break;
                    case 2:
                        arrowDirection = arrowDown;
                        break;
                    case 3:
                        arrowDirection = arrowLeft;
                        break;
                    case 4:
                        arrowDirection = arrowRight;
                        break;

                    default:
                        break;
                }

                fullText = arrowDirection.ToUpper() + "\n\n";

                StartCoroutine("ShowText");
                delayCurrentTime = 0.2f;
                currentCode = "";
            }

            arrowQuickAction();
            arrowGameTwoStarted = true;
        }
        else if (noFurtherHack == true && securityIsHacked == false)
        {
            StopAllCoroutines();
            securityIsHacked = true;
            securityHacking = false;
            securityIs50Hacked = true;
            responseText.text = "";
            fullText = "SECURITY IS 50% HACKED\n\n";
            delayCurrentTime = 1f;
            StartCoroutine("ShowText");
        }
    }

    public void informationBoxEnter()
    {

        switch (ButtonFunctionInfoBox.missionName)
        {
            case "Poor":
                fullTextTwo = "We have found an easy way to get some money. You have to hack this poor man's laptop and get all his data. He does not have any protection on his laptop. Good luck";
                StartCoroutine("ShowTextInfoBox");
                break;
            case "Account":
                fullTextTwo = "We have found a prosperous bank account that you must hack for some good profit. This job is not as easy as you recall. The bank account is under protection by a security " +
                    "brand called FireLax. If you can shut down the security, we will be able to take all his money. Good luck";
                StartCoroutine("ShowTextInfoBox");
                break;
            case "Store":
                fullTextTwo = "It is time for you to show off your skills. We want you to hack and steal the money the store hides. I heard that the store is not cheap, so you will be " +
                    "capable to get some big money from this mission. Remember this job is not for amateurs. Good luck";
                StartCoroutine("ShowTextInfoBox");
                break;


            default:
                break;
        }
        

    }
    public void informationBoxExitOrReturn()
    {
        fullTextTwo = "";
        informationBoxText.text = "";
 
    }

}
