using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipControll : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Tooltip tooltip;
    public void OnPointerEnter(PointerEventData eventData)
    {
        Item item = GetComponent<Slot>().item;
        if (item != null)
        {
            tooltip.gameObject.SetActive(true);
            tooltip.SetupTooltip(item.itemName, item.description, item.itemCost, item.atk, item.def);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);

    }
}
