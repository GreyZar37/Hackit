using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject gameMenu;
    public GameObject shopMenu;
    public GameObject missionsMenu;
 

    // Start is called before the first frame update
    void Start()
    {

     
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
