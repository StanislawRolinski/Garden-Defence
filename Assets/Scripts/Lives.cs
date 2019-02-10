using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    [SerializeField] float baseLives = 3f;
    [SerializeField] int damage = 1;
    float myLives;
    Text livesText;

    public float MyLives { get => myLives; set => myLives = value; }

    void Start()
    {
        myLives = baseLives - PlayerPrefsController.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDesplay();
    }

    private void UpdateDesplay()
    {
        livesText.text = "My Lives: " + MyLives.ToString();
    }
    public void TakeLife()
    {
        {
            myLives -= 1;
            UpdateDesplay();

            if(myLives <= 0)
            {
                FindObjectOfType<LevelController>().HandleLoseCondition();
            }
        }
    }
}
