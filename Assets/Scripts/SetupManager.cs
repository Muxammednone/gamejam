using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class SetupManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject[] _visuals;
    [SerializeField] private Tower[] _towers;
    public LayerMask layerMask;
    public int setuppingIndex;

    //Materials
    [SerializeField] private Material _whiteMaterial;
    [SerializeField] private Material _blackMaterial;

    // detecting values
    private bool _canSetup;
    private GameObject visual = null;
    private void Setup(Vector3 point, int setup_index)
    {
        Instantiate(_towers[setuppingIndex], new Vector3(point.x, -0.05f, point.z), Quaternion.identity);
        Destroy(visual);
        _gameManager.isSetupping = false;
    }
    private void makeVisual(Vector3 point)
    {
        if (visual == null)
        {
            visual = Instantiate(_visuals[setuppingIndex], new Vector3(point.x, -0.05f, point.z), Quaternion.identity);
        }
        
    }
    private void paintVisual(bool flag)
    {
        if (visual == null) return;
        if (flag) {
            MeshRenderer[] renderers = visual.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer render in renderers)
            {
                render.material = _whiteMaterial;
            }
        }
        else
        {
            MeshRenderer[] renderers = visual.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer render in renderers)
            {
                render.material = _blackMaterial;
            }
        }
        
    }
    private bool CheckForSetup(GameObject visual)
    {
        
        Collider[] coliders = Physics.OverlapBox(visual.transform.position, new Vector3(0.95f, 1, 0.95f), Quaternion.identity, layerMask);
        foreach (Collider col in coliders) 
        {
            if (!col.gameObject.GetComponent<DetectEnemy>())
            {
                if (col.gameObject.transform.parent.gameObject.tag != "setup_tile") return false;
            }
            
        }
        return true;
    }
    

    
    private void Update()
    {
        if (_gameManager.isSetupping)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int groundLayer = LayerMask.GetMask("Ground");
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                makeVisual(hit.point);
                _canSetup = CheckForSetup(visual);
                paintVisual(_canSetup);
                visual.transform.position = new Vector3(hit.point.x, -0.05f, hit.point.z);

            }
            else
            {
                _canSetup = false;
            }

            if (_canSetup && Input.GetMouseButton(0))
            {
                Setup(hit.point, setuppingIndex);
            }
        }
    }
}
