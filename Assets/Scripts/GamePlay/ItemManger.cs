using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ItemManger: MonoBehaviour
{
    [SerializeField] private GameObject _balstEffect;

    public ElementType elementType = ElementType.ITEM;
    public ItemType currentItemId = ItemType.BLUE;
    public BombType bombType = BombType.BIRD_RED;
    public Sprite Icon;
    private bool isChecked = false;
    public bool isGrouped = false;
    public List<Collider2D> _nearColliders;
    
    public ElementType etype
    {
        get
        {
            return elementType;
        }
        set
        {
            elementType = value;
        }
    }

    public void CheckNearItem()
    {
        if (isChecked)
            return;
        isChecked = true;

        Debug.Log("Checcker");

        if(!isGrouped)
        {
            isGrouped = true;
            GameManager.Instance.selectedGroup.Add(this.gameObject.GetComponent<ItemManger>());
        }

        _nearColliders = Physics2D.OverlapCircleAll(transform.position, 0.7f).Where(x => x.GetComponent<ItemManger>() != null 
        && x.GetComponent<ItemManger>().etype == ElementType.ITEM
        && !x.GetComponent<ItemManger>().isChecked).ToList();

        for (int i = 0; i < _nearColliders.Count; i++)
            _nearColliders[i].GetComponent<ItemManger>().CheckNearItem();
    }
}
