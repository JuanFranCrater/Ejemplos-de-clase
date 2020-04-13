using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : EventManager
{
    public static GameManager instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    
    [Header("Audio")]
    public AudioClip getGem;
    public AudioClip getKey;
    public AudioSource _audio;
    [Header ("Green")]
    public GameObject greenKey;
    public GameObject greenGem;
    public bool hasGreenKey = false;
    public bool hasGreenGem = false;
    public Sprite greenKeySprite;
    public Sprite greenGemSprite;

    [Header("Orange")]
    public GameObject orangeKey;
    public GameObject orangeGem;
    public bool hasOrangeKey = false;
    public bool hasOrangeGem = false;
    public Sprite orangeKeySprite;
    public Sprite orangeGemSprite;
    public Platform platformOrange;

    [Header("Blue")]
    public GameObject blueKey;
    public GameObject blueGem;
    public bool hasBlueKey = false;
    public bool hasBlueGem = false;
    public Sprite blueKeySprite;
    public Sprite blueGemSprite;
    public Platform platformBlue;

    [Header("Doors")]
    public GameObject[] doors;

    public void takeGreenKey()
    {
        hasGreenKey = true;
        checkKeys();
    }

    public void takeOrangeKey()
    {
        hasOrangeKey = true;
        activateOrangeElevator();
        checkKeys();
    }

    private void activateOrangeElevator()
    {
        platformOrange.activated = true;
    }

    public void takeBlueKey()
    {
        hasBlueKey = true;
        activateBlueElevator();
        checkKeys();
    }

    private void checkKeys()
    {
        if (hasGreenKey && hasBlueKey && hasOrangeKey)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].SetActive(false);
            }
        }
    }

    private void activateBlueElevator()
    {
        platformBlue.activated = true;
    }

    public void takeGem(string name)
    {
        _audio.PlayOneShot(getGem);
        switch (name)
        {
            case "blue":
                takeBlueGem();
                break;
            case "green":
                takeGreenGem();
                break;
            case "orange":
                takeOrangeGem();
                break;
        }
    }

    public bool takeKey(string name)
    {
        
        switch (name)
        {
            case "blue":
                if (hasBlueGem)
                {
                    takeBlueKey();
                    _audio.PlayOneShot(getKey);
                }
                return hasBlueGem;
            case "green":
                if (hasGreenGem)
                {
                    takeGreenKey();
                    _audio.PlayOneShot(getKey);
                }
                return hasGreenGem;
            case "orange":
                if (hasOrangeGem)
                {
                    takeOrangeKey();
                    _audio.PlayOneShot(getKey);
                }
                return hasOrangeGem;
        }
        return false;
    }


    public void takeGreenGem()
    {
        hasGreenGem = true;
        greenGem.GetComponent<SpriteRenderer>().sprite = greenGemSprite;
        greenKey.GetComponent<SpriteRenderer>().sprite = greenKeySprite;
    }

    public void takeOrangeGem()
    {
        hasOrangeGem = true;
        orangeGem.GetComponent<SpriteRenderer>().sprite = orangeGemSprite;
        orangeKey.GetComponent<SpriteRenderer>().sprite = orangeKeySprite;
    }

    public void takeBlueGem()
    {
        hasBlueGem = true;
        blueGem.GetComponent<SpriteRenderer>().sprite = blueGemSprite;
        blueKey.GetComponent<SpriteRenderer>().sprite = blueKeySprite;
    }
}
