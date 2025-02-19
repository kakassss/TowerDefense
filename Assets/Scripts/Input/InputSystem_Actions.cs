//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/Scripts/Input/InputSystem_Actions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputSystem_Actions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem_Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem_Actions"",
    ""maps"": [
        {
            ""name"": ""InputBuild"",
            ""id"": ""0a43264c-b547-4989-acfc-be5f42427fa4"",
            ""actions"": [
                {
                    ""name"": ""Building"",
                    ""type"": ""Button"",
                    ""id"": ""b2b65d69-c21e-4546-bb64-f0676f2528a0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4923a047-0b04-4327-83e2-e1ae43005165"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Building"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InputMovementKeyboard"",
            ""id"": ""e01c3a29-8815-4cff-b088-f027b5d109d8"",
            ""actions"": [
                {
                    ""name"": ""CameraMovementKeyboard"",
                    ""type"": ""Value"",
                    ""id"": ""7a83a328-ad25-455e-a6fb-18a3392c8c03"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""CameraMovementMouse"",
                    ""type"": ""Value"",
                    ""id"": ""89b32b69-14ab-40d7-a122-ccbb22656641"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""7a8ffa52-9564-4343-a0b5-4f2d982c523f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""959d66ce-09a3-4859-a61c-895a083221b9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ada9ee2e-d034-4fb3-baf7-f06111a7f101"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f26eb399-1323-4d40-8929-5cd6e699bc1a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""15ea84a5-d368-4b09-8aff-e19bf8662a85"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows"",
                    ""id"": ""1efd97d5-19e3-4681-9118-db63f30e18ac"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e27092bb-3177-4d78-acbe-479ee47d6e44"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""347109b7-5ace-48e6-8ed2-ba6e33908fe6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bc1b6795-3de2-4db7-88bc-9fb9bda1f1d5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b80bc8d6-77ef-4542-b32d-ecd3ad550a2e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementKeyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""9362c095-1c91-4ec1-a994-c1c79a41eb14"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a128c5ac-f6d7-47b4-ba9c-19b32d176179"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fdb997ad-b123-4bca-94f2-df6b0886f2f0"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""CameraMovementMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InputIdle"",
            ""id"": ""eb50b941-92a7-4bad-8fec-1f6d6a426ff1"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""f14ff38c-2958-497b-869e-3dca1bc9f6ac"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""69b74277-1ac5-4656-a31e-3b4f30251b29"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Touch"",
            ""bindingGroup"": ""Touch"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XR"",
            ""bindingGroup"": ""XR"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // InputBuild
        m_InputBuild = asset.FindActionMap("InputBuild", throwIfNotFound: true);
        m_InputBuild_Building = m_InputBuild.FindAction("Building", throwIfNotFound: true);
        // InputMovementKeyboard
        m_InputMovementKeyboard = asset.FindActionMap("InputMovementKeyboard", throwIfNotFound: true);
        m_InputMovementKeyboard_CameraMovementKeyboard = m_InputMovementKeyboard.FindAction("CameraMovementKeyboard", throwIfNotFound: true);
        m_InputMovementKeyboard_CameraMovementMouse = m_InputMovementKeyboard.FindAction("CameraMovementMouse", throwIfNotFound: true);
        // InputIdle
        m_InputIdle = asset.FindActionMap("InputIdle", throwIfNotFound: true);
        m_InputIdle_Select = m_InputIdle.FindAction("Select", throwIfNotFound: true);
    }

    ~@InputSystem_Actions()
    {
        UnityEngine.Debug.Assert(!m_InputBuild.enabled, "This will cause a leak and performance issues, InputSystem_Actions.InputBuild.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_InputMovementKeyboard.enabled, "This will cause a leak and performance issues, InputSystem_Actions.InputMovementKeyboard.Disable() has not been called.");
        UnityEngine.Debug.Assert(!m_InputIdle.enabled, "This will cause a leak and performance issues, InputSystem_Actions.InputIdle.Disable() has not been called.");
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // InputBuild
    private readonly InputActionMap m_InputBuild;
    private List<IInputBuildActions> m_InputBuildActionsCallbackInterfaces = new List<IInputBuildActions>();
    private readonly InputAction m_InputBuild_Building;
    public struct InputBuildActions
    {
        private @InputSystem_Actions m_Wrapper;
        public InputBuildActions(@InputSystem_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Building => m_Wrapper.m_InputBuild_Building;
        public InputActionMap Get() { return m_Wrapper.m_InputBuild; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputBuildActions set) { return set.Get(); }
        public void AddCallbacks(IInputBuildActions instance)
        {
            if (instance == null || m_Wrapper.m_InputBuildActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputBuildActionsCallbackInterfaces.Add(instance);
            @Building.started += instance.OnBuilding;
            @Building.performed += instance.OnBuilding;
            @Building.canceled += instance.OnBuilding;
        }

        private void UnregisterCallbacks(IInputBuildActions instance)
        {
            @Building.started -= instance.OnBuilding;
            @Building.performed -= instance.OnBuilding;
            @Building.canceled -= instance.OnBuilding;
        }

        public void RemoveCallbacks(IInputBuildActions instance)
        {
            if (m_Wrapper.m_InputBuildActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputBuildActions instance)
        {
            foreach (var item in m_Wrapper.m_InputBuildActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputBuildActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputBuildActions @InputBuild => new InputBuildActions(this);

    // InputMovementKeyboard
    private readonly InputActionMap m_InputMovementKeyboard;
    private List<IInputMovementKeyboardActions> m_InputMovementKeyboardActionsCallbackInterfaces = new List<IInputMovementKeyboardActions>();
    private readonly InputAction m_InputMovementKeyboard_CameraMovementKeyboard;
    private readonly InputAction m_InputMovementKeyboard_CameraMovementMouse;
    public struct InputMovementKeyboardActions
    {
        private @InputSystem_Actions m_Wrapper;
        public InputMovementKeyboardActions(@InputSystem_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @CameraMovementKeyboard => m_Wrapper.m_InputMovementKeyboard_CameraMovementKeyboard;
        public InputAction @CameraMovementMouse => m_Wrapper.m_InputMovementKeyboard_CameraMovementMouse;
        public InputActionMap Get() { return m_Wrapper.m_InputMovementKeyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputMovementKeyboardActions set) { return set.Get(); }
        public void AddCallbacks(IInputMovementKeyboardActions instance)
        {
            if (instance == null || m_Wrapper.m_InputMovementKeyboardActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputMovementKeyboardActionsCallbackInterfaces.Add(instance);
            @CameraMovementKeyboard.started += instance.OnCameraMovementKeyboard;
            @CameraMovementKeyboard.performed += instance.OnCameraMovementKeyboard;
            @CameraMovementKeyboard.canceled += instance.OnCameraMovementKeyboard;
            @CameraMovementMouse.started += instance.OnCameraMovementMouse;
            @CameraMovementMouse.performed += instance.OnCameraMovementMouse;
            @CameraMovementMouse.canceled += instance.OnCameraMovementMouse;
        }

        private void UnregisterCallbacks(IInputMovementKeyboardActions instance)
        {
            @CameraMovementKeyboard.started -= instance.OnCameraMovementKeyboard;
            @CameraMovementKeyboard.performed -= instance.OnCameraMovementKeyboard;
            @CameraMovementKeyboard.canceled -= instance.OnCameraMovementKeyboard;
            @CameraMovementMouse.started -= instance.OnCameraMovementMouse;
            @CameraMovementMouse.performed -= instance.OnCameraMovementMouse;
            @CameraMovementMouse.canceled -= instance.OnCameraMovementMouse;
        }

        public void RemoveCallbacks(IInputMovementKeyboardActions instance)
        {
            if (m_Wrapper.m_InputMovementKeyboardActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputMovementKeyboardActions instance)
        {
            foreach (var item in m_Wrapper.m_InputMovementKeyboardActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputMovementKeyboardActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputMovementKeyboardActions @InputMovementKeyboard => new InputMovementKeyboardActions(this);

    // InputIdle
    private readonly InputActionMap m_InputIdle;
    private List<IInputIdleActions> m_InputIdleActionsCallbackInterfaces = new List<IInputIdleActions>();
    private readonly InputAction m_InputIdle_Select;
    public struct InputIdleActions
    {
        private @InputSystem_Actions m_Wrapper;
        public InputIdleActions(@InputSystem_Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_InputIdle_Select;
        public InputActionMap Get() { return m_Wrapper.m_InputIdle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InputIdleActions set) { return set.Get(); }
        public void AddCallbacks(IInputIdleActions instance)
        {
            if (instance == null || m_Wrapper.m_InputIdleActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InputIdleActionsCallbackInterfaces.Add(instance);
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
        }

        private void UnregisterCallbacks(IInputIdleActions instance)
        {
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
        }

        public void RemoveCallbacks(IInputIdleActions instance)
        {
            if (m_Wrapper.m_InputIdleActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInputIdleActions instance)
        {
            foreach (var item in m_Wrapper.m_InputIdleActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InputIdleActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InputIdleActions @InputIdle => new InputIdleActions(this);
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_TouchSchemeIndex = -1;
    public InputControlScheme TouchScheme
    {
        get
        {
            if (m_TouchSchemeIndex == -1) m_TouchSchemeIndex = asset.FindControlSchemeIndex("Touch");
            return asset.controlSchemes[m_TouchSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    private int m_XRSchemeIndex = -1;
    public InputControlScheme XRScheme
    {
        get
        {
            if (m_XRSchemeIndex == -1) m_XRSchemeIndex = asset.FindControlSchemeIndex("XR");
            return asset.controlSchemes[m_XRSchemeIndex];
        }
    }
    public interface IInputBuildActions
    {
        void OnBuilding(InputAction.CallbackContext context);
    }
    public interface IInputMovementKeyboardActions
    {
        void OnCameraMovementKeyboard(InputAction.CallbackContext context);
        void OnCameraMovementMouse(InputAction.CallbackContext context);
    }
    public interface IInputIdleActions
    {
        void OnSelect(InputAction.CallbackContext context);
    }
}
