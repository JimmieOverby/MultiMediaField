// <copyright file="Quicktime.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Text;
  using System.Web.UI;

  /// <summary>
  /// Displays quick time video on the page.
  /// </summary>
  public class Quicktime : MediaBaseObject
  {
    #region Fields

    /// <summary>
    /// The class id.
    /// </summary>
    private static readonly string classID = "clsid:02BF25D5-8C17-4B23-BC80-D3488ABDDC6B";

    /// <summary>
    /// The code base.
    /// </summary>
    private static readonly string codeBase = "http://www.apple.com/qtactivex/qtplugin.cab#version=7,3,0,0";

    /// <summary>
    /// The object type.
    /// </summary>
    private static readonly string objectType = "video/quicktime";

    #endregion Fields

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

      this.AddObjectAttribute("codebase", codeBase);
      this.AddObjectAttribute("classid", classID);

      this.AddObjectParameter("src", src);
      this.AddObjectParameter("autohref", bool.TrueString);
      this.AddObjectParameter("autoplay", bool.TrueString);
      this.AddObjectParameter("bgcolor", "white");
      this.AddObjectParameter("cache", bool.TrueString);
      this.AddObjectParameter("controller", bool.TrueString);
      this.AddObjectParameter("correction", "full");
      this.NestedObject = this.CreateNestedObject(src);

      base.Render(writer);
    }

    #endregion Protected methods

    #region Private methods

    /// <summary>
    /// Creates nested object.
    /// </summary>
    /// <param name="src">
    /// The source url.
    /// </param>
    /// <returns>
    /// The nested object body.
    /// </returns>
    private string CreateNestedObject(string src)
    {
      StringBuilder nested = new StringBuilder();

      nested.AppendLine(string.Format("<object  name=\"movieId\" data=\"{0}\" width=\"{1}\" height=\"{2}\" type=\"{3}\">", src, this.Width.Value, this.Height.Value, objectType));
      nested.AppendLine("<param value=\"true\" name=\"autoplay\" />");
      nested.AppendLine("<param value=\"true\" name=\"controller\" />");
      nested.AppendLine("<param value=\"true\" name=\"showlogo\" />");
      nested.AppendLine("<param value=\"white\" name=\"bgcolor\" />");
      nested.AppendLine("<param value=\"true\" name=\"cache\" />");
      nested.AppendLine("<param value=\"true\" name=\"autohref\" />");
      nested.AppendLine("<param value=\"full\" name=\"correction\" />");
      nested.AppendLine("</object>");

      return nested.ToString();
    }

    #endregion Private methods
  }
}