// <copyright file="ClearImage.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Shell.Applications.WebEdit.Commands
{
  using System.Collections.Specialized;
  using Collections;
  using Diagnostics;
  using Framework.Commands;
  using Resources;
  using Shell;
  using Sitecore;
  using Sitecore.Data.Fields;
  using Sitecore.Data.Items;
  using Sitecore.Web;
  using Sitecore.Web.UI.Sheer;
  using Xml.Xsl;

  /// <summary>
  /// The clear image.
  /// </summary>
  public class ClearImage : WebEditImageCommand
  {
    #region Public methods

    /// <summary>
    /// The execute.
    /// </summary>
    /// <param name="context">
    /// The context.
    /// </param>
    public override void Execute(CommandContext context)
    {
      Assert.ArgumentNotNull(context, "context");

      if (context.Items.Length != 1)
      {
        return;
      }

      Item itemNotNull = Client.GetItemNotNull(context.Parameters["itemid"]);
      itemNotNull.Fields.ReadAll();

      Field field = itemNotNull.Fields[context.Parameters["fieldid"]];
      Assert.IsNotNull(field, "field");

      ImageRenderer renderer = new ImageRenderer
      {
        Item = itemNotNull,
        FieldName = field.Name,
        FieldValue = string.Empty,
        Parameters = this.GetRendererParameters(context.Parameters)
      };

      SheerResponse.SetAttribute("scHtmlValue", "value", renderer.Render().ToString());
      SheerResponse.SetAttribute("scPlainValue", "value", EditorConstants.NoValue);
      SheerResponse.Eval("scSetHtmlValue('{0}');", context.Parameters["controlid"]);

      WebUtil.SetCookieValue("sitecore_webedit_editing", "1");
    }

    #endregion

    #region Protected methods

    /// <summary>
    /// The get renderer parameters.
    /// </summary>
    /// <param name="parameters">
    /// The parameters.
    /// </param>
    /// <returns>
    /// Dictionary of parameters
    /// </returns>
    protected virtual SafeDictionary<string> GetRendererParameters(NameValueCollection parameters)
    {
      Assert.ArgumentNotNull(parameters, "paramerers");

      var rendererParams = new SafeDictionary<string>();
      foreach (string key in parameters)
      {
        rendererParams[key] = parameters[key];
      }

      Item item = Client.GetItemNotNull("/sitecore/content/Applications/WebEdit/WebEdit Texts", Client.CoreDatabase);
      rendererParams["src"] = Themes.MapTheme(item["Default Image"]);

      return rendererParams;
    }

    #endregion
  }
}