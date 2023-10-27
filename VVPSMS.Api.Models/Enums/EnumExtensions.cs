﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VVPSMS.Api.Models.Enums
{
    public static class EnumExtensions
    {

        public static string DisplayName(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            EnumDisplayNameAttribute attribute
                = Attribute.GetCustomAttribute(field, typeof(EnumDisplayNameAttribute))
            as EnumDisplayNameAttribute;

            return attribute == null ? value.ToString() : attribute.DisplayName;
        }
    }
}
