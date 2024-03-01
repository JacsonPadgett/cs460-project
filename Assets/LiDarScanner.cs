using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class LiDarScanner : MonoBehaviour
{
    private List<Vector3> _positionsList = new List<Vector3>();
    private List<VisualEffect> _vfxList = new List<VisualEffect>();
    private VisualEffect _currentVFX;
    private Texture2D _texture;
    private Color[] _positions;
    private bool _createNewVFX;
    private int _particleAmount;
    private LineRenderer _lineRenderer;
    private const string TEXTURE_NAME = "PositionsTexture";
    private const string RESOLUTION_PARAMETER_NAME = "Resolution";
    private bool _isFiring;
    private float _scanDelay = 0.2f;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private VisualEffect _vfxPrefab;
    [SerializeField] private GameObject _vfxContainer;
    [SerializeField] private Transform _castPoint;
    [SerializeField] private float _radius = 10f;
    [SerializeField] private float _maxRadius = 10f;
    [SerializeField] private float _minRadius = 1f;
    [SerializeField] private int _pointsPerScan = 40;
    [SerializeField] private float _range = 10f;
    [SerializeField] private int resolution = 100;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
        _createNewVFX = true;
        CreateNewVFX();
        ApplyPositions();
    }

    public void StartScanWithDelay()
    {
        _isFiring = true;
        StartCoroutine(ScanWithDelay());
    }

    public void EndScan()
    {
        _isFiring = false;
        StopAllCoroutines();
        _lineRenderer.enabled = false;
    }

    private IEnumerator ScanWithDelay()
    {
        while (_isFiring)
        {
            StartScan();
            yield return new WaitForSeconds(_scanDelay);
        }
    }

    private void StartScan()
    {
        for (int i = 0; i < _pointsPerScan; i++)
        {
            Vector3 randomPoint = GenerateRandomPointInCone();
            Vector3 dir = (randomPoint - transform.position).normalized;

            if (Physics.Raycast(transform.position, dir, out RaycastHit hit, _range, _layerMask))
            {
                if (_positionsList.Count < resolution * resolution)
                {
                    _positionsList.Add(hit.point);
                    _lineRenderer.enabled = true;
                    _lineRenderer.SetPositions(new[]
                    {
                        transform.position,
                        hit.point
                    });
                    _particleAmount++;
                }
                else
                {
                    _createNewVFX = true;
                    CreateNewVFX();
                    break;
                }
            }
        }
        ApplyPositions();
    }

    private Vector3 GenerateRandomPointInCone()
    {
        float theta = Random.Range(0f, Mathf.PI * 2f);
        float phi = Random.Range(0f, Mathf.PI / 4f);
        float x = Mathf.Sin(phi) * Mathf.Cos(theta);
        float y = Mathf.Sin(phi) * Mathf.Sin(theta);
        float z = Mathf.Cos(phi);
        Vector3 randomPoint = new Vector3(x, y, z);
        randomPoint *= _radius;
        randomPoint = transform.TransformDirection(randomPoint);
        randomPoint += _castPoint.position;
        return randomPoint;
    }

    private void CreateNewVFX()
    {
        if (!_createNewVFX) return;
        _vfxList.Add(_currentVFX);
        _currentVFX = Instantiate(_vfxPrefab, transform.position, Quaternion.identity, _vfxContainer.transform);
        _currentVFX.SetUInt(RESOLUTION_PARAMETER_NAME, (uint)resolution);
        _texture = new Texture2D(resolution, resolution, TextureFormat.RGBAFloat, false);
        _positions = new Color[resolution * resolution];
        _positionsList.Clear();
        _createNewVFX = false;
    }

    private void ApplyPositions()
    {
        Vector3[] pos = _positionsList.ToArray();
        Vector3 vfxPos = _currentVFX.transform.position;
        Vector3 transformPos = transform.position;
        int loopLength = _texture.width * _texture.height;
        int posListLen = pos.Length;

        for (int i = 0; i < loopLength; i++)
        {
            Color data;

            if (i < posListLen - 1)
            {
                data = new Color(pos[i].x - vfxPos.x, pos[i].y - vfxPos.y, pos[i].z - vfxPos.z, 1);
            }
            else
            {
                data = new Color(0, 0, 0, 0);
            }
            _positions[i] = data;
        }

        _texture.SetPixels(_positions);
        _texture.Apply();
        _currentVFX.SetTexture(TEXTURE_NAME, _texture);
        _currentVFX.Reinit();
    }
}
