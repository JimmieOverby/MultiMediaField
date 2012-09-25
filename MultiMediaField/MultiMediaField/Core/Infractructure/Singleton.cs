// <copyright file="Singleton.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Utilities
{
  using System.Reflection;

  /// <summary>
  /// Base class for the singleton classes.
  /// </summary>
  /// <typeparam name="T">
  /// The type name.
  /// </typeparam>
  public class Singleton<T> where T : class
  {
    #region Fields

    /// <summary>
    /// The sync object.
    /// </summary>
    private static readonly object syncObject = new object();

    /// <summary>
    /// The instance.
    /// </summary>
    private static T instance;

    #endregion

    #region Public properties

    /// <summary>
    /// Gets Instance.
    /// </summary>
    public static T Instance
    {
      get
      {
        if (instance == null)
        {
          lock (syncObject)
          {
            if (instance == null)
            {
              instance = (T)typeof(T).InvokeMember(typeof(T).Name, BindingFlags.Instance | BindingFlags.CreateInstance | BindingFlags.NonPublic, null, null, null);
            }
          }
        }

        return instance;
      }
    }

    #endregion
  }
}