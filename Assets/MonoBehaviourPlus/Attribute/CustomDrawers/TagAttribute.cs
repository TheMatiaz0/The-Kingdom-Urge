﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyberevolver;
using Cyberevolver.Unity;
using UnityEngine;
using System.Collections;
namespace Cyberevolver.Unity
{

    /// <summary>
    /// Drawes string as a unity tag field.
    /// </summary>
    [CyberAttributeUsage(LegalTypeFlags.None,typeof(string))]
    [AttributeUsage(AttributeTargets.Field)]
    public class TagAttribute : CyberAttribute
    {

    }
}
