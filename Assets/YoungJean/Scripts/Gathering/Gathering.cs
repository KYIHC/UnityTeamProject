using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    public GameObject interaction;

    private void Awake()
    {
        interaction.SetActive(false);
    }

    private void Update()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, 1f);
        foreach (var coll in colls)
        {


            if (coll.CompareTag("Stone") &&
                Inventory.instance.items.Count < Inventory.instance.SlotCount)
            {
                {
                    interaction.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Inventory.instance.Additem(ItemDatabase.instance.itemsDB[3]);
                        Destroy(coll.gameObject);
                    }
                }
            }
            else if (coll.CompareTag("Wood"))
            {
                if (Inventory.instance.items.Count < Inventory.instance.SlotCount)
                {
                    interaction.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        Inventory.instance.Additem(ItemDatabase.instance.itemsDB[4]);
                        Destroy(coll.gameObject);
                    }
                }

            }



        }

        StartCoroutine(IconDown());

    }

    IEnumerator IconDown()
    {
        if (interaction.activeSelf)
        {
            yield return new WaitForSeconds(1f);
            interaction.SetActive(false);
        }
    }

}
