using UnityEngine;
using UnityEngine.InputSystem;
public class Mouse : MonoBehaviour
{
    public Vector3 mouseWorldPosition;
    [SerializeField] private Camera mainCamera;
    public float radius = 0.2f;
    public LayerMask MoveButton;
    public Color gizmoColor = Color.red;
    Collider2D collision;
    GameObject buttons;
    public void SetMouse(InputAction.CallbackContext context)
    {
        Vector2 mousePos = context.ReadValue<Vector2>();
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePos);
        mouseWorldPosition.z = 0f;
        collision = Physics2D.OverlapCircle(mouseWorldPosition, radius, MoveButton);

    }
    public void SetTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(mouseWorldPosition, radius);
    }
}
