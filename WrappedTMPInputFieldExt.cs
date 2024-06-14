#if UNITY_2018_2_OR_NEWER
#define TMP_WEBGL_SUPPORT
#endif

#if TMP_WEBGL_SUPPORT
using UnityEngine;
using TMPro;
using WebGLSupport.Detail;
using UnityEngine.UI;
using System;
using System.Transactions;

namespace WebGLSupport
{
    /// <summary>
    /// Wrapper for TMPro.TMP_InputField
    /// </summary>
    class WrappedTMPInputFieldExt : WrappedTMPInputField
    {
        TMP_InputFieldExt input;

        public WrappedTMPInputFieldExt(TMP_InputFieldExt input): base(input) 
        {
            this.input = input;
        }

        private TMP_InputFieldExt.OnPositionChangedEvent _onPositionChanged;

        public TMP_InputFieldExt.OnPositionChangedEvent OnPositionChanged
        {
            get => input.onPositionChanged;
        }
       
    }
}

#endif // TMP_WEBGL_SUPPORT
