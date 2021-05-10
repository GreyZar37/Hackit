using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public Sprite[] sprites;
    public SpriteRenderer spriteRend;
    public int index = 10;
    public GameObject gameManagerObj;
    public GameObject MusicObj;
    public GameObject FanObj;
    float soundVolume = 1f;
    float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        gameManagerObj = GameObject.FindGameObjectWithTag("GameManager");
        MusicObj = GameObject.FindGameObjectWithTag("MusicObj");
        FanObj = GameObject.FindGameObjectWithTag("FanObj");


    }

    // Update is called once per frame
    void Update()
    {
        print(musicVolume);
        gameManagerObj.GetComponent<AudioSource>().volume = soundVolume;
        MusicObj.GetComponent<AudioSource>().volume = musicVolume;
        FanObj.GetComponent<AudioSource>().volume = soundVolume;

    }

    public void sfxDown()
    {

        if (soundVolume <= 0)
        {
            soundVolume = 0;
        }
        if (soundVolume >= 1)
        {
            soundVolume = 1;
        }

        soundVolume -= 0.1f;

         index = Mathf.Clamp(index - 1, 0, 10);
        updateUI();
    }
    public void sfxUp()
    {
        if(soundVolume <= 0)
        {
            soundVolume = 0;
        }
        if(soundVolume >= 1)
        {
            soundVolume = 1;
        }

        soundVolume += 0.1f;
        index = Mathf.Clamp(index + 1, 0, 10);
        updateUI();
    }


    public void musicDown()
    {

        if (musicVolume <= 0)
        {
            musicVolume = 0;
        }
        if (musicVolume >= 1)
        {
            musicVolume = 1;
        }

        musicVolume -= 0.1f;

        index = Mathf.Clamp(index - 1, 0, 10);
        updateUI();
    }
    public void musicUp()
    {
        if (musicVolume <= 0)
        {
            musicVolume = 0;
        }
        if (musicVolume >= 1)
        {
            musicVolume = 1;
        }

        musicVolume += 0.1f;
        index = Mathf.Clamp(index + 1, 0, 10);
        updateUI();
    }

    private void updateUI()
    {

        spriteRend.sprite = sprites[index];
    }

}
