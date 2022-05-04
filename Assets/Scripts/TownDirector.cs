using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TownDirector : MonoBehaviour
{
    private static TownDirector instance = null;

    public static TownDirector Instance 
    { 
        get 
        { 
            return instance; 
        } 
    }

    public static Entity selectedEntity;
    public Canvas entityUI;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(HasClickedOutsideSelectableEntity())
        {
            Unselect();
        }
    }

    public static void Select(Entity entity)
    {
        Unselect();

        selectedEntity = entity;

    }

    public static void Unselect()
    {
        if (selectedEntity != null)
        {
            selectedEntity.Unselect();
            selectedEntity = null;
        }
    }

    private bool HasClickedOutsideSelectableEntity()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Entity entity = hit.transform.gameObject.GetComponent<Entity>();

                if (!entity)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
