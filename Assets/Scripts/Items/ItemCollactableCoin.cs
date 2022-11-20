using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;
public class ItemCollactableCoin : ItemCollactableBase
{
    public Collider2D collider;

    protected override void Oncollect()
    {
        base.Oncollect();
        ItemManager.Instance.AddByType(ItemType.COIN);
        collider.enabled = false;

    }

}
