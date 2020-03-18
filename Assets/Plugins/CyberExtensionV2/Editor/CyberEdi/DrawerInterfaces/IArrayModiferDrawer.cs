using Cyberevolver.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Cyberevolver.EditorUnity
{

    public interface IArrayModiferDrawer:ICyberDrawer
    {
        void DrawAfterSize(SerializedProperty prop, CyberAttribute cyberAttrribute);
        void DrawBeforeSize(SerializedProperty prop, CyberAttribute cyberAttrribute);
        void DrawAfterAll(SerializedProperty prop, CyberAttribute cyberAttrribute);
    }
}
