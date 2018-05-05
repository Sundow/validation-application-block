﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseLibrary.Validation
{
    public static partial class ValidationReflectionHelper
    {
        /// <summary>
        /// Retrieves an array of the custom attributes applied to a member of a type, looking for the existence
        /// of a metadata type where the attributes are actually specified.
        /// Parameters specify the member, the type of the custom attribute to search
        /// for, and whether to search ancestors of the member.
        /// </summary>
        /// <param name="element">An object derived from the <see cref="MemberInfo"/> class that describes a 
        /// constructor, event, field, method, or property member of a class.</param>
        /// <param name="attributeType">The type, or a base type, of the custom attribute to search for.</param>
        /// <param name="inherit">If <see langword="true"/>, specifies to also search the ancestors of element for 
        /// custom attributes.</param>
        /// <returns>An <see cref="Attribute"/> array that contains the custom attributes of type type applied to 
        /// element, or an empty array if no such custom attributes exist.</returns>
        /// <seealso cref="ModelMetadataTypeAttribute"/>
        public static Attribute[] GetCustomAttributes(MemberInfo element, Type attributeType, bool inherit)
        {
            MemberInfo matchingElement = GetMatchingElement(element);

            return Attribute.GetCustomAttributes(matchingElement, attributeType, inherit);
        }

        private static MemberInfo GetMatchingElement(MemberInfo element)
        {
            Type sourceType = element as Type;
            bool elementIsType = sourceType != null;
            if (sourceType == null)
            {
                sourceType = element.DeclaringType;
            }

            ModelMetadataTypeAttribute metadataTypeAttribute = (ModelMetadataTypeAttribute)
                Attribute.GetCustomAttribute(sourceType, typeof(ModelMetadataTypeAttribute), false);

            if (metadataTypeAttribute == null)
            {
                return element;
            }

            sourceType = metadataTypeAttribute.MetadataType;

            if (elementIsType)
            {
                return sourceType;
            }

            MemberInfo[] matchingMembers =
                sourceType.GetMember(
                    element.Name,
                    element.MemberType,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            if (matchingMembers.Length > 0)
            {
                MethodBase methodBase = element as MethodBase;
                if (methodBase == null)
                {
                    return matchingMembers[0];
                }

                Type[] parameterTypes = methodBase.GetParameters().Select(pi => pi.ParameterType).ToArray();
                return matchingMembers.Cast<MethodBase>().FirstOrDefault(mb => MatchMethodBase(mb, parameterTypes)) ?? element;
            }

            return element;
        }
    }
}
