using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHWForm.Models
{
    public static class ModelFactory
    {
        public static IModel GetModel<T>()  where T : IModel, new()
        {
            return new T();
        }
    }
}