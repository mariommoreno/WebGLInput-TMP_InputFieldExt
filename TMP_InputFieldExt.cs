using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;


namespace TMPro
{
    /// <summary>
    /// Editable text input field.
    /// </summary>
    [AddComponentMenu("UI/TextMeshPro - Input Field EXT", 11)]
    public class TMP_InputFieldExt : TMP_InputField
    {
		
        [Serializable]
        public class OnPositionChangedEvent : UnityEvent<int> { }


        /// <summary>
        /// Event delegates triggered when carret or string position changed on click.
        /// </summary>
        [SerializeField]
        private OnPositionChangedEvent m_OnPositionChanged = new OnPositionChangedEvent();


        public OnPositionChangedEvent onPositionChanged { get { return m_OnPositionChanged; } set { SetPropertyUtilityExt.SetClass(ref m_OnPositionChanged, value); } }


        protected void SendOnPositionChanged()
        {
            if (onPositionChanged != null)
                onPositionChanged.Invoke(stringPositionInternal);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            SendOnPositionChanged();
        }

        static class SetPropertyUtilityExt
        {
            public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
            {
                if ((currentValue == null && newValue == null) || (currentValue != null && currentValue.Equals(newValue)))
                    return false;

                currentValue = newValue;
                return true;
            }
        }
    }
}
