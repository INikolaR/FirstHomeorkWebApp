using System;
using NewVariant.Interfaces;
using NewVariant.Models;
using NewVariant.Exceptions;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Text.Json;

namespace DatabaseLib
{
    /// <summary>
    /// Class to save and manipulate data.
    /// </summary>
    public class DataBase : IDataBase
    {
        /// <summary>
        /// Consists databases in the Dictionary of 4 elements.
        /// </summary>
        private Dictionary<Type, object> databases = new Dictionary<Type, object>();
        public DataBase()
        {
            // The first element - the type of data, the second - the list of objects of this type.
            databases.Add(typeof(Shop), null); // null if table does not exist, the table itself otherwise.
            databases.Add(typeof(Buyer), null);
            databases.Add(typeof(Good), null);
            databases.Add(typeof(Sale), null);
        }
        /// <summary>
        /// Creates table of type T.
        /// </summary>
        /// <typeparam name="T">Type of table.</typeparam>
        /// <exception cref="DataBaseException">Throws if table is already exists.</exception>
        public void CreateTable<T>() where T : IEntity
        {
            if (!databases.ContainsKey(typeof(T)))
            {
                return; // If we get incorrect type - do nothing.
            }
            if (databases[typeof(T)] == null)
            {
                databases[typeof(T)] = new List<T>();
            }
            else
            {
                throw new DataBaseException("Table already exists!");
            }
        }
        /// <summary>
        /// Deserealizes the table of type T from the file.
        /// </summary>
        /// <typeparam name="T">Type of table.</typeparam>
        /// <param name="path">Path to file.</param>
        public void Deserialize<T>(string path) where T : IEntity
        {
            if (!databases.ContainsKey(typeof(T)))
            {
                return; // If we get incorrect type - do nothing.
            }
            try
            {
                databases[typeof(T)] = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path));
            }
            catch (Exception e)
            {
                databases[typeof(T)] = new List<T>();
            }
        }
        /// <summary>
        /// Gets the table of type T.
        /// </summary>
        /// <typeparam name="T">Type of table.</typeparam>
        /// <returns>Table.</returns>
        /// <exception cref="DataBaseException">Throws if there is no such table.</exception>
        public IEnumerable<T> GetTable<T>() where T : IEntity
        {
            if (!databases.ContainsKey(typeof(T)))
            {
                return new List<T>(); // If we get incorrect type - return empty list.
            }
            if (databases[typeof(T)] == null)
            {
                throw new DataBaseException("No such table!");
            }
            return new List<T>((List<T>)databases[typeof(T)]);
        }
        /// <summary>
        /// Inserts a record into table of type T.
        /// </summary>
        /// <typeparam name="T">Type of table.</typeparam>
        /// <param name="getEntity">Entity to insert.</param>
        /// <exception cref="DataBaseException">Throws if there is no such table.</exception>
        public void InsertInto<T>(Func<T> getEntity) where T : IEntity
        {
            if (!databases.ContainsKey(typeof(T)))
            {
                return; // If we get incorrect type - do nothing.
            }
            if (databases[typeof(T)] == null)
            {
                throw new DataBaseException("No such table!");
            }
            ((List<T>)databases[typeof(T)]).Add(getEntity());
        }
        /// <summary>
        /// Serealizes the table of type T to the file.
        /// </summary>
        /// <typeparam name="T">Type of table.</typeparam>
        /// <param name="path">Path to file.</param>
        /// <exception cref="DataBaseException">Throws if there is no such table.</exception>
        public void Serialize<T>(string path) where T : IEntity
        {
            if (!databases.ContainsKey(typeof(T)))
            {
                return;
            }
            try
            {
                if (databases[typeof(T)] == null)
                {
                    throw new DataBaseException("No such table!");
                }
                File.WriteAllText(path, JsonSerializer.Serialize<List<T>>((List<T>)databases[typeof(T)]));
            }
            catch (DataBaseException e)
            {
                throw e;
            }
            catch (Exception e)
            {

            }
        }
    }
}
