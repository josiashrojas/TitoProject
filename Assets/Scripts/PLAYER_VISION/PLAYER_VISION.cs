using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PLAYER_VISION : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    private UniversalAdditionalCameraData urpMainCamera;
    [SerializeField]
    private GameObject DarknessArea;
    private Material darknessAreaMaterial;
    [SerializeField, Range(0f, 10f)]
    private float initialDarknessArea = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        urpMainCamera = mainCamera.GetComponent<UniversalAdditionalCameraData>();
        darknessAreaMaterial = DarknessArea.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            urpMainCamera.SetRenderer(0);
            darknessAreaMaterial.SetFloat("_DarknessArea", initialDarknessArea);
        }
    }
}
