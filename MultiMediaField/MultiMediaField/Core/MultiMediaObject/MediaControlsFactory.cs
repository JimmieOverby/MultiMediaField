// <copyright file="MediaControlsFactory.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Collections.Generic;
  using System.Xml;
  using Reflection;
  using Sitecore.Configuration;
  using Sitecore.Text;
  using Utilities;

  /// <summary>
  /// The media controls factory.
  /// </summary>
  public class MediaControlsFactory : Singleton<MediaControlsFactory>
  {
    #region Fields

    /// <summary>
    /// The media object extensions.
    /// </summary>
    private readonly Dictionary<string, string> mediaObjectExtensions = new Dictionary<string, string>();

    #endregion Fields

    #region Constructors

    /// <summary>
    /// Prevents a default instance of the <see cref="MediaControlsFactory"/> class from being created.
    /// </summary>
    private MediaControlsFactory()
    {
      this.RegisterControls();
    }

    #endregion Constructors

    #region Public methods

    /// <summary>
    /// Gets the media object.
    /// </summary>
    /// <param name="extension">
    /// The files extension.
    /// </param>
    /// <returns>
    /// Return media object for the extension. If object doesn't exit and useDefaultObject set to true, return default media object.
    /// </returns>
    public MediaBaseObject GetMediaObject(string extension)
    {
      string mediaObjectType;
      if (this.mediaObjectExtensions.TryGetValue(extension.ToLower(), out mediaObjectType))
      {
        MediaBaseObject mediaBaseObject = ReflectionUtil.CreateObject(mediaObjectType) as MediaBaseObject;
        return mediaBaseObject;
      }

      return null;
    }

    #endregion Public methods

    #region Protected methods

    /// <summary>
    /// The register controls.
    /// </summary>
    protected void RegisterControls()
    {
      this.mediaObjectExtensions.Clear();
      XmlNodeList nodeList = Factory.GetConfigNode("multimedia").ChildNodes;
      foreach (XmlNode node in nodeList)
      {
        ListString extensions = new ListString(node.Attributes["extensions"].Value);
        foreach (string extension in extensions.Items)
        {
          if (!this.mediaObjectExtensions.ContainsKey(extension.ToLower()))
          {
            this.mediaObjectExtensions.Add(extension.ToLower(), node.Attributes["type"].Value);
          }
        }
      }
    }

    #endregion Protected methods
  }
}