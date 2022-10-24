using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class EquipmentPanel : MonoBehaviour
{

    public static EquipmentPanel instance;

    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlots[] equipmentSlots;

    public event Action<Item> OnItemRightClickedEvent;


    [SerializeField] GameObject CompletedDrink;
    [SerializeField] GameObject CompletedDrink1;
    [SerializeField] GameObject CompletedDrink2;
    [SerializeField] GameObject ServingDrink;
    [SerializeField] GameObject ServingDrink1;
    [SerializeField] GameObject ServingDrink2;
    [SerializeField] GameObject BackInDialogueView;
    [SerializeField] GameObject BackInDialogueView1;
    [SerializeField] GameObject BackInDialogueView2;


    [SerializeField] GameObject Next;
    [SerializeField] GameObject Continue;

    public bool isCorrect = false;
    public bool isCorrect1 = false;
    public bool isCorrect2 = false;
    public bool isCorrect3 = false;
    public bool making = true;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }

    }



    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlots>();
    }



    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                previousItem = (EquippableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                //Debug.Log(equipmentSlots[i].Item.name);
                Debug.Log(DialogueManager.instance.characterName);
                return true;
            }
        }
        previousItem = null;
        return false;
    }



    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                return true;
            }
        }
        return false;
    }

    public void CraftPumpkin()
    {



        if (equipmentSlots[0].Item.name == "Toxins")
        {
            Debug.Log("Toxins added");
            isCorrect1 = true;

        }
        if (equipmentSlots[1].Item.name == "Pumpkin")
        {
            Debug.Log("Pumpkin added");
            isCorrect2 = true;
        }

        if (equipmentSlots[2].Item.name == "Ghosts")
        {
            Debug.Log("Ghosts added");
            isCorrect3 = true;
        }

    }

    public void CraftSunrise()
    {
        if (equipmentSlots[0].Item.name == "Blood")
        {
            Debug.Log("Blood added");
            isCorrect1 = true;

        }
        if (equipmentSlots[1].Item.name == "Eyecandy")
        {
            Debug.Log("Eyecandy added");
            isCorrect2 = true;
        }

        if (equipmentSlots[2].Item.name == "Poison")
        {
            Debug.Log("Poison added");
            isCorrect3 = true;
        }
    }

    public void CraftButton()
    {
        Debug.Log("Craft button clicked");
        if (DialogueManager.instance.characterName == "Dahlia")
        {
            CraftPumpkin();
            if (isCorrect1 && isCorrect2 && isCorrect3)
            {
                isCorrect = true;
                Debug.Log("Drink made");
                CompletedDrink.SetActive(true);
                making = false;
            }
            else
            {
                CompletedDrink.SetActive(false);
                isCorrect = false;
            }
        }

        if (DialogueManager.instance.characterName == "Salem")
        {
            CraftSunrise();
            if (isCorrect1 && isCorrect2 && isCorrect3)
            {
                isCorrect = true;
                Debug.Log("Drink made");
                CompletedDrink1.SetActive(true);
                making = false;
            }
            else
            {
                CompletedDrink1.SetActive(false);
                isCorrect = false;
            }
        }

    }

    public void ServeButton()
    {
        Debug.Log("Served button called");
        

        
        // Next.SetActive(false);
        // Continue.SetActive(true);

        if (DialogueManager.instance.characterName == "Dahlia")
        {
            ServingDrink.SetActive(false);
            BackInDialogueView.SetActive(true);
        }
  
        if (DialogueManager.instance.characterName == "Salem")
        {
            ServingDrink1.SetActive(false);
            BackInDialogueView1.SetActive(true);
        }
        if (DialogueManager.instance.characterName == "Edmund")
        {
            ServingDrink2.SetActive(false);
            BackInDialogueView2.SetActive(true);
        }


    }


}
