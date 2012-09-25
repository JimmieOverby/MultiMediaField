// <copyright file="Image.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Web.UI;

  /// <summary>
  /// The image.
  /// </summary>
  public class ImageControl : MediaBaseObject
  {
    #region Overriden methods
    /// <summary>
    /// The render.
    /// </summary>
    /// <param name="writer">
    /// The writer.
    /// </param>
    protected override void Render(HtmlTextWriter writer)
    {
      this.MediaObjectTag = HtmlTextWriterTag.Img;
      base.Render(writer);
    }

    #endregion Overriden methods
  }
}