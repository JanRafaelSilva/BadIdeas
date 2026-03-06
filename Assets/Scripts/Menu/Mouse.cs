using UnityEngine;
using UnityEngine.InputSystem;
public class Mouse : MonoBehaviour
{
    public Vector3 mouseWorldPosition;
    public Vector2 mousePos;
    [SerializeField] private Camera mainCamera;
    public LayerMask Button;
    public void Update()
    {
        
    }
    public void SetMouse(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
        mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePos);
        mouseWorldPosition.z = 0f;
    }
    public void SetTouch(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero, Button);
            var buttons = hit.collider.gameObject.GetComponent<Buttons>();
            buttons.OnClick(mousePos);
        }
    }
       
 }
    /*private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(mouseWorldPosition, radius);
    }*/

