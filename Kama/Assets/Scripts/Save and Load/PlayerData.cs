﻿using System;

[System.Serializable]
public class PlayerData 
{
    public float[] position;
    public float HP;
    public float MaxHP;
    public float SP;
    public float MaxSP;

    public float level;
    public float maxLevel;
    public float EXP;
    public float maxEXP;
    public float ATK;

    public int[] itemIds;
    public int potionsCount;

    public PlayerData(PlayerComponent player)
    {
        // Position
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        // Stats
        HP = player.HealthComponent.HP;
        MaxHP = player.HealthComponent.MaxHP;
        SP = player.SkillComponent.Sp;
        MaxSP = player.SkillComponent.MaxSp;

        // Level
        level = player.LevelComponent.CurrentLevel;
        maxLevel = player.LevelComponent.maxLevel;
        EXP = player.LevelComponent.CurrentEXP;
        maxEXP = player.LevelComponent.maxEXP;
        ATK = player.LevelComponent.CurrentATK;

        // Inventory
        int inventorySize = 0;
        potionsCount = 0;
        itemIds = new int[Inventory.instance.items.Count];

        foreach (Item item in Inventory.instance.items)
        {
            itemIds[inventorySize] = item.id;
            inventorySize++;

            if (item.name == "Health Potion")
                potionsCount++;
        }
    }
}