using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonFunctionInfoBox : MonoBehaviour
{


    public UnityEvent buttonFunction;
    public Animator animator;
    public GameManager gameManager;

    public static string missionName;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        switch (this.gameObject.tag)
        {
            case "Poor":
                missionName = "Poor";
                break;
            case "Account":
                missionName = "Account";
                break;
            case "Store":
                missionName = "Store";
                break;

            default:
                break;
        }
      

        if (animator != null)
        animator.SetBool("IsRunning", true);
        gameManager.GetComponent<GameManager>().informationBoxEnter();
    }
    private void OnMouseExit()
    {
        if(animator != null)
        animator.SetBool("IsRunning", false);
        gameManager.GetComponent<GameManager>().informationBoxExitOrReturn();

    }
    private void OnMouseDown()
    {
        buttonFunction.Invoke();
        gameManager.GetComponent<GameManager>().informationBoxExitOrReturn();
    }
}
