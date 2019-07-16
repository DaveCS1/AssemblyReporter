#region License

// ********************************* Header *********************************\
// 
//    Class:  ReflectionExtensions.cs
//    Copyright (c) 2019 - 2019 AssemblyReport. All rights reserved.
// 
// **************************************************************************/

#endregion

#region Namespace

using System;
using System.Reflection;
using AssemblyReport.Enumerators;

#endregion

namespace AssemblyReport.Extensibility
{
    /// <summary>The <see cref="ReflectionExtensions"/> provides extension methods.</summary>
    public static class ReflectionExtensions
    {
        #region Public Methods and Operators

        ///// <summary>Converts to member information types.</summary>
        ///// <param name="source">The source.</param>
        ///// <returns>The <see cref="MemberInfoTypes"/>.</returns>
        ///// <exception cref="ArgumentOutOfRangeException"></exception>
        //// ReSharper disable once CyclomaticComplexity
        //public static MemberInfoTypes ConvertToMemberInfoTypes(this TypeKind source)
        //{
        //    MemberInfoTypes memberInfoTypes;

        //    switch (source)
        //    {
        //        case TypeKind.Other:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Class:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Interface:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Interface;
        //            break;
        //        }
        //        case TypeKind.Struct:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Structure;
        //            break;
        //        }
        //        case TypeKind.Delegate:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Delegate;
        //            break;
        //        }
        //        case TypeKind.Enum:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Enumerator;
        //            break;
        //        }
        //        case TypeKind.Void:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Method;
        //            break;
        //        }
        //        case TypeKind.Unknown:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Null:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.None:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Dynamic:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.UnboundTypeArgument:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.TypeParameter:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Array:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Pointer:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.ByReference:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Anonymous:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Intersection:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.ArgList:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.Tuple:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.ModOpt:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        case TypeKind.ModReq:
        //        {
        //            memberInfoTypes = MemberInfoTypes.Class;
        //            break;
        //        }
        //        default:
        //        {
        //            throw new ArgumentOutOfRangeException();
        //        }
        //    }

        //    return memberInfoTypes;
        //}

        /// <summary>Converts to member information types.</summary>
        /// <param name="source">The source.</param>
        /// <param name="instance">The instance fo the type.</param>
        /// <returns>The <see cref="MemberInfoTypes"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">source - null</exception>
        public static MemberInfoTypes ConvertToMemberInfoTypes(this MemberTypes source, Type instance = null)
        {
            MemberInfoTypes infoTypes;

            switch (source)
            {
                case MemberTypes.Constructor:
                {
                    infoTypes = MemberInfoTypes.Class;
                    break;
                }
                case MemberTypes.Event:
                {
                    infoTypes = MemberInfoTypes.Event;
                    break;
                }
                case MemberTypes.Field:
                {
                    infoTypes = MemberInfoTypes.Field;
                    break;
                }
                case MemberTypes.Method:
                {
                    infoTypes = MemberInfoTypes.Method;
                    break;
                }
                case MemberTypes.Property:
                {
                    infoTypes = MemberInfoTypes.Property;
                    break;
                }
                case MemberTypes.TypeInfo:
                {
                    if (instance != null)
                    {
                        // Validate whether the type is a class.
                        if (instance.IsClass)
                        {
                            infoTypes = MemberInfoTypes.Class;
                        }
                        else if (instance.IsEnum)
                        {
                            infoTypes = MemberInfoTypes.Enumerator;
                        }
                        else if (instance.IsStructure())
                        {
                            infoTypes = MemberInfoTypes.Structure;
                        }
                        else if (instance.IsInterface)
                        {
                            infoTypes = MemberInfoTypes.Interface;
                        }
                        else
                        {
                            infoTypes = MemberInfoTypes.Class;
                        }
                    }
                    else
                    {
                        infoTypes = MemberInfoTypes.Class;
                    }

                    break;
                }
                case MemberTypes.Custom:
                {
                    infoTypes = MemberInfoTypes.Class;
                    break;
                }
                case MemberTypes.NestedType:
                {
                    if (instance != null)
                    {
                        if (instance.IsEnum)
                        {
                            infoTypes = MemberInfoTypes.Enumerator;
                        }
                        else
                        {
                            infoTypes = MemberInfoTypes.Class;
                        }
                    }
                    else
                    {
                        infoTypes = MemberInfoTypes.Class;
                    }

                    break;
                }
                case MemberTypes.All:
                {
                    infoTypes = MemberInfoTypes.Class;
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException(nameof(source), source, null);
                }
            }

            return infoTypes;
        }

        /// <summary>Converts to member information types.</summary>
        /// <param name="source">The source.</param>
        /// <returns>The <see cref="MemberInfoTypes"/>.</returns>
        public static MemberInfoTypes ConvertToMemberInfoTypes(this Type source)
        {
            MemberTypes types = source.MemberType;
            return ConvertToMemberInfoTypes(types, source);
        }

        #endregion
    }
}