using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public Sprite[] sprites;
    public SpriteRenderer spriteRend;
    public int index = 10;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sfxDown()
    {
        index = Mathf.Clamp(index - 1, 0, 10);
        updateUI();
    }
    public void sfxUp()
    {
        index = Mathf.Clamp(index + 1, 0, 10);
        updateUI();
    }
    private void updateUI()
    {
        Debug.Log(index,this);
        spriteRend.sprite = sprites[index];
    }

}
