using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 0;
    Text starText;

    public int Stars { get => stars; set => stars = value; }

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDesplay();
    }

    void UpdateDesplay()
    {
        starText.text = Stars.ToString();
    }

    public void AddStars(int amount)
    {
        Stars += amount;
        UpdateDesplay();
    }

    public void SpendStars(int amount)
    {
        if(Stars>= amount)
        {
            Stars -= amount;
            UpdateDesplay();
        }
    }

    
}
