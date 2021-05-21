// ***********************************************************************
// Assembly         : JewelryStoreAPIs
// Author           : Athira Nair
// Created          : 05-11-2021
//
// ***********************************************************************
// <copyright file="SharedMethods.cs" company="JewelryStoreAPIs">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using JewelryStoreAPIs.Authentication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace JewelryStoreAPIs
{
    /// <summary>
    /// Class SharedMethods.
    /// Implements the <see cref="Object" />
    /// </summary>
    /// <seealso cref="Object" />
    public static class SharedMethods
    {


        /// <summary>
        /// The created on
        /// </summary>
        private static string CreatedOn;

        /// <summary>
        /// Deserializes to object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns>T.</returns>
        public static T DeserializeToObject<T>(string filePath) where T : class
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

                T myDocument;
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    myDocument = (T)xmlSerializer.Deserialize(streamReader);
                }

                return myDocument;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// Loads the data model.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns>T.</returns>
        public static T LoadDataModel<T>(string filePath) where T : class
        {
            T seririzedObj = null;
            Console.WriteLine("Inside" + CreatedOn);
            seririzedObj = DeserializeToObject<T>(filePath);

            //Console.WriteLine("Ouside" + CreatedOn);

            return seririzedObj;
        }
        
    }
}
