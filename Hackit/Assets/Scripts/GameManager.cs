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

    public TMP_Text responseText;
   
    public TMP_InputField writenCodeInput;
    public GameObject writenCodeInputGbj;

    float delay = 0.01f;
    public string fullText;

    public bool textDone = true;
    public float delayTextTime;
    public float delayCurrentTime;


    [Header("Options")]

    const string help = "help()";
    const string leaveMission = "leaveMission()";
    const string missionInfo = "mission()";
    const string commands = "commands()";
    const string commandsHacking = "commands(hacking)";

    [Header("Codes")]

    string currentCode;

    const string securityScan = "securityScan()";
    const string hackSecurity = "hack(security)";
    const string stealDataCode = "steal(data)";
    const string hackit = "hackit()";


    [Header("GamePlayOriented")]
    bool firstTime = true;
    bool hackingMode = false;
    int detectionRiskInt;
    string detectionRisk;
    bool securityHacking;
    bool waitingForInputAndWaitingForGameplay;
    bool waitingForInput;

    


    [Header("SecuritySystem")]


    bool hasSecurity;
    bool hasSC_PRO;


    string modelLevel;
    string modelLevelNone = "Null";
    string modelLevelOne = "X9000";
    string modelLeveTwo = "X9125";

    string securityLevel;
    string securityLevelNone = "Null";
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
    
    void Start()
    {
     

    }

    void Update()
    {

        print(waitingForInputAndWaitingForGameplay);
        print(waitingForInput);

        delayCurrentTime -= Time.deltaTime;

        if(delayCurrentTime <= 0)
        {
            textDone = true;
        }
        else
        {
            textDone = false;
        }


        if(textDone == true && waitingForInputAndWaitingForGameplay == false)
        {
            writenCodeInput.ActivateInputField();
            
        }
        else if(textDone == false)
        {
            writenCodeInput.DeactivateInputField();
            
        }
        if(waitingForInputAndWaitingForGameplay == true || waitingForInput == true)
        {
            writenCodeInput.DeactivateInputField();
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

        
        if (Input.GetKeyDown(KeyCode.LeftControl) && textDone == true || Input.GetKeyDown(KeyCode.RightControl) && textDone == true)
        {
            writenCodeInput.text = "";
            currentCode = "";

            fullText = "Error <<< No permission to use control<<<\n\n";
            delayCurrentTime = 0.5f;
            StartCoroutine("ShowText");
        }

            if (Input.GetKeyDown(KeyCode.Return) && textDone==true)
        {
            currentCode = writenCodeInput.text;

          
            if(hackingMode == false)
            {
                switch (currentCode)
                {

                    case help:
                        fullText = "help()\n\n" + ">>>You have several hacking commands that you must write to be able to " +
                        "hack into the system\n <<< Remember to scan the security before hacking it\n " + "<<Use this command to enter hacking" +
                        " mode >>> " + " " + hackit + " \n"+ "There is no turning back when you enter hacking mode<<\n" + ">>> Use " +
                        "this command: " + " " + commandsHacking + " " + " to see all available hacking commands\n >>> Use this command: " + " " + commands + " " + " to see all<<< " +
                        "available non-hacking commands\n" + "  /// You can buy more hacking commands in the shop<<\n\n";

                        delayCurrentTime = 8f;

                        StartCoroutine("ShowText");
                        currentCode = "";


                        break;

                    case commands:
                        fullText = commands + "\n\n" + "<<commands>>:\n" + help + "\n " + leaveMission +"\n  " + missionInfo + "\n " + commandsHacking + "\n\n";

                        StartCoroutine("ShowText");

                        delayCurrentTime = 1f;
                        currentCode = "";
                        break;


                    case leaveMission:

                        
                        gamePlayObj.SetActive(false);
                        missionsMenu.SetActive(true);

                        securityIsHacked = false;
                        responseText.text = "";
                        currentCode = "";
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

                    case hackSecurity:

                        fullText = "<<Error You need to enter hacking mode to use this command<<";

                        break;

                    case hackit:

                        responseText.text = "";

                        if(firstTime == true)
                        {
                            fullText = ">>NOW YOU HAVE ENTERED HACKING MODE>\n <<YOU NEED TO HACK THE SYSTEM!! TYPE "+ "<"+commandsHacking +">"+ " TO SEE ALL THE HACKING COMMANDS>>\n >>>YOU " +
                                "HAVE LIMITED TIME!!!\n\n" + "<<WARNING>> YOU ENTERED HACKING MODE <<WARNING>>\n\n" + ">!!>>>!!>DONT WASTE YOUR TIME AND START HACKING!!!>>>!!!>\n\n";
                            delayCurrentTime = 3.5f;
                            StartCoroutine("ShowText");
                            currentCode = "";

                            hackingMode = true;

                        }
                        else if(firstTime == false)
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
            else if(hackingMode == true && securityHacking == false)
            {

                switch (currentCode)
                {
                    case help:

                        break;

                    case commands:

                        fullText = "<<!!COMMAND LIST BLOCKED!!>>\n\n";

                        StartCoroutine("ShowText");

                        delayCurrentTime = 0.5f;
                        currentCode = "";

                        break;


                    case leaveMission:
                   
                        gamePlayObj.SetActive(false);
                        missionsMenu.SetActive(true);

                        securityIsHacked = false;
                        hackingMode = false;
                        responseText.text = "";
                        currentCode = "";
                        break;

                    case commandsHacking:

                        fullText = commandsHacking + "\n\n" + "<<!!YOUR HACKING LIST!!>:\n" + hackSecurity + "\n " + stealDataCode  + "\n\n";
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

                        if(securityIsHacked == false)
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


            else if (hackingMode == true && securityHacking == true)
            {
                
                if (currentCode.ToLower() == modelLevel.ToLower() && waitingForInputAndWaitingForGameplay == false)
                {
                   
                    waitingForInputAndWaitingForGameplay = true;
                    fullText = "!!HACKING STARTS....!\n\n" + "(PRESS SPACE TO PROCEED)\n\n";
                    StartCoroutine("ShowText");
                    currentCode = "";


                }
                else if (currentCode.ToLower() != modelLevel.ToLower() && waitingForInputAndWaitingForGameplay == false)
                {
                    detectionRiskInt++;
                    fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper();
                    StartCoroutine("ShowText");
                    currentCode = "";
                }

            }

           


            writenCodeInput.text = "";
        }
        if (waitingForInputAndWaitingForGameplay == true)
        
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {

               

                   if (firstTime == true && waitingForInput == false)
                   {
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

                        fullText = "<<NOW IT IS TIME TO HACK IT<<\n\n" + "<<PRESS THE SAME BUTTONS AS SHOWN IN THE CONSOLE<<\n\n" + arrowDirection.ToUpper() + "\n\n";

                        StartCoroutine("ShowText");

                    currentCode = "";
                        waitingForInput = true;




                    }
                    else if (firstTime == false & waitingForInput == false)
                    {
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
                        currentCode = "";
                        waitingForInput = true;


                    }

            }

            arrowQuickAction();
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


    public void poorMission_()
    {
        missionsMenu.SetActive(false);
        gamePlayObj.SetActive(true);

        tutorial();

        hasSecurity = false;
        securityLevel = securityLevelNone;
        modelLevel = modelLevelNone;
        hackingDifficulty = hackingDifficultyNone;
        securityCode = securityLevelNone;
        securityPassColor = securityPassColorNone;
        securityBrand = securityBrandNone;
        hasSC_PRO = false;



       



    }
    public void accountMission_()
    {
        missionsMenu.SetActive(false);
        gamePlayObj.SetActive(true);

        tutorial();


        hasSecurity = true;
        securityLevel = securityLevelOne.ToString();
        modelLevel = modelLevelOne;
        hackingDifficulty = hackingDifficultyOne;
        securityCode = securityCodeOne.ToString();
        securityPassColor = securityPassColorOne;
        securityBrand = securityBrandOne;
        hasSC_PRO = false;
    }
    public void storeMission_()
    {
        missionsMenu.SetActive(false);
        gamePlayObj.SetActive(true);

        tutorial();

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
                "<><Type " + " " + commands + " " + " to see all non-hacking commands\n\n";
           
            delayCurrentTime = 8f;
            StartCoroutine("ShowText");

        }
    }



    public void securityScan_()
    {
        if(firstTime == true)
        {
            fullText = "securityCheck()\n\n" + "Pay close attention to security information <<< You will need it later! >> Once you start " +
                "hacking, you will not be able to scan the security>>\n\n " + "Has security = " + hasSecurity + "\n Has SC_PRO = " + hasSC_PRO + "\n  Security  " +
              "model = " + modelLevel + "\n    Security Brand = " + securityBrand + "\n    Security Pass Color = "
             + securityPassColor + "\n   Security Code = " + securityCode + "\n  Security level = " + securityLevel + "\n Hacking difficulty = " + hackingDifficulty + "\n\n";

            delayCurrentTime = 5f;
            StartCoroutine("ShowText");
            currentCode = "";
        }
        else
        {
      fullText = "securityScan()\n\n" + "Has security = " + hasSecurity + "\n Has SC_PRO = " + hasSC_PRO + "\n  Security  " +
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
            fullText = "__TYPE THE SECURITY MODEL NAME__\n\n";
            delayCurrentTime = 1f;
            StartCoroutine("ShowText");
            currentCode = "";
            securityHacking = true;


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
        currentCode = "";
      
    }

    public void arrowQuickAction()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (arrowDirection == arrowDown)
            {
                arrowChanger();
            }
            else
            {
                detectionRiskInt++;
                fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper() + arrowDirection.ToUpper() + "\n\n";
                StartCoroutine("ShowText");
                currentCode = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (arrowDirection == arrowUp)
            {
                arrowChanger();
            }
            else
            {
                detectionRiskInt++;
                fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper() + arrowDirection.ToUpper() + "\n\n";
                StartCoroutine("ShowText");
                currentCode = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (arrowDirection == arrowLeft)
            {
                arrowChanger();
            }
            else
            {
                detectionRiskInt++;
                fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper() + arrowDirection.ToUpper() + "\n\n";
                StartCoroutine("ShowText");
                currentCode = "";
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (arrowDirection == arrowRight)
            {
                arrowChanger();
            }
            else
            {
                detectionRiskInt++;
                fullText = "ERROR !!WRONG CODE INPUT!!\n\n" + "SECURITY DETECTION RISK: " + detectionRisk.ToUpper() + "\n\n" + arrowDirection.ToUpper() + "\n\n";
                StartCoroutine("ShowText");
                currentCode = "";

            }
        }
    }
 


}
