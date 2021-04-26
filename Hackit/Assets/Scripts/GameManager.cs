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

    bool securityIsHacked;

    void Start()
    {
     

    }

    void Update()
    {

        delayCurrentTime -= Time.deltaTime;

        if(delayCurrentTime <= 0)
        {
            textDone = true;
        }
        else
        {
            textDone = false;
        }


        if(textDone == true)
        {
            writenCodeInput.ActivateInputField();
        }
        else if(textDone == false)
        {
            writenCodeInput.DeactivateInputField();
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
                        " mode >>> " + "<" + hackit + ">\n"+ "There is no turning back when you enter hacking mode<<\n" + ">>> Use " +
                        "this command: " + "<" + commandsHacking + ">" + " to see all available hacking commands\n >>> Use this command: " + "<" + commands + ">" + " to see all<<< " +
                        "available non-hacking commands\n" + "  /// You can buy more hacking commands in the shop<<\n\n";

                        delayCurrentTime = 6f;

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

                        fullText = "<<WARNING>> YOU ENTERED HACKING MODE <<WARNING>>\n\n" + ">!!>>>!!>DONT WASTE YOUR TIME AND START HACKING!!!>>>!!!>\n\n";
                        delayCurrentTime = 1f;
                        StartCoroutine("ShowText");
                        currentCode = "";

                        hackingMode = true;

                        break;


                    default:

                        delayCurrentTime = 0.5f;
                        fullText = "<<Error wrong code input>>\n\n";
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;


                }
               
            }
            else if(hackingMode == true)
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

                        fullText = commandsHacking + "\n\n" + "<<!!YOUR HACKING LIST!!>:\n" + securityScan + "\n " + hackSecurity + "\n " + stealDataCode + "\n" + hackit + "\n\n";
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

                    default:

                        delayCurrentTime = 0.5f;
                        fullText = "<<ERROR NOTHING FOUND!!!>>\n\n";
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;
                }




                switch (currentCode)
                {

                    case hackSecurity:

                        hackSecurity_();

                        break;

                    case hackit:

                        fullText = ">>!!!ALREADY ENTERED>>!!!\n\n";
                        delayCurrentTime = 0.5f;
                        StartCoroutine("ShowText");
                        currentCode = "";

                        break;



                    default:
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
                "the security " + "<" + securityScan + ">" + " and deactivate it " + "<" + hackSecurity + "> " + "\n" + "Type " + "<" + hackit + "> " +
                "to enter hacking mode\n" + "There is no turning back when you enter hacking mode\n" + " << Steal the data you need  " +
                "by using this command: " + "<" + stealDataCode + ">" + " <<\n " +
                "<<>You can type the command " + "<" + help + ">" + " to get more information\n" +
                "<><Type " + "<" + commands + ">" + " to see all non-hacking commands " + "The help menu will change during hacking mode\n\n";
           
            delayCurrentTime = 6f;
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

            delayCurrentTime = 2f;
            StartCoroutine("ShowText");
            currentCode = "";
        }
        else
        {
      fullText = "securityScan()\n\n" + "Has security = " + hasSecurity + "\n Has SC_PRO = " + hasSC_PRO + "\n  Security  " +
      "model = " + modelLevel + "\n    Security Brand = " + securityBrand + "\n    Security Pass Color = "
      + securityPassColor + "\n   Security Code = " + securityCode + "\n  Security level = " + securityLevel + "\n Hacking difficulty = " + hackingDifficulty + "\n\n";

            delayCurrentTime = 2f;
            StartCoroutine("ShowText");
            currentCode = "";
        }
       
    }


    public void hackSecurity_()
    {


        if (hasSecurity == true)
        {
            
           
        }
        else if (hasSecurity == false)
        {
            fullText = "<<<Error no security found<<<\n\n";
            delayCurrentTime = 2f;
            StartCoroutine("ShowText");
            currentCode = "";
        }

    }

 


}
