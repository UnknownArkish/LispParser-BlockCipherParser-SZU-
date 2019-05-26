using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL_HW_2.Framework
{
    public static class MVC
    {
        private static Dictionary<string, Model> m_Models = new Dictionary<string, Model>();

        public static T GetModel<T>() where T : Model
        {
            T result = null;
            foreach (Model model in m_Models.Values)
            {
                if (model is T)
                {
                    result = model as T;
                }
            }
            return result;
        }

        /// <summary>
        /// 向MVC中注册一个Model
        /// </summary>
        public static void RegisterModel(Model model)
        {
            model.Init();
            m_Models[model.Name] = model;
        }
    }
}
