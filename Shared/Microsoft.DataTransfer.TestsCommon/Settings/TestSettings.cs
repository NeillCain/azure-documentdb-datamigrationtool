﻿using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Microsoft.DataTransfer.TestsCommon.Settings
{
    [XmlRoot("Settings")]
    public sealed class TestSettings : ITestSettings
    {
        [XmlElement]
        public string DocumentDbConnectionStringFormat { get; set; }

        [XmlElement]
        public string SqlConnectionString { get; set; }

        [XmlElement]
        public string MongoConnectionString { get; set; }

        public string DocumentDbConnectionString(string databaseName)
        {
            return String.Format(CultureInfo.InvariantCulture, DocumentDbConnectionStringFormat, databaseName);
        }
    }
}
