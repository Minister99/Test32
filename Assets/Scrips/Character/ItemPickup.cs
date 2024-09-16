using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera; // Камера игрока для направления
    [SerializeField] private float _pickupRange = 3.0f; // Дальность взаимодействия
    [SerializeField] private float _carryDistance = 2.0f; // Расстояние до предмета при переносе
    [SerializeField] private LayerMask _pickupLayer; // Слой, к которому относятся поднимаемые предметы
    [SerializeField] private Vector3 _distanceItem;

    private GameObject _heldItem; // Текущий предмет, который держит игрок
    private Rigidbody _heldItemRb; // Rigidbody предмета для управления физикой

    private void Update()
    {
        if (_heldItem == null)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Проверка нажатия клавиши "E" для поднятия
            {
                TryPickupItem();
            }
        }
        else
        {
            CarryItem();
            if (Input.GetKeyDown(KeyCode.E)) // Проверка нажатия клавиши "E" для сброса предмета
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
                _heldItemRb.useGravity = false; // Отключаем гравитацию для поднятого предмета
                _heldItemRb.isKinematic = true; // Переводим объект в кинематический режим
            }
        }
    }

    private void CarryItem()
    {
        Vector3 targetPosition = _playerCamera.position + (_playerCamera.forward + _distanceItem) * _carryDistance;
        _heldItem.transform.position = targetPosition; // Перемещаем предмет перед игроком
    }

    private void DropItem()
    {
        _heldItemRb.useGravity = true; // Включаем гравитацию обратно
        _heldItemRb.isKinematic = false; // Отключаем кинематический режим
        _heldItem.isStatic = false;
        _heldItem = null;
        _heldItemRb = null;
    }
}
