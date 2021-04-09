using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ComputerAnimations : MonoBehaviour
{

    
    int loops;
    Animator animmator;
    public GameObject mainMenu;
    public GameObject gameManager;



    // Start is called before the first frame update
    void Start()
    {
        animmator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void changeLoadingScreenAnim()
    {
        loops++;

        if(loops >= 4)
        {
            
            animmator.SetBool("loadingScreenHasEndedStart", true);
            loops = 0;
        }

    }
    public void changeStartScreenAnim()
    {
        
        animmator.SetBool("loadingScreenHasEndedStart", false);
        animmator.SetBool("startScreenHasEnded", true);

     mainMenu.SetActive(true);
    }

    public void LoadingScreenFromMainScreen()
    {
        loops++;
        if(loops == 1)
        {
            animmator.SetBool("startScreenHasEnded", false);
            animmator.SetBool("startButtonClicked", true);
            gameManager.GetComponent<GameManager>().changeSceneToGameMenu();
        }
        

        
        else if (loops >= 4)
        {
            animmator.SetBool("startButtonClicked", false);
            gameManager.GetComponent<GameManager>().gameMenu.SetActive(true);
           loops = 0;
        }

    }
   
    
}
