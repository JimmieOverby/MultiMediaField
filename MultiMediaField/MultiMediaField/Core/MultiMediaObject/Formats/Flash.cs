// <copyright file="Flash.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Web.UI;

  /// <summary>
  /// The flash object.
  /// </summary>
  public class Flash : MediaBaseObject
  {
    #region Fields

    /// <summary>
    /// The object type.
    /// </summary>
    private static readonly string objectType = "application/x-shockwave-flash";

    #endregion

    #region Protected methods

    /// <summary>
    /// The render.
    /// </summary>
    /// <param name="writer">
    /// The writer.
    /// </param>
    protected override void Render(HtmlTextWriter writer)
    {
      string src = this.Source;
      this.RemoveObjectAttribute("src");   

      this.AddObjectAttribute("type", objectType);
      this.AddObjectAttribute("data", src);

      this.AddObjectParameter("movie", src);
      this.AddObjectParameter("wmode", "transparent");
      this.AddObjectParameter("loop", "true");
      this.AddObjectParameter("menu", "false");
      this.AddObjectParameter("allowScriptAccess", "always");
      this.AddObjectParameter("play", "true");
      this.AddObjectParameter("loop", "true");

      base.Render(writer);
    }

    #endregion
  }
}