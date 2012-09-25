// <copyright file="WindowsMediaPlayer.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Web.UI;

  /// <summary>
  /// Displays "wma", "wmv", "avi", "mpeg" files on the page.
  /// </summary>
  public class WindowsMediaPlayer : MediaBaseObject
  {
    #region Fields

    /// <summary>
    /// The class id.
    /// </summary>
    private static readonly string classID = "clsid:22D6F312-B0F6-11D0-94AB-0080C74C7E95"; // "clsid:6BF52A52-394A-11d3-B153-00C04F79FAA6";

    /// <summary>
    /// The code base.
    /// </summary>
    private static readonly string codeBase = "http://activex.microsoft.com/activex/controls/mplayer/en/nsmp2inf.cab#Version=5,1,52,701";

    /// <summary>
    /// The firefox object type.
    /// </summary>
    private static readonly string firefoxObjectType = "application/x-mplayer2";

    /// <summary>
    /// The firefox plugins page.
    /// </summary>
    private static readonly string firefoxPluginsPage = "http://www.microsoft.com/Windows/MediaPlayer/";

    /// <summary>
    /// The object type.
    /// </summary>
    private static readonly string objectType = "application/x-oleobject";

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
      this.AddObjectAttribute("src", src);
      this.AddObjectAttribute("data", src);
      this.AddObjectAttribute("classid", classID);
      this.AddObjectAttribute("type", objectType);
      this.AddObjectAttribute("codebase", codeBase);
      this.AddObjectAttribute("ShowStatusBar", "true");
      this.AddObjectAttribute("DefaultFrame", "mainFrame");

      this.NestedObject = this.CreateNestedObject(src);

      base.Render(writer);
    }

    #endregion

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
      string writer = string.Empty;
      writer += "<!-- BEGIN PLUG-IN HTML FOR FIREFOX-->";
      writer += string.Format("<embed height=\"{0}\" width=\"{1}\" align=\"middle\" showstatusbar=\"true\" defaultframe=\"rightFrame\" src=\"{2}\" pluginspage=\"{3}\" type=\"{4}\"></embed>", this.Width.Value, this.Height.Value, src, firefoxPluginsPage, firefoxObjectType);
      writer += "<!-- END PLUG-IN HTML FOR FIREFOX-->";
      return writer;
    }

    #endregion
  }
}