using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefendersButton>();
        foreach (DefendersButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
