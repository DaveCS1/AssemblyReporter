#region License

// ********************************* Header *********************************\
// 
//    Class:  MarkdownReport.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms.VisualStyles;
using AssemblyReport.Enumerators;
using AssemblyReport.Extensibility;
using AssemblyReport.Primitives.AssemblyHierarchy;
using AssemblyReport.Primitives.Markdown.Elements;
using AssemblyReport.Properties;
using AssemblyReport.Utilities;

#endregion

namespace AssemblyReport.Primitives.Markdown
{
    /// <summary>The <see cref="MarkdownReport"/> class.</summary>
    public class MarkdownReport : MarkdownBase
    {
        #region Constants

        /// <summary>The document separator.</summary>
        public const string DocumentSeparator = "---";

        /// <summary>The markdown separator.</summary>
        public const char MarkdownSeparator = '|';

        /// <summary>The missing documentation text.</summary>
        public const string MissingDocumentationText = "Missing summary description.";

        /// <summary>The table divider set0.</summary>
        public const string TableDividerSet0 = ":---: | :---: | ---";

        /// <summary>The table divider set1.</summary>
        public const string TableDividerSet1 = ":---: | :---: | --- | ---";

        #endregion

        #region Constructors and Destructors

        /// <summary>Initializes a new instance of the <see cref="MarkdownReport"/> class.</summary>
        /// <param name="assemblyPropertiesInfo">The assembly properties information.</param>
        /// <param name="hierarchy">The assembly hierarchy.</param>
        /// <param name="reportSettings">The report settings.</param>
        public MarkdownReport(AssemblyPropertiesInfo assemblyPropertiesInfo, HierarchyTree hierarchy, ReportSettings reportSettings) : base(Path.GetFileNameWithoutExtension(assemblyPropertiesInfo.Location), assemblyPropertiesInfo.AssemblyDirectory.FullName)
        {
            // Initialize variables
            AssemblyPropertiesInfo = assemblyPropertiesInfo;
            HierarchyTree = hierarchy;
            ReportSettings = reportSettings;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the assembly properties information.</summary>
        /// <value>The assembly properties information.</value>
        public AssemblyPropertiesInfo AssemblyPropertiesInfo { get; private set; }

        /// <summary>Gets the hierarchy tree.</summary>
        /// <value>The hierarchy tree.</value>
        public HierarchyTree HierarchyTree { get; private set; }

        /// <summary>Gets the report settings.</summary>
        /// <value>The report settings.</value>
        public ReportSettings ReportSettings { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>Gets the category types.</summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <see cref="List{T}"/>.</returns>
        public static List<MarkdownTypeId> GetCategoryTypes(ReportSettings settings)
        {
            var entries = new List<MarkdownTypeId>
            {
                new MarkdownTypeId(MemberInfoTypes.Class, $@"{nameof(Resources.Class)}", settings),
                new MarkdownTypeId(MemberInfoTypes.Delegate, $@"{nameof(Resources.Delegate)}", settings),
                new MarkdownTypeId(MemberInfoTypes.Enumerator, $@"{nameof(Resources.Enumerator)}", settings),
                new MarkdownTypeId(MemberInfoTypes.Event, $@"{nameof(Resources.Event)}", settings),
                new MarkdownTypeId(MemberInfoTypes.Interface, $@"{nameof(Resources.Interface)}", settings),
                new MarkdownTypeId(MemberInfoTypes.Structure, $@"{nameof(Resources.Structure)}", settings)
            };

            return entries;
        }

        /// <summary>Generates the report.</summary>
        /// <param name="assemblyPropertiesInfo">The assembly properties information.</param>
        /// <param name="hierarchy">The hierarchy.</param>
        /// <param name="reportSettings">The report settings.</param>
        public void GenerateReport(AssemblyPropertiesInfo assemblyPropertiesInfo, HierarchyTree hierarchy, ReportSettings reportSettings)
        {
            AssemblyPropertiesInfo = assemblyPropertiesInfo;
            HierarchyTree = hierarchy;
            ReportSettings = reportSettings;

            // Begin the generation process for the report.
            StringBuilder reportBuilder = new StringBuilder();

            // Header
            reportBuilder.AppendLine(MarkdownElement.CreateComment(@"Initialize Document Variables"));
            reportBuilder.AppendLine();

            // Generate Top link
            reportBuilder.AppendLine(HtmlUtil.GenerateBackToTop()[0]);
            reportBuilder.AppendLine();

            // Loop thru each member info type and register the commonly used variables for the markdown document.
            //foreach (MarkdownTypeId reference in GetCategoryTypes(ReportSettings))
            //{
            // Create a comment to separate the categories.
            //reportBuilder.AppendLine(MarkdownElement.CreateComment($@"ID: {reference.ID} Variables"));

            // Create the image source reference variables.
            //string imageTypeSource = reference.ImageTypeSource;
            //reportBuilder.AppendLine(imageTypeSource);
            //}

            // Create visual document content
            reportBuilder.AppendLine(HtmlUtil.GenerateHTMLTextCode(HorizontalAlign.Center, @"Assembly Report", "h2"));

            // Render assembly report information
            string italicAssemblyLocation = MarkdownEmphasis.CreateEmphasis(AssemblyPropertiesInfo.FileName, MarkdownEmphasis.EmphasisType.Italic);
            reportBuilder.AppendLine(MarkdownHeader.CreateHeader(@"Assembly: " + italicAssemblyLocation, 6));

            string italicAssemblyExportedTypes = MarkdownEmphasis.CreateEmphasis(Convert.ToString(ReportSettings.ExportedTypes), MarkdownEmphasis.EmphasisType.Italic);
            reportBuilder.AppendLine(MarkdownHeader.CreateHeader(@"Exported Types: " + italicAssemblyExportedTypes, 6));

            string italicAssemblyMissingDocumentation = MarkdownEmphasis.CreateEmphasis(Convert.ToString(ReportSettings.MissingDocumentation.Count), MarkdownEmphasis.EmphasisType.Italic);
            reportBuilder.AppendLine(MarkdownHeader.CreateHeader(@"Missing Documentation: " + italicAssemblyMissingDocumentation, 6));

            string italicTimestampGenerated = MarkdownEmphasis.CreateEmphasis(DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString(), MarkdownEmphasis.EmphasisType.Italic);
            reportBuilder.AppendLine(MarkdownHeader.CreateHeader(@"Generated: " + italicTimestampGenerated, 6));

            // Draw splitter
            reportBuilder.AppendLine();
            reportBuilder.AppendLine(DocumentSeparator);
            reportBuilder.AppendLine();

            // Generate architecture sections and their images.
            if (HierarchyTree.Classes.Count > 0)
            {
                reportBuilder.AppendLine(GenerateSection(MemberInfoTypes.Class, "Classes", "Class", reportSettings, HierarchyTree.Classes));
            }

            if (HierarchyTree.Delegates.Count > 0)
            {
                reportBuilder.AppendLine(GenerateSection(MemberInfoTypes.Delegate, "Delegates", "Delegate", reportSettings, HierarchyTree.Delegates));
            }

            if (HierarchyTree.Enumerators.Count > 0)
            {
                reportBuilder.AppendLine(GenerateSection(MemberInfoTypes.Enumerator, "Enumerators", "Enumerator", reportSettings, HierarchyTree.Enumerators));
            }

            if (HierarchyTree.Events.Count > 0)
            {
                reportBuilder.AppendLine(GenerateSection(MemberInfoTypes.Event, "Events", "Event", reportSettings, HierarchyTree.Events));
            }

            if (HierarchyTree.Interfaces.Count > 0)
            {
                reportBuilder.AppendLine(GenerateSection(MemberInfoTypes.Interface, "Interfaces", "Interface", reportSettings, HierarchyTree.Interfaces));
            }

            if (HierarchyTree.Structures.Count > 0)
            {
                reportBuilder.AppendLine(GenerateSection(MemberInfoTypes.Structure, "Structures", "Structure", reportSettings, HierarchyTree.Structures));
            }

            reportBuilder.AppendLine(DocumentSeparator);
            reportBuilder.AppendLine();
            reportBuilder.Append(HtmlUtil.GenerateBackToTop()[1]);

            Contents = reportBuilder.ToString();
        }

        #endregion

        #region Methods

        /// <summary>Generates the category section for the members info.</summary>
        /// <param name="sectionInfoTypes">The section kind.</param>
        /// <param name="categoryHeader">The category header name.</param>
        /// <param name="tableName">The table name.</param>
        /// <param name="settings">The image directory.</param>
        /// <param name="items">The table row items.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GenerateSection(MemberInfoTypes sectionInfoTypes, string categoryHeader, string tableName, ReportSettings settings, List<HierarchyNode> items)
        {
            const string DescriptionHeader = "Description";
            const string ValuesHeader = "Values";

            string basePath;
            char pathDivider;

            if (settings.FileRepositoryIsUrl)
            {
                pathDivider = Path.AltDirectorySeparatorChar;

                // Retrieve the trimmed relative path
                string parentUrl = TextUtil.GetParentUriString(new Uri(settings.ImageRepository));
                string relativePath = TextUtil.GetRelativeURIPath(parentUrl, settings.ImageRepository);
                string formattedPath = relativePath.Substring(1, relativePath.Length - 2);

                // Formats the path to a url from string
                basePath = $@"{formattedPath}";
            }
            else
            {
                pathDivider = Path.DirectorySeparatorChar;

                // Return the relative path
                string dirPath = Path.GetDirectoryName(settings.BuildPath);

                string relativePath = TextUtil.GetRelativePath(settings.ImageRepository, dirPath);

                // Format the path to scope into the image directory for retrieving the images from the local system.
                basePath = $@".\{relativePath}";
            }

            string imageSource = $@"{basePath}{pathDivider}{tableName}{Constants.ImageFilePNGExtension}";

            string memberImageText = HtmlUtil.GenerateHTMLImageCode(imageSource, tableName, new Size(16, 16));

            // Create the markdown table layout.
            var columns = new List<string>();
            var rows = new List<string>();

            // Create the top left section. Add an empty buffer image to keep the table cells at a minimum size to prevent hiding the image cells when during text wrapping. 

            columns.Add(string.Format("<img src={0}file://null{0} width={0}{1}{0} height={0}0{0} alt ={0}{0} />", Constants.Quotes, 64));
            columns.Add(tableName);
            columns.Add(DescriptionHeader);

            // Determine the member kind.
            switch (sectionInfoTypes)
            {
                case MemberInfoTypes.Class:
                {
                    // Create section separators.
                    const string sectionSeparators = TableDividerSet0;
                    rows.Add(sectionSeparators);

                    // Create section items content.
                    foreach (HierarchyNode entry in items)
                    {
                        string itemName = entry.Name;
                        string itemDescription = DocumentationExtensions.GetSummary(entry.NodeType);

                        if (string.IsNullOrEmpty(itemDescription))
                        {
                            itemDescription = MissingDocumentationText;
                        }

                        string rowItemName = $"{memberImageText} {MarkdownSeparator} {itemName} {MarkdownSeparator} {itemDescription}";

                        rows.Add(rowItemName);
                    }

                    break;
                }
                case MemberInfoTypes.Delegate:
                {
                    // Create section separators.
                    const string sectionSeparators = TableDividerSet0;
                    rows.Add(sectionSeparators);

                    // Create section items content.
                    foreach (HierarchyNode entry in items)
                    {
                        string itemName = entry.Name;
                        string itemDescription = DocumentationExtensions.GetSummary(entry.NodeType);

                        if (string.IsNullOrEmpty(itemDescription))
                        {
                            itemDescription = MissingDocumentationText;
                        }

                        string rowItemName = $"{memberImageText} {MarkdownSeparator} {itemName} {MarkdownSeparator} {itemDescription}";

                        rows.Add(rowItemName);
                    }

                    break;
                }
                case MemberInfoTypes.Enumerator:
                {
                    columns.Add(ValuesHeader);

                    // Create section separators.
                    const string sectionSeparators = TableDividerSet1;
                    rows.Add(sectionSeparators);

                    // Create section items content.
                    foreach (HierarchyNode entry in items)
                    {
                        string itemName = entry.Name;
                        string itemDescription = DocumentationExtensions.GetSummary(entry.NodeType);

                        if (string.IsNullOrEmpty(itemDescription))
                        {
                            itemDescription = MissingDocumentationText;
                        }

                        string enumValues = TypesUtil.GetEnumeratorValues(entry.NodeType);

                        string rowItemName = $"{memberImageText} {MarkdownSeparator} {itemName} {MarkdownSeparator} {itemDescription} {MarkdownSeparator} {enumValues}.";

                        rows.Add(rowItemName);
                    }

                    break;
                }
                case MemberInfoTypes.Structure:
                {
                    // Create section separators.
                    const string sectionSeparators = TableDividerSet0;
                    rows.Add(sectionSeparators);

                    // Create section items content.
                    foreach (HierarchyNode entry in items)
                    {
                        string itemName = entry.Name;
                        string itemDescription = DocumentationExtensions.GetSummary(entry.NodeType);

                        if (string.IsNullOrEmpty(itemDescription))
                        {
                            itemDescription = MissingDocumentationText;
                        }

                        string rowItemName = $"{memberImageText} {MarkdownSeparator} {itemName} {MarkdownSeparator} {itemDescription}";

                        rows.Add(rowItemName);
                    }

                    break;
                }
                case MemberInfoTypes.Interface:
                {
                    // Create section separators.
                    const string sectionSeparators = TableDividerSet0;
                    rows.Add(sectionSeparators);

                    // Create section items content.
                    foreach (HierarchyNode entry in items)
                    {
                        string itemName = entry.Name;
                        string itemDescription = DocumentationExtensions.GetSummary(entry.NodeType);

                        if (string.IsNullOrEmpty(itemDescription))
                        {
                            itemDescription = MissingDocumentationText;
                        }

                        string rowItemName = $"{memberImageText} {MarkdownSeparator} {itemName} {MarkdownSeparator} {itemDescription}";

                        rows.Add(rowItemName);
                    }

                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(sectionInfoTypes), sectionInfoTypes, null);
                }
            }

            // Generate markdown table.
            StringBuilder sectionBuilder = new StringBuilder();

            // Create the header.
            sectionBuilder.AppendLine(MarkdownHeader.CreateHeader(categoryHeader, 3));

            // Create the table.
            string table = new MarkdownTable(columns, rows).MarkdownContentText;
            sectionBuilder.Append(table);

            return sectionBuilder.ToString();
        }

        #endregion
    }
}