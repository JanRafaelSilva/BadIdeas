using UnityEngine;
using UnityEngine.InputSystem;
public class Mouse : MonoBehaviour
{
    public Vector3 mouseWorldPosition;
    public Vector2 mousePos;
    [SerializeField] private Camera mainCamera;
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
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(mousePos), Vector2.zero, LayerMask.NameToLayer("MoveButton"));
            if(hit.collider != null){
                var buttons = hit.collider.gameObject.GetComponent<Buttons>();
                buttons.OnClick();
            }
        }
    }
       
 }