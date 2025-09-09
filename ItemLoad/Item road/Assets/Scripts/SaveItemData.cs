using System;
using UnityEngine;

public class SaveItemData
{
    public Guid instanceId;
    public ItemData itemId;
    public DateTime creationTime;

    public SaveItemData()
    {
        instanceId = Guid.NewGuid();
        creationTime = DateTime.Now;
    }
}
