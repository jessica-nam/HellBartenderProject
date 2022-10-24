using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemToolTip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ItemNameText;
    [SerializeField] TextMeshProUGUI ItemSlotText;

    private StringBuilder sb = new StringBuilder();

    public void ShowTooltip(EquippableItem item){
        ItemNameText.text = item.ItemName;
        ItemSlotText.text = item.EquipmentType.ToString();

        sb.Length = 0;


        gameObject.SetActive(true);
    }

    public void HideTooltip(){
        gameObject.SetActive(false);
    }

}
