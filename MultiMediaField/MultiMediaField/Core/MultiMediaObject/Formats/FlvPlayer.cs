// <copyright file="FlvPlayer.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Web.UI;

  /// <summary>
  /// The flv player.
  /// </summary>
  public class FlvPlayer : MediaBaseObject
  {
    #region Fields

    /// <summary>
    /// The object type.
    /// </summary>
    private static readonly string objectType = "application/x-shockwave-flash";

    /// <summary>
    /// The player config path.
    /// </summary>
    private static readonly string playerConfigPath = "/sitecore/shell/Applications/MultiMediaField/FlvPlayer/flv-player_configs.txt";

    /// <summary>
    /// The player path.
    /// </summary>
    private static readonly string playerPath = "/sitecore/shell/Applications/MultiMediaField/FlvPlayer/player_flv_maxi.swf";

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

      this.AddObjectAttribute("data", playerPath);
      this.AddObjectAttribute("type", objectType);

      this.AddObjectParameter("movie", playerPath);
      this.AddObjectParameter("FlashVars", System.Web.HttpUtility.HtmlEncode(string.Format("flv={0}&config={1}", src, GetFullUrl(playerConfigPath))));
      this.AddObjectParameter("wmode", "transparent");
      this.AddObjectParameter("loop", "true");
      this.AddObjectParameter("menu", "false");
      this.AddObjectParameter("play", "true");
      this.AddObjectParameter("loop", "true");
      this.AddObjectParameter("allowFullScreen", "true");
      this.AddObjectParameter("allowScriptAccess", "always");

      base.Render(writer);
    }

    #endregion
  }
}