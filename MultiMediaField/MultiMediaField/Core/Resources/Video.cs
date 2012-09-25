// <copyright file="Video.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Resources.Media
{
  using Data.Items;
  using SecurityModel;

  /// <summary>
  /// The video.
  /// </summary>
  public class Video : Media
  {
    #region Fields

    /// <summary>
    /// The default height.
    /// </summary>
    private static readonly string defaultHeight = "310";

    /// <summary>
    /// The default width.
    /// </summary>
    private static readonly string defaultWidth = "400";

    #endregion

    #region Public methods

    /// <summary>
    /// The clone.
    /// </summary>
    /// <returns>
    /// The cloned item.
    /// </returns>
    public override Media Clone()
    {
      return new Video();
    }

    #endregion

    #region Protected methods

    /// <summary>
    /// The update meta data.
    /// </summary>
    /// <param name="mediaStream">
    /// The media stream.
    /// </param>
    public override void UpdateMetaData(MediaStream mediaStream)
    {
      base.UpdateMetaData(mediaStream);
      Item innerItem = this.MediaData.MediaItem.InnerItem;
      using (new EditContext(innerItem, SecurityCheck.Disable))
      {
        innerItem["Width"] = defaultWidth;
        innerItem["Height"] = defaultHeight;
        innerItem["Dimensions"] = string.Format("{0} x {1}", defaultWidth, defaultHeight);
      }
    }

    #endregion
  }
}