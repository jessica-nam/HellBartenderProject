using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour
{
    [Header("Sprite to change")]
    public SpriteRenderer bodyPart;

    [Header("Sprites to cycle through")]
    public List<Sprite> options = new List<Sprite>();

    private int currOption = 0;

    public void NextOption()
    {
        currOption++;
        if(currOption >= options.Count)
        {
            currOption = 0; // Reset if cycled through entire list
        }

        bodyPart.sprite = options[currOption];
    }

    public void PrevOption()
    {
        currOption--;
        if (currOption <= 0)
        {
            currOption = options.Count - 1;
        }

        bodyPart.sprite = options[currOption];
    }
}
