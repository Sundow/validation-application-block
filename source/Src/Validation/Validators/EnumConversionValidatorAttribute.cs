﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System;

namespace EnterpriseLibrary.Validation.Validators
{
    /// <summary>
    /// Represents a <see cref="EnumConversionValidator"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property
        | AttributeTargets.Field
        | AttributeTargets.Method
        | AttributeTargets.Parameter,
        AllowMultiple = true,
        Inherited = false)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1019",
        Justification = "Fields are used internally")]
    public sealed class EnumConversionValidatorAttribute : ValueValidatorAttribute
    {
        private Type enumType;

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="EnumConversionValidatorAttribute"/> </para>
        /// </summary>
        public EnumConversionValidatorAttribute(Type enumType)
        {
            ValidatorArgumentsValidatorHelper.ValidateEnumConversionValidator(enumType);

            this.enumType = enumType;
        }

        /// <summary>
        /// The type of enum that should be validated. 
        /// </summary>
        public Type EnumType
        {
            get { return enumType; }
        }

        /// <summary>
        /// Creates the <see cref="EnumConversionValidator"/> described by the attribute object.
        /// </summary>
        /// <param name="targetType">The type of object that will be validated by the validator.</param>
        /// <remarks>This operation must be overriden by subclasses.</remarks>
        /// <returns>The created <see cref="EnumConversionValidator"/>.</returns>
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new EnumConversionValidator(EnumType, Negated);
        }

        private readonly Guid typeId = Guid.NewGuid();

        /// <summary>
        /// Gets a unique identifier for this attribute.
        /// </summary>
        public override object TypeId
        {
            get
            {
                return this.typeId;
            }
        }
    }
}
