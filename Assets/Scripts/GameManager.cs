using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<ItemManger> selectedGroup = new List<ItemManger>();

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
   
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Get the mouse position on the screen and send a raycast into the game world from that position.
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

           // If something was hit, the RaycastHit2D.collider will not be null.
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);

                ItemManger tapItem = hit.collider.GetComponent<ItemManger>();
                if (tapItem != null)
                {
                    selectedGroup.Clear();
                    tapItem.CheckNearItem(tapItem.currentItemId);

                    // selectedGroup.Add(tapItem);
                    if (selectedGroup.Count > 1)
                    {
                        foreach (var item in selectedGroup)
                        {
                            Destroy(item.gameObject);
                        }
                        selectedGroup.Clear();
                    }
                    else
                    {
                        selectedGroup[0].isGrouped = false;
                        selectedGroup[0].isChecked = false;
                        selectedGroup.Clear();
                    }
                }
            }
        }
    }
   
   
}
