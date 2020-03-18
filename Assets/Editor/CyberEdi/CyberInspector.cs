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
using System.Reflection;
namespace  Cyberevolver.EditorUnity
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(UnityEngine.Object),true)]
    public class CyberInspector : Editor
    {
        private CyberEdit cyberEditor;
        private void OnEnable()
        {
            if (target == null)
                return;
            cyberEditor = new CyberEdit(serializedObject, target);
            cyberEditor.Active();
        }
        public override void OnInspectorGUI()
        {
            if (cyberEditor == null)
                return;
            if (target.GetType().GetMembers(BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance|BindingFlags.Static).Append(target.GetType()).Any(item=>item.GetCustomAttributes<CyberAttribute>().Any()))
            {
                EditorGUI.BeginChangeCheck();
                cyberEditor.DrawAll();
                if (EditorGUI.EndChangeCheck())
                {
                    cyberEditor.Save();
                }
            }
            else
                DrawDefaultInspector();

           
         
        }
    }
}
