using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
 
[RequireComponent(typeof(Selectable))]
public class InteractiveItem : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
//     public bool isEntered = false;
//     public Selectable _selectable;
//     public float GazeActivationTime = 3f;
//  
//     BaseInputModule input;
//  
//     float timeElapsed;
//  
//  
//     void Start ()
//     {
//         input = FindObjectOfType<BaseInputModule>();
//         _selectable = GetComponent<Selectable>();
//     }
//  
//     void Update ()
//     {
//         if (!_selectable.IsInteractable())
//         {
//             ReticlePointer.Instance.SetFillAmount(0);
//             return;
//         }
//         if(isEntered)
//         {
//             timeElapsed += Time.deltaTime;
//  
//             ReticlePointer.Instance.SetFillAmount(Mathf.Clamp(timeElapsed/GazeActivationTime,0,1));
//  
//             if(timeElapsed >= GazeActivationTime)
//             {
//                 timeElapsed = 0;
//  
//                 ((GazeInputModule)input).HandleTriggerManually();
//  
//                 ReticlePointer.Instance.SetFillAmount(0);
//  
//                 isEntered = false;
//             }
//  
//             ReticlePointer.Instance.Show();
//  
//         }
//         else
//         {
//             timeElapsed = 0;
//         }
//     }
//  
//     void OnDisable()
//     {
//         isEntered = false;
//         if (ReticlePointer.Instance!= null)
//         {
//             ReticlePointer.Instance.SetFillAmount(0);
//         }
//     }
//  
// #region IPointerEnterHandler implementation
//  
//     public void OnPointerEnter (PointerEventData eventData)
//     {
//         if (_selectable.IsInteractable())
//         {
//             Invoke("SetEnteredTrue",0.3f); // start timer after 0.3 seconds of gaze. You can call SetEnteredTrue() directly.
//         }
//     }
//  
//     void SetEnteredTrue()
//     {
//         isEntered = true;
//     }
//  
// #endregion
//  
// #region IPointerExitHandler implementation
//  
//     public void OnPointerExit (PointerEventData eventData)
//     {
//         if (!_selectable.IsInteractable())
//             return;
//         try
//         {
//             CancelInvoke("SetEnteredTrue");
//             isEntered = false;
//             ReticlePointer.Instance.SetFillAmount(0);
//         }
//         catch (System.Exception ex)
//         {
//             Debug.LogError(ex.Message);
//         }
//     }
// #endregion
//  
// #region IPointerClickHandler implementation
//  
//     public void OnPointerClick (PointerEventData eventData)
//     {
//         isEntered = false;
//         timeElapsed = 0;
//         ReticlePointer.Instance.SetFillAmount(0);
//  
//     }
// #endregion
 
}