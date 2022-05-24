// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Controller/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Skills"",
            ""id"": ""94ba2253-ae6b-452d-87fc-99efabc96ea9"",
            ""actions"": [
                {
                    ""name"": ""Q Skill"",
                    ""type"": ""Button"",
                    ""id"": ""1065de9c-9eae-41b0-9853-d4fa4d1e1bfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""E Skill"",
                    ""type"": ""Button"",
                    ""id"": ""94aaf9da-5c0b-4ffe-8b5d-1131fdf638b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R Skill"",
                    ""type"": ""Button"",
                    ""id"": ""82f29826-9e5a-46f3-856d-ec744303d60e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d1ddf81e-e2ef-4657-834e-bd45bc4eadc5"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c562973-fcf0-4543-b337-0d9e52880d4e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""008e6f27-0b87-47d9-a407-06f1cf536633"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E Skill"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Skills
        m_Skills = asset.FindActionMap("Skills", throwIfNotFound: true);
        m_Skills_QSkill = m_Skills.FindAction("Q Skill", throwIfNotFound: true);
        m_Skills_ESkill = m_Skills.FindAction("E Skill", throwIfNotFound: true);
        m_Skills_RSkill = m_Skills.FindAction("R Skill", throwIfNotFound: true);
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

    // Skills
    private readonly InputActionMap m_Skills;
    private ISkillsActions m_SkillsActionsCallbackInterface;
    private readonly InputAction m_Skills_QSkill;
    private readonly InputAction m_Skills_ESkill;
    private readonly InputAction m_Skills_RSkill;
    public struct SkillsActions
    {
        private @PlayerController m_Wrapper;
        public SkillsActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @QSkill => m_Wrapper.m_Skills_QSkill;
        public InputAction @ESkill => m_Wrapper.m_Skills_ESkill;
        public InputAction @RSkill => m_Wrapper.m_Skills_RSkill;
        public InputActionMap Get() { return m_Wrapper.m_Skills; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SkillsActions set) { return set.Get(); }
        public void SetCallbacks(ISkillsActions instance)
        {
            if (m_Wrapper.m_SkillsActionsCallbackInterface != null)
            {
                @QSkill.started -= m_Wrapper.m_SkillsActionsCallbackInterface.OnQSkill;
                @QSkill.performed -= m_Wrapper.m_SkillsActionsCallbackInterface.OnQSkill;
                @QSkill.canceled -= m_Wrapper.m_SkillsActionsCallbackInterface.OnQSkill;
                @ESkill.started -= m_Wrapper.m_SkillsActionsCallbackInterface.OnESkill;
                @ESkill.performed -= m_Wrapper.m_SkillsActionsCallbackInterface.OnESkill;
                @ESkill.canceled -= m_Wrapper.m_SkillsActionsCallbackInterface.OnESkill;
                @RSkill.started -= m_Wrapper.m_SkillsActionsCallbackInterface.OnRSkill;
                @RSkill.performed -= m_Wrapper.m_SkillsActionsCallbackInterface.OnRSkill;
                @RSkill.canceled -= m_Wrapper.m_SkillsActionsCallbackInterface.OnRSkill;
            }
            m_Wrapper.m_SkillsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @QSkill.started += instance.OnQSkill;
                @QSkill.performed += instance.OnQSkill;
                @QSkill.canceled += instance.OnQSkill;
                @ESkill.started += instance.OnESkill;
                @ESkill.performed += instance.OnESkill;
                @ESkill.canceled += instance.OnESkill;
                @RSkill.started += instance.OnRSkill;
                @RSkill.performed += instance.OnRSkill;
                @RSkill.canceled += instance.OnRSkill;
            }
        }
    }
    public SkillsActions @Skills => new SkillsActions(this);
    public interface ISkillsActions
    {
        void OnQSkill(InputAction.CallbackContext context);
        void OnESkill(InputAction.CallbackContext context);
        void OnRSkill(InputAction.CallbackContext context);
    }
}
