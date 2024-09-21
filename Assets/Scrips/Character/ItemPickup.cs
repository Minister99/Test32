using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera; // ������ ������ ��� �����������
    [SerializeField] private float _pickupRange = 3.0f; // ��������� ��������������
    [SerializeField] private float _carryDistance = 2.0f; // ���������� �� �������� ��� ��������
    [SerializeField] private LayerMask _pickupLayer; // ����, � �������� ��������� ����������� ��������
    [SerializeField] private Vector3 _distanceItem;

    private GameObject _heldItem; // ������� �������, ������� ������ �����
    private Rigidbody _heldItemRb; // Rigidbody �������� ��� ���������� �������

    private void Update()
    {
        if (_heldItem == null)
        {
            if (Input.GetKeyDown(KeyCode.E)) // �������� ������� ������� "E" ��� ��������
            {
                TryPickupItem();
            }
        }
        else
        {
            CarryItem();
            if (Input.GetKeyDown(KeyCode.E)) // �������� ������� ������� "E" ��� ������ ��������
            {
                DropItem();
            }
        }
    }

    private void TryPickupItem()
    {
        Ray ray = new Ray(_playerCamera.position, _playerCamera.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _pickupRange, _pickupLayer))
        {
            if (hitInfo.collider.gameObject.TryGetComponent<Rigidbody>(out _heldItemRb))
            {
                _heldItem = hitInfo.collider.gameObject;
                _heldItemRb.useGravity = false; // ��������� ���������� ��� ��������� ��������
                _heldItemRb.isKinematic = true; // ��������� ������ � �������������� �����
            }
        }
    }

    private void CarryItem()
    {
        Vector3 targetPosition = _playerCamera.position + (_playerCamera.forward + _distanceItem) * _carryDistance;
        _heldItem.transform.position = targetPosition; // ���������� ������� ����� �������
    }

    private void DropItem()
    {
        _heldItemRb.useGravity = true; // �������� ���������� �������
        _heldItemRb.isKinematic = false; // ��������� �������������� �����
        _heldItem.isStatic = false;
        _heldItem = null;
        _heldItemRb = null;
    }
}
