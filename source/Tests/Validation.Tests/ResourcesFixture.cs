﻿// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Globalization;
using EnterpriseLibrary.Validation.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnterpriseLibrary.Validation.Tests
{
    [TestClass]
    public class ResourcesFixture
    {
        [TestMethod]
        public void CanRetrieveResourceCulture()
        {
            // avoid drop in coverage for generate method
            CultureInfo cultureInfo = Resources.Culture;
            Resources.Culture = cultureInfo;
        }
    }
}
