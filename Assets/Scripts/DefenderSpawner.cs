using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreatedDefenderParent();
    }

    private void CreatedDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttempToPlaceDefenderAt();
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        worldPos = SnapToGrid(worldPos);
        
        return worldPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender()
    {
        Defender newDefender = Instantiate(defender, GetSquareClicked(), Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;

    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttempToPlaceDefenderAt()
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.StarCost;
        if (starDisplay.Stars >= defenderCost)
        {
            starDisplay.SpendStars(defenderCost);
            SpawnDefender();
            
        }
        
    }
}
