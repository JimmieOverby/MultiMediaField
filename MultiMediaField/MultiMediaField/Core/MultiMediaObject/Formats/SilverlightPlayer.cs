// <copyright file="WindowsMediaPlayer.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Text;
  using System.Web.UI;

  /// <summary>
  /// The silverlight player.
  /// </summary>
  public class SilverlightPlayer : MediaBaseObject
  {
    #region Fields

    /// <summary>
    /// The object data.
    /// </summary>
    private static readonly string objectData = "data:application/x-silverlight-2,";

    /// <summary>
    /// The object type.
    /// </summary>
    private static readonly string objectType = "application/x-silverlight-2";

    /// <summary>
    /// The player path.
    /// </summary>
    private static readonly string playerPath = "/sitecore/shell/Applications/MultiMediaField/SilverlightPlayer/VideoPlayer.xap";

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

      this.AddObjectAttribute("data", objectData);
      this.AddObjectAttribute("type", objectType);

      this.AddObjectParameter("source", GetFullUrl(playerPath));
      this.AddObjectParameter("background", "black");

      StringBuilder playerParams = new StringBuilder();
      playerParams.AppendFormat("m={0},", src);
      playerParams.AppendFormat("autostart={0},", false);
      playerParams.AppendFormat("autohide={0},", true);
      playerParams.AppendFormat("canscrub={0},", true);
      this.AddObjectParameter("initParams", playerParams.ToString());

      this.NestedObject = IfNotInstalledHtml();

      base.Render(writer);
    }

    #endregion

    #region Private methods

    /// <summary>
    /// Displays if not installed html.
    /// </summary>
    /// <returns>
    /// The if not installed html.
    /// </returns>
    private static string IfNotInstalledHtml()
    {
      var html = new StringBuilder();
      html.Append("<img style=\"cursor: pointer; border-style: none;\" onclick=\"javascript:window.open('http://go.microsoft.com/fwlink/?LinkID=124807');\" src=\"http://go.microsoft.com/fwlink/?LinkId=108181\" alt=\"Get Microsoft Silverlight\" />");
      return html.ToString();
    }

    #endregion
  }
}