#region License

// ********************************* Header *********************************\
// 
//    Class:  ImageUtil.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using AssemblyReport.Enumerators;
using AssemblyReport.Extensibility;

#endregion

namespace AssemblyReport.Utilities
{
    /// <summary>The <see cref="ImageUtil"/> class.</summary>
    public static class ImageUtil
    {
        #region Public Methods and Operators

        /// <summary>Saves all image member types to the output path.</summary>
        /// <param name="path">The output path.</param>
        public static void ExportAllMemberTypes(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path), @"The output path cannot be null or empty.");
            }

            DirectoryInfo info = new DirectoryInfo(path);
            string imageFolderName = info.Name;

            if (!info.Exists)
            {
                try
                {
                    info.Parent?.CreateSubdirectory(imageFolderName);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            ExportMemberTypeImage(path, "Class", MemberInfoTypes.Class);
            ExportMemberTypeImage(path, "Delegate", MemberInfoTypes.Delegate);
            ExportMemberTypeImage(path, "Enumerator", MemberInfoTypes.Enumerator);
            ExportMemberTypeImage(path, "Event", MemberInfoTypes.Event);
            ExportMemberTypeImage(path, "Interface", MemberInfoTypes.Interface);
            ExportMemberTypeImage(path, "Structure", MemberInfoTypes.Structure);
        }

        /// <summary>Saves the specified image member type to the specified output path.</summary>
        /// <param name="outputFolder">The output folder to save to.</param>
        /// <param name="fileName">The image file name to save as.</param>
        /// <param name="memberInfoTypes">Kind of the member.</param>
        /// <exception cref="ArgumentNullException">Thrown when the path is null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when the memberType or memberKind is null.</exception>
        public static void ExportMemberTypeImage(string outputFolder, string fileName, MemberInfoTypes memberInfoTypes)
        {
            if (string.IsNullOrEmpty(outputFolder))
            {
                throw new ArgumentNullException(nameof(outputFolder), @"The output path cannot be null or empty.");
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                Image imageType = ResolveMemberTypeImage(memberInfoTypes);

                string fullName = fileName + Constants.ImageFilePNGExtension;
                string destinationPath = Path.Combine(outputFolder, fullName);

                // Save image to file.
                imageType.Save(destinationPath, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>Gets the index of the image.</summary>
        /// <param name="source">The source type.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public static int GetMemberImageIndex(MemberInfoTypes source)
        {
            /* The Assembly Explorer Tree View ImageList icons index table:
             *
             * 0 = Folder
             * 1 = Namespace
             * 2 = Class
             * 3 = Delegate
             * 4 = Enumerator
             * 5 = Event
             * 6 = Interface
             * 7 = Method
             * 8 = Structure
             * 9 = Constructor
             * 10 = Field
             * 11 = Property
             *
             */

            int index;

            switch (source)
            {
                case MemberInfoTypes.Event:
                {
                    index = 5;
                    break;
                }
                case MemberInfoTypes.Field:
                {
                    index = 10;
                    break;
                }
                case MemberInfoTypes.Method:
                {
                    index = 7;
                    break;
                }
                case MemberInfoTypes.Property:
                {
                    index = 11;
                    break;
                }
                case MemberInfoTypes.Class:
                {
                    index = 2;
                    break;
                }
                case MemberInfoTypes.Delegate:
                {
                    index = 3;
                    break;
                }
                case MemberInfoTypes.Enumerator:
                {
                    index = 4;
                    break;
                }
                case MemberInfoTypes.Structure:
                {
                    index = 8;
                    break;
                }
                case MemberInfoTypes.Interface:
                {
                    index = 6;
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(source), source, null);
                }
            }

            return index;
        }

        /// <summary>Resolves the member type image.</summary>
        /// <param name="memberInfoTypes">The member information types.</param>
        /// <returns>The <see cref="Image"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">memberInfoTypes - null</exception>
        public static Image ResolveMemberTypeImage(MemberInfoTypes memberInfoTypes)
        {
            string memberName;

            // Determine the image to extract.
            switch (memberInfoTypes)
            {
                case MemberInfoTypes.Class:
                {
                    memberName = "Class";
                    break;
                }
                case MemberInfoTypes.Delegate:
                {
                    memberName = "Delegate";
                    break;
                }
                case MemberInfoTypes.Enumerator:
                {
                    memberName = "Enumerator";
                    break;
                }
                case MemberInfoTypes.Structure:
                {
                    memberName = "Structure";
                    break;
                }
                case MemberInfoTypes.Interface:
                {
                    memberName = "Interface";
                    break;
                }
                case MemberInfoTypes.Event:
                {
                    memberName = "Event";
                    break;
                }
                case MemberInfoTypes.Field:
                {
                    memberName = "Field";
                    break;
                }
                case MemberInfoTypes.Method:
                {
                    memberName = "Method";
                    break;
                }
                case MemberInfoTypes.Property:
                {
                    memberName = "Property";
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(memberInfoTypes), memberInfoTypes, null);
                }
            }

            string fullResourceName = memberName + Constants.ImageFilePNGExtension;

            // Get the assembly to extract the resource images from.
            Assembly assembly = typeof(Constants).Assembly;
            string resourceBasePath = assembly.GetResourceBasePath(fullResourceName);

            // Extract to image.
            Image extractToImage = ResourceUtils.ExtractToImage(assembly, resourceBasePath);

            return extractToImage;
        }

        #endregion
    }
}