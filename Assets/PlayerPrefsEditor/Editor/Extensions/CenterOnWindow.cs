using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using Object = UnityEngine.Object;

namespace BgTools.Extensions
{

    public static class Extensions
    {
        private static Type[] GetAllDerivedTypes(this AppDomain aAppDomain, Type aType)
        {
            List<Type> result = new List<Type>();
            Assembly[] assemblies = aAppDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.IsSubclassOf(aType))
                        result.Add(type);
                }
            }
            return result.ToArray();
        }

        public static Rect GetEditorMainWindowPos(EditorWindow relatedWin = null)
        {
            Type containerWinType = AppDomain.CurrentDomain.GetAllDerivedTypes(typeof(ScriptableObject)).Where(t => t.Name == "ContainerWindow").FirstOrDefault();

            if (containerWinType == null)
                throw new MissingMemberException("Can't find internal type ContainerWindow. Maybe something has changed inside Unity");

            FieldInfo showModeField = containerWinType.GetField("m_ShowMode", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            PropertyInfo positionProperty = containerWinType.GetProperty("position", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            if (showModeField == null || positionProperty == null)
                throw new MissingFieldException("Can't find internal fields 'm_ShowMode' or 'position'. Maybe something has changed inside Unity");

            Object[] windows = Resources.FindObjectsOfTypeAll(containerWinType);
            foreach (Object win in windows)
            {
                int showmode = (int)showModeField.GetValue(win);

                // Given window
                //if (relatedWin != null && relatedWin.GetInstanceID() == win.GetInstanceID())
                //{
                //    var pos = (Rect)positionProperty.GetValue(win, null);
                //    return pos;
                //}

                // Main window
                if (showmode == 4)
                {
                    Rect pos = (Rect)positionProperty.GetValue(win, null);
                    return pos;
                }
            }
            throw new NotSupportedException("Can't find internal main window. Maybe something has changed inside Unity");
        }

        /// <summary>
        /// Center the EditorWindow in front of the MainUnityWindow (support multi screens).
        /// Kept the currend window sizes.
        /// </summary>
        public static void CenterOnMainWindow(this EditorWindow window)
        {
            CenterOnWindow(window, null);
        }

        /// <summary>
        /// Center the EditorWindow in front of the given EditorWindow (support multi screens).
        /// Kept the currend window sizes.
        /// </summary>
        /// <param name="relatedWin">Referance window for the positioning.</param>
        public static void CenterOnWindow(this EditorWindow window, EditorWindow relatedWin)
        {
            Rect main = GetEditorMainWindowPos(relatedWin);

            Rect pos = window.position;
            float w = (main.width - pos.width) * 0.5f;
            float h = (main.height - pos.height) * 0.5f;
            pos.x = main.x + w;
            pos.y = main.y + h;
            window.position = pos;
        }
    }
}