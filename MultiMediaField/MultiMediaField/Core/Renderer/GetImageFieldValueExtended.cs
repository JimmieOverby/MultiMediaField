// <copyright file="GetImageFieldValueExtended.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Pipelines.RenderField
{
  using Web;
  using Web.UI.WebControls;
  using Xml.Xsl;

  /// <summary>
  /// The get image field value.
  /// </summary>
  internal class GetImageFieldValueExtended : GetImageFieldValue
  {
    #region Public methods

    /// <summary>
    /// Processes render field pipline.
    /// </summary>
    /// <param name="args">
    /// The render field argument list.
    /// </param>
    public new void Process(RenderFieldArgs args)
    {
      if (args.FieldTypeKey != "image")
      {
        return;
      }

      MediaObject mediaObject = new MediaObject
      {
        // Database = Context.Database.Name, 
        // DataSource = args.Item.ID.ToString(), 
        Item = args.Item,
        FieldName = args.FieldName, 
        FieldValue = args.FieldValue, 
        RenderParameters = args.Parameters
      };
      args.WebEditParameters.AddRange(args.Parameters);
      RenderFieldResult result = new RenderFieldResult(HtmlUtil.RenderControl(mediaObject));

      args.Result.FirstPart = result.FirstPart;
      args.Result.LastPart = result.LastPart;
      args.DisableWebEditContentEditing = true;
      args.WebEditClick = "return Sitecore.WebEdit.editControl($JavascriptParameters, 'webedit:chooseimage')";
    }

    #endregion
  }
}