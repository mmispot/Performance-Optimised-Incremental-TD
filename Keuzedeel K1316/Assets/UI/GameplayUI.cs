using UnityEngine;
using UnityEngine.UIElements;

public class GameplayUI : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    private Button spawnButton;
    private PanelRenderer panelRenderer;
    private ScrollView scrollView;
    public int buttonCount;

    private void Start()
    {
        // Zorg ervoor dat de EnemySpawner is ingesteld in de Inspector.
        if (enemySpawner == null)
        {
            Debug.LogError("EnemySpawner is not assigned in the Inspector!");
        }
    }

    private void OnEnable()
    {
        panelRenderer = GetComponent<PanelRenderer>();

        // Registreer een callback die wordt uitgevoerd wanneer de UI
        // is geladen of opnieuw wordt geladen.
        panelRenderer.RegisterUIReloadCallback(OnUIReload);
    }

    private void OnDisable()
    {
        // Stop met luisteren naar het laden of opnieuw laden van de UI.
        panelRenderer.UnregisterUIReloadCallback(OnUIReload);
    }

    // Deze methode wordt aangeroepen wanneer de UI door de PanelRenderer is geladen.
    private void OnUIReload(PanelRenderer panelRenderer, VisualElement rootElement, int version)
    {
        scrollView = rootElement.Q<ScrollView>("Content");
        scrollView.verticalScrollerVisibility = ScrollerVisibility.AlwaysVisible;

        spawnButton = rootElement.Q<Button>("SpawnBtn");
        spawnButton.clicked += OnSpawnButtonClicked;
    }

    public void CountButtons()
    {
        if (scrollView == null) return;
        buttonCount = scrollView.childCount;
        Debug.Log("Button count: " + buttonCount);
    }

    public void Update()
    {
        if (scrollView == null) return;

        CountButtons();
        if (buttonCount > 12)
        {
            scrollView.AddToClassList("wider");
            Debug.Log("Added wider class to scrollView");
        }
        else
        {
            scrollView.RemoveFromClassList("wider");
            Debug.Log("Removed wider class from scrollView");
        }
    }

    public void OnSpawnButtonClicked()
    {
        enemySpawner.SpawnWave(10, 0.5f);
    }
}