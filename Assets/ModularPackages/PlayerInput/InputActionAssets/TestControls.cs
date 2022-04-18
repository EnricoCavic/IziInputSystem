// GENERATED AUTOMATICALLY FROM 'Assets/ModularPackages/PlayerInput/InputActionAssets/TestControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MainInputAsset : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainInputAsset()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TestControls"",
    ""maps"": [
        {
            ""name"": ""MainMap"",
            ""id"": ""ea01f048-ab50-409d-8c13-7a92f1637bfe"",
            ""actions"": [
                {
                    ""name"": ""MainInput"",
                    ""type"": ""Value"",
                    ""id"": ""09f8075c-b162-4050-86f4-45b5c59b6ffd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryInput"",
                    ""type"": ""Value"",
                    ""id"": ""e14c839b-dd37-47d4-b8b3-68685b1d20d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8302439f-1a8e-4706-9859-51263c177c15"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MainInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4aab9cf-cff3-452f-983a-916c64156dee"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MainMap
        m_MainMap = asset.FindActionMap("MainMap", throwIfNotFound: true);
        m_MainMap_MainInput = m_MainMap.FindAction("MainInput", throwIfNotFound: true);
        m_MainMap_SecondaryInput = m_MainMap.FindAction("SecondaryInput", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // MainMap
    private readonly InputActionMap m_MainMap;
    private IMainMapActions m_MainMapActionsCallbackInterface;
    private readonly InputAction m_MainMap_MainInput;
    private readonly InputAction m_MainMap_SecondaryInput;
    public struct MainMapActions
    {
        private @MainInputAsset m_Wrapper;
        public MainMapActions(@MainInputAsset wrapper) { m_Wrapper = wrapper; }
        public InputAction @MainInput => m_Wrapper.m_MainMap_MainInput;
        public InputAction @SecondaryInput => m_Wrapper.m_MainMap_SecondaryInput;
        public InputActionMap Get() { return m_Wrapper.m_MainMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMapActions set) { return set.Get(); }
        public void SetCallbacks(IMainMapActions instance)
        {
            if (m_Wrapper.m_MainMapActionsCallbackInterface != null)
            {
                @MainInput.started -= m_Wrapper.m_MainMapActionsCallbackInterface.OnMainInput;
                @MainInput.performed -= m_Wrapper.m_MainMapActionsCallbackInterface.OnMainInput;
                @MainInput.canceled -= m_Wrapper.m_MainMapActionsCallbackInterface.OnMainInput;
                @SecondaryInput.started -= m_Wrapper.m_MainMapActionsCallbackInterface.OnSecondaryInput;
                @SecondaryInput.performed -= m_Wrapper.m_MainMapActionsCallbackInterface.OnSecondaryInput;
                @SecondaryInput.canceled -= m_Wrapper.m_MainMapActionsCallbackInterface.OnSecondaryInput;
            }
            m_Wrapper.m_MainMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MainInput.started += instance.OnMainInput;
                @MainInput.performed += instance.OnMainInput;
                @MainInput.canceled += instance.OnMainInput;
                @SecondaryInput.started += instance.OnSecondaryInput;
                @SecondaryInput.performed += instance.OnSecondaryInput;
                @SecondaryInput.canceled += instance.OnSecondaryInput;
            }
        }
    }
    public MainMapActions @MainMap => new MainMapActions(this);
    public interface IMainMapActions
    {
        void OnMainInput(InputAction.CallbackContext context);
        void OnSecondaryInput(InputAction.CallbackContext context);
    }
}
