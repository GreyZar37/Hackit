using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonFunction : MonoBehaviour
{


    public UnityEvent buttonFunction;
    public Animator animator;
    public GameObject gameManegerObj;

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
        gameManegerObj.GetComponent<AudioSource>().PlayOneShot(gameManegerObj.GetComponent<GameManager>().buttonChangeClip);

        if (animator != null)
        animator.SetBool("IsRunning", true);
    }
    private void OnMouseExit()
    {
        if(animator != null)
        animator.SetBool("IsRunning", false);
        
    }
    private void OnMouseDown()
    {
        gameManegerObj.GetComponent<AudioSource>().PlayOneShot(gameManegerObj.GetComponent<GameManager>().buttonClickClip);

        buttonFunction.Invoke();
    }
}
