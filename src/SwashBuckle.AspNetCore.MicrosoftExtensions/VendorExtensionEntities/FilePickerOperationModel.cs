﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
    public class FilePickerOperationModel
    {
        /// <summary>
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </summary>
        [JsonProperty("operation-id")]
        public string OperationId { get; }

        /// <summary>
        /// Parameter value to pass to lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&amp;lookupOpParam2=hardcoded)
        /// </summary>
        [JsonProperty("parameters")]
        public Dictionary<string, FilePickerParameterValue> Parameters { get; }

        /// <param name="operationId">
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </param>
        /// <param name="parameters">
        /// Parameter value to pass to lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&amp;lookupOpParam2=hardcoded)
        /// </param>
        public FilePickerOperationModel (string operationId, Dictionary<string, string> parameters)
        {
            //no operation - dont create parameters
            if (string.IsNullOrEmpty(operationId))
                return;

            OperationId = operationId;
            if (parameters == null)
                return;
            Parameters = new Dictionary<string, FilePickerParameterValue>();
            foreach (var param in parameters)
            {
                Parameters.Add(param.Key, new FilePickerParameterValue(param.Value));
            }
        }
    }

    public class FilePickerParameterValue
    {
        [JsonProperty("value-property")]
        public string Value { get; }

        public FilePickerParameterValue(string value)
        {
            Value = value;
        }
    }
}