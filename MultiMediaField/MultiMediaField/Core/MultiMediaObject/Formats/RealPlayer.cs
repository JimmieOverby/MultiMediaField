// <copyright file="RealPlayer.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Web.UI;

  /// <summary>
  /// Display "ra", "ram", "rpm" files on the page.
  /// </summary>
  public class RealPlayer : MediaBaseObject
  {
    #region Fields

    /// <summary>
    /// The class id.
    /// </summary>
    private static readonly string classID = "clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA";

    /// <summary>
    /// The object type.
    /// </summary>
    private static readonly string objectType = "audio/x-pn-realaudio";

    #endregion Fields

    #region Overriden methods

    /// <summary>
    /// The render.
    /// </summary>
    /// <param name="writer">
    /// The writer.
    /// </param>
    protected override void Render(HtmlTextWriter writer)
    {
      this.AddObjectAttribute("src", this.Source);
      this.AddObjectAttribute("classid", classID);
      this.AddObjectAttribute("type", objectType);

      base.Render(writer);
    }

    #endregion Overriden methods
  }
}