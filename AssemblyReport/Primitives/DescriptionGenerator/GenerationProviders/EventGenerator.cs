#region License

// ********************************* Header *********************************\
// 
//    Class:  EventGenerator.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace AssemblyReport.Primitives.DescriptionGenerator
{
    /// <summary>The <see cref="DescriptionGeneratorBase"/> class.</summary>
    public partial class DescriptionGeneratorBase
    {
        #region Public Methods and Operators

        /// <summary>Generates the property.</summary>
        /// <param name="delegateName">Name of the delegate.</param>
        /// <param name="remarks">The remarks.</param>
        /// <returns>The <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">delegateName - The property name cannot be null or empty!</exception>
        public static string GenerateDelegate(string delegateName, string remarks)
        {
            if (string.IsNullOrEmpty(delegateName))
            {
                throw new ArgumentNullException(nameof(delegateName), @"The delegate name cannot be null or empty!");
            }

            // Get the event text
            return GenerateSummary($@"Occurs when a property value has changed for {delegateName}.", remarks);
        }

        /// <summary>Generates the property.</summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="parameters">The list of parameters.</param>
        /// <param name="remarks">The remarks text.</param>
        /// <returns>The <see cref="string"/>.</returns>
        /// <exception cref="ArgumentNullException">eventName - The property name cannot be null or empty!</exception>
        public static string GenerateEvent(string eventName, List<ParamInfo> parameters, string remarks)
        {
            if (string.IsNullOrEmpty(eventName))
            {
                throw new ArgumentNullException(nameof(eventName), @"The event name cannot be null or empty!");
            }

            StringBuilder eventBuilder = new StringBuilder();

            // Generate summary text
            string summaryText = GenerateSummary($@"Called when the {eventName} has changed.", remarks);
            eventBuilder.AppendLine(summaryText);

            if ((parameters != null) && (parameters.Count > 0))
            {
                // Generate parameters text
                foreach (ParamInfo paramInfo in parameters)
                {
                    string parametersText = GenerateParameter(paramInfo);
                    eventBuilder.AppendLine(parametersText);
                }
            }

            // Get the event text
            return eventBuilder.ToString();
        }

        #endregion
    }
}