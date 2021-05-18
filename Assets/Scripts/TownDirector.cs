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
    public static Canvas selectedEntityUI;

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
            // TODO: Un clique sur un bouton du UI de l'entité est considéré comme un clique à l'extérieur de l'entité, le désélectionnant.
            // Trouver un moyen d'empêcher ce comportement.
            // Le Unselect() sera désactivé en attendant.
            // Unselect();
        }
    }

    public static void Select(Entity entity)
    {
        Unselect();

        selectedEntity = entity;

        if(entity.ui)
        {
            selectedEntityUI = Instantiate(entity.ui);
        }
    }

    public static void Unselect()
    {
        if (selectedEntity != null)
        {
            selectedEntity.Unselect();
            selectedEntity = null;
        }

        if(selectedEntityUI != null)
        {
            Destroy(selectedEntityUI.gameObject);
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
