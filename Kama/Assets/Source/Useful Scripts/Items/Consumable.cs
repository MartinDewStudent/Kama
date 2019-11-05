using UnityEngine;

/* An Item that can be consumed. So far that just means regaining health */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Consumable")]
public class Consumable : Item {

    public int healthGain;
    GameObject player;
    bool instanciated = false;

    // This is called when pressed in the inventory
    public override void Use()
	{
        if (!instanciated)
        {
            player = GameObject.FindGameObjectWithTag("Main Character");
            instanciated = true;
        }

        // Heal the player
        player.GetComponent<StandartHealthComponent>().Increase(healthGain);

		Debug.Log(name + " consumed!");

        // Remove the item after use
        RemoveFromInventory();	
	}
}
