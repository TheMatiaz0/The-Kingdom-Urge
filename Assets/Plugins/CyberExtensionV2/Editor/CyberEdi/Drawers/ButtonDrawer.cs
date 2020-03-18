using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberevolver;
using Cyberevolver.Unity;
using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.Events;
using System.Reflection;

namespace Cyberevolver.EditorUnity
{
    [Drawer(typeof(ButtonAttribute))]
    public class ButtonDrawer : IMethodDrawer,IMetaDrawer
    {
        public void DrawAfter(CyberAttribute cyberAttributer)
        {
            if (CyberEdit.Current.CurrentInspectedMember is FieldInfo)
            {
                ButtonAttribute attribute = cyberAttributer as ButtonAttribute;
                var type = CyberEdit.Current.GetFinalTargetType();
                DrawMethod(type.GetMethod(attribute.Method, BindingFlags.Public | BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Static), attribute);
            }
            EditorGUILayout.EndHorizontal();
          
        }

        public void DrawBefore(CyberAttribute cyberAttributer)
        {
            EditorGUILayout.BeginHorizontal();
        }

        public void DrawMethod(MethodInfo method, CyberAttribute cyberAttrribute)
        {
           
            object locker = new object();
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            if (cyberAttrribute == null)
                throw new ArgumentNullException(nameof(method));

        
            ButtonAttribute button = cyberAttrribute as ButtonAttribute;

            TheEditor.PrepareToRefuseGui(locker);
            if (button.CustomColor)
                GUI.color = button.CurColor;      
            if ((Application.isPlaying == false && button.WhenCanPress == UnityEventCallState.RuntimeOnly)
                || (button.WhenCanPress == UnityEventCallState.Off))
            {

                GUI.enabled = false;
            }
          
            
            string text = button.Text;
            if (string.IsNullOrEmpty(text))
                text = method.Name;
            object[] finalArg = null;          
            ParameterInfo[] param = method.GetParameters();
            GUILayoutOption elementHeight = GUILayout.Height(20);
            if (param.Length>0)
            {
                finalArg = new object[param.Length];
                if (param.Length > 1)
                    GUILayout.BeginVertical("groupBox");
                else
                {
                    elementHeight = GUILayout.Height(button.Height);
                    if (button.InNextLine == false)
                        GUILayout.BeginHorizontal();
                }
                       
            }
        
            for(int x=0;x<param.Length;x++)
            {
                GUILayout.BeginHorizontal();
                string curretnArgCode = $"B_Arg1{x}";
                if (param.Length > 1)
                    EditorGUILayout.PrefixLabel(param[x].Name);

                object val = CyberEdit.Current.GetGlobalValue(method, curretnArgCode);
                (string str, UnityEngine.Object refer) = TheEditor.GeneralField(val?.ToString()??"NULL",val as UnityEngine.Object,param[x].ParameterType,
                    elementHeight);
                if (str is null)
                    str = String.Empty;
                val = SpecialConvert.Convert(param[x].ParameterType, refer, str);
                CyberEdit.Current.SetGlobalValue(method, curretnArgCode, val);
                finalArg[x] = val;
                GUILayout.EndHorizontal();
            }


            object result = null;
            List<GUILayoutOption> options = new List<GUILayoutOption>();
            options.Add(GUILayout.Height(button.Height));
            switch(button.CalcMode)
            {
                case CalcMode.UseContextSettings when CyberEdit.Current.CurrentInspectedMember is FieldInfo:             
                case CalcMode.Calc:
                    options.Add(GUILayout.Width(new GUIStyle("button").CalcSize(new GUIContent(text)).x));
                    break;
            } 
            if (GUILayout.Button(text,options.ToArray()))
            {
                if (method.IsStatic == false)
                    result= method.Invoke(CyberEdit.Current.Target, finalArg);
                else
                    result = method.Invoke(null,  finalArg);
            }
            if(result is null == false)
            {
                Debug.Log($"{text}: {result}", CyberEdit.Current.Target);
            }
            if (param.Length>0)
            {
                if (param.Length > 1)
                    GUILayout.EndVertical();
                else if(button.InNextLine==false)
                    GUILayout.EndHorizontal();
            }

            TheEditor.RefuseGui(locker);
           
        }

        
    }
}
