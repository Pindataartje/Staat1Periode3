using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // Deze regel verklaart een openbare variabele met de naam Instance van het type InventoryManager.
    // 'static' betekent dat er slechts één Instance is die wordt gedeeld door alle instanties van InventoryManager.
    public static InventoryManager Instance;

    // Deze regel verklaart een openbare lijstvariabele met de naam Items van het type Item.
    // Lijsten zijn als containers die meerdere items van hetzelfde type kunnen bevatten.
    public List<Item> Items = new List<Item>();

    // Deze regel verklaart openbare variabelen om verwijzingen naar andere objecten in de Unity-scene te bevatten.
    // 'Transform' vertegenwoordigt de positie, rotatie en schaal van een GameObject.
    public Transform ItemContent;  // Bevat het ouderobject waar items worden weergegeven.
    public GameObject InventoryItem; // Vertegenwoordigt de sjabloon of prefab voor elk item.

    // Deze methode wordt aangeroepen wanneer het GameObject voor het eerst wordt geïnitialiseerd.
    private void Awake()
    {
        // Hier wijzen we de huidige instantie van InventoryManager toe aan de statische Instance-variabele.
        // Dit maakt het voor andere scripts gemakkelijk om deze instantie te benaderen.
        Instance = this;
    }

    // Deze methode voegt een item toe aan de Items-lijst.
    // Het neemt een 'item'-parameter van het type Item, dat het toe te voegen item vertegenwoordigt.
    public void Add(Item item)
    {
        // Voegt het gespecificeerde 'item' toe aan de Items-lijst.
        Items.Add(item);
    }

    // Deze methode verwijdert een item uit de Items-lijst.
    // Het neemt een 'item'-parameter van het type Item, dat het te verwijderen item vertegenwoordigt.
    public void Remove(Item item)
    {
        // Verwijdert het gespecificeerde 'item' uit de Items-lijst.
        Items.Remove(item);
    }

    // Deze methode geeft alle items in de Items-lijst weer.
    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        // Loop door elk item in de Items-lijst.
        foreach (var item in Items)
        {
            // Instantiateert een nieuw GameObject met behulp van de 'inventoryItem'-prefab.
            // 'Instantiate' maakt een nieuwe instantie van een prefab in de scène.
            GameObject obj = Instantiate(InventoryItem, ItemContent);

            // Verkrijgt referenties naar de Text- en Image-componenten binnen het geïnstantieerde GameObject.
            // 'Find' zoekt naar een child GameObject met een specifieke naam.
            var itemName = obj.transform.Find("Itemname").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            // Stelt de tekst en afbeelding van het geïnstantieerde GameObject in op basis van de eigenschappen van het item.
            itemName.text = item.itemName; // Stelt de itemnaam in.
            itemIcon.sprite = item.icon;   // Stelt het itemicoon in.
        }
    }
}
