using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerManager : MonoBehaviour
{
    public GameObject uiToolkitObject;      // drag the "UI Toolkit" GameObject here
    public List<GameObject> towerPrefabs;   // drag your tower prefabs in here

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
            panelRenderer.UnregisterUIReloadCallback(OnUIReload);
    }

    // Unity calls this whenever the UI is (re)loaded and gives you the root element
    void OnUIReload(PanelRenderer renderer, VisualElement root)
    {
        root.Query<Button>().ForEach(button =>
            button.RegisterCallback<ClickEvent>(OnShopButtonClicked));
    }

    void OnShopButtonClicked(ClickEvent evt)
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