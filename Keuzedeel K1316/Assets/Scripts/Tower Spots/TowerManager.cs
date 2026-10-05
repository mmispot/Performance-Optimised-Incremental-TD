using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerManager : MonoBehaviour
{
    public GameObject uiToolkitObject;
    public List<GameObject> towerPrefabs;

    GameObject selectedTower;
    PanelRenderer panelRenderer;

    void OnEnable()
    {
        panelRenderer = uiToolkitObject.GetComponent<PanelRenderer>();
        panelRenderer.RegisterUIReloadCallback(OnUIReload);
    }

    void OnDisable()
    {
        if (panelRenderer != null) 
        {
            panelRenderer.UnregisterUIReloadCallback(OnUIReload);
        }
    }

    void OnUIReload(PanelRenderer renderer, VisualElement root)
    {
        root.Query<Button>().ForEach(button => button.RegisterCallback<ClickEvent>(OnShopButtonClicked));
    }

    void OnShopButtonClicked(ClickEvent evt)  //Admittedly did use AI for the next 2 functions so I didnt have to write a lot of code, but I did have to edit it to make it work with the code I'd alr written
    {
        var button = (Button)evt.currentTarget;
        selectedTower = towerPrefabs.Find(p => p.name == button.name);
        Debug.Log("Selected: " + (selectedTower != null ? selectedTower.name : "nothing"));
    }

    public void OnSpotClicked(GameObject spot)
    {
        if (selectedTower == null) return;

        Instantiate(selectedTower, spot.transform.position, Quaternion.identity);
        selectedTower = null;
    }
}