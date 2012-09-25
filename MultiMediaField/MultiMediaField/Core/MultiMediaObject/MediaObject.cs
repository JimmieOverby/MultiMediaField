// <copyright file="MediaObject.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.IO;
  using System.Web.UI;
  using System.Web.UI.WebControls;
  using Collections;
  using Data.Fields;
  using Data.Items;
  using Diagnostics;
  using Globalization;
  using Resources;
  using Resources.Media;
  using Sitecore;
  using Sitecore.Configuration;
  using Sitecore.Text;
  using Sites;
  using Utilities;

  /// <summary>
  /// The media object.
  /// </summary>
  public class MediaObject : UI.WebControl
  {
    #region Fields

    /// <summary>
    /// The allowstretch.
    /// </summary>
    private bool allowstretch;

    /// <summary>
    /// The alt text.
    /// </summary>
    private string altText = string.Empty;

    /// <summary>
    /// The bgcolor.
    /// </summary>
    private string bgcolor = "transparent";

    /// <summary>
    /// The border.
    /// </summary>
    private string border = string.Empty;

    /// <summary>
    /// The database.
    /// </summary>
    private string database = string.Empty;

    /// <summary>
    /// The disablemediacache.
    /// </summary>
    private bool disablemediacache;

    /// <summary>
    /// The field name.
    /// </summary>
    private string fieldName = string.Empty;

    /// <summary>
    /// The field value.
    /// </summary>
    private string fieldValue = string.Empty;

    /// <summary>
    /// The height.
    /// </summary>
    private string height = string.Empty;

    /// <summary>
    /// The h space.
    /// </summary>
    private string hSpace = string.Empty;

    /// <summary>
    /// The language.
    /// </summary>
    private string language = string.Empty;

    /// <summary>
    /// The max height.
    /// </summary>
    private string maxHeight = string.Empty;

    /// <summary>
    /// The max width.
    /// </summary>
    private string maxWidth = string.Empty;

    /// <summary>
    /// The scale.
    /// </summary>
    private string scale = string.Empty;

    /// <summary>
    /// The src.
    /// </summary>
    private string src = string.Empty;

    /// <summary>
    /// The thumbnail.
    /// </summary>
    private bool thumbnail;

    /// <summary>
    /// The version.
    /// </summary>
    private string version = string.Empty;

    /// <summary>
    /// The v space.
    /// </summary>
    private string vSpace = string.Empty;

    /// <summary>
    /// The width.
    /// </summary>
    private string width = string.Empty;

    /// <summary>
    /// The xhtml.
    /// </summary>
    private bool xhtml;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Gets or sets a value indicating whether AllowStretch.
    /// </summary>
    public bool AllowStretch
    {
      get
      {
        return this.allowstretch;
      }

      set
      {
        this.allowstretch = value;
      }
    }

    /// <summary>
    /// Gets or sets AltText.
    /// </summary>
    public string AltText
    {
      get
      {
        return this.altText;
      }

      set
      {
        this.altText = value;
      }
    }

    /// <summary>
    /// Gets or sets BgColor.
    /// </summary>
    public string BgColor
    {
      get
      {
        return this.bgcolor;
      }

      set
      {
        this.bgcolor = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether DisableMediaCache.
    /// </summary>
    public bool DisableMediaCache
    {
      get
      {
        return this.disablemediacache;
      }

      set
      {
        this.disablemediacache = value;
      }
    }

    /// <summary>
    /// Gets or sets FieldName.
    /// </summary>
    public string FieldName
    {
      get
      {
        return this.fieldName;
      }

      set
      {
        this.fieldName = value;
      }
    }

    /// <summary>
    /// Gets or sets FieldValue.
    /// </summary>
    public string FieldValue
    {
      get
      {
        return this.fieldValue;
      }

      set
      {
        this.fieldValue = value;
      }
    }

    /// <summary>
    /// Gets or sets HSpace.
    /// </summary>
    public string HSpace
    {
      get
      {
        return this.hSpace;
      }

      set
      {
        this.hSpace = value;
      }
    }

    /// <summary>
    /// Gets or sets objectBorder.
    /// </summary>
    public string ObjectBorder
    {
      get
      {
        return this.border;
      }

      set
      {
        this.border = value;
      }
    }

    /// <summary>
    /// Gets or sets objectDatabase.
    /// </summary>
    public string ObjectDatabase
    {
      get
      {
        return this.database;
      }

      set
      {
        this.database = value;
      }
    }

    /// <summary>
    /// Gets or sets objectHeight.
    /// </summary>
    public string ObjectHeight
    {
      get
      {
        return this.height;
      }

      set
      {
        this.height = value;
      }
    }

    /// <summary>
    /// Gets or sets objectLanguage.
    /// </summary>
    public string ObjectLanguage
    {
      get
      {
        return this.language;
      }

      set
      {
        this.language = value;
      }
    }

    /// <summary>
    /// Gets or sets objectMaxHeight.
    /// </summary>
    public string ObjectMaxHeight
    {
      get
      {
        return this.maxHeight;
      }

      set
      {
        this.maxHeight = value;
      }
    }

    /// <summary>
    /// Gets or sets objectMaxWidth.
    /// </summary>
    public string ObjectMaxWidth
    {
      get
      {
        return this.maxWidth;
      }

      set
      {
        this.maxWidth = value;
      }
    }

    /// <summary>
    /// Gets or sets objectScale.
    /// </summary>
    public string ObjectScale
    {
      get
      {
        return this.scale;
      }

      set
      {
        this.scale = value;
      }
    }

    /// <summary>
    /// Gets or sets objectVersion.
    /// </summary>
    public string ObjectVersion
    {
      get
      {
        return this.version;
      }

      set
      {
        this.version = value;
      }
    }

    /// <summary>
    /// Gets or sets objectWidth.
    /// </summary>
    public string ObjectWidth
    {
      get
      {
        return this.width;
      }

      set
      {
        this.width = value;
      }
    }

    /// <summary>
    /// Gets or sets RenderParameters.
    /// </summary>
    public SafeDictionary<string> RenderParameters { get; set; }

    /// <summary>
    /// Gets or sets Src.
    /// </summary>
    public string Src
    {
      get
      {
        return this.src;
      }

      set
      {
        this.src = value;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether Thumbnail.
    /// </summary>
    public bool Thumbnail
    {
      get
      {
        return this.thumbnail;
      }

      set
      {
        this.thumbnail = value;
      }
    }

    /// <summary>
    /// Gets or sets VSpace.
    /// </summary>
    public string VSpace
    {
      get
      {
        return this.vSpace;
      }

      set
      {
        this.vSpace = value;
      }
    }

    /// <summary>
    /// Gets or sets Item.
    /// </summary>
    public Item Item { get; set; }
    
    #endregion Properties

    #region Public methods

    /// <summary>
    /// The get default image.
    /// </summary>
    /// <returns>
    /// The default image link.
    /// </returns>
    public static string GetDefaultImage()
    {
      return Themes.MapTheme(Client.GetItemNotNull("/sitecore/content/Applications/WebEdit/WebEdit Texts", Client.CoreDatabase)["Default Image"]);
    }

    #endregion Public methods

    #region Overriden methods

    /// <summary>
    /// The do render.
    /// </summary>
    /// <param name="output">
    /// The output.
    /// </param>
    protected override void DoRender(HtmlTextWriter output)
    {
      // Item item = this.GetItem();
      MediaBaseObject mediaObject = this.CreateMediaObject(this.Item);
      if (mediaObject != null)
      {
        mediaObject.RenderControl(output);
      }
    }

    #endregion Overriden methods

    #region Private members

    #region Helpers

    /// <summary>
    /// Extracts the string.
    /// </summary>
    /// <param name="values">
    /// The values list.
    /// </param>
    /// <param name="keys">
    /// The keys array.
    /// </param>
    /// <returns>
    /// The extracted value.
    /// </returns>
    private static string Extract(SafeDictionary<string, string> values, params string[] keys)
    {
      Assert.ArgumentNotNull(values, "values");
      Assert.ArgumentNotNull(keys, "keys");
      foreach (string str in keys)
      {
        string str2 = values[str];
        if (str2 != null)
        {
          values.Remove(str);
          return str2;
        }
      }

      return null;
    }

    /// <summary>
    /// Gets proportional value.
    /// </summary>
    /// <param name="value1">
    /// The value 1.
    /// </param>
    /// <param name="value2">
    /// The value 2.
    /// </param>
    /// <param name="valueDepended">
    /// The value depended.
    /// </param>
    /// <returns>
    /// The get proportional value.
    /// </returns>
    private static string GetProportionalValue(string value1, string value2, string valueDepended)
    {
      int v1, v2, vd;
      if (int.TryParse(value1, out v1) && int.TryParse(value2, out v2) && int.TryParse(valueDepended, out vd))
      {
        int vout = (v1 * vd) / v2;
        return vout.ToString();
      }

      return string.Empty;
    }

    /// <summary>
    /// The set if string is null or empty.
    /// </summary>
    /// <param name="parameter">
    /// The parameter.
    /// </param>
    /// <param name="value">
    /// The value.
    /// </param>
    private static void SetIfStringIsNullOrEmpty(ref string parameter, string value)
    {
      if (string.IsNullOrEmpty(parameter) && !string.IsNullOrEmpty(value))
      {
        parameter = value;
      }
    }

    /// <summary>
    /// The get min values.
    /// </summary>
    /// <param name="value1">
    /// The value 1.
    /// </param>
    /// <param name="value2">
    /// The value 2.
    /// </param>
    /// <param name="valueDepended1">
    /// The value depended 1.
    /// </param>
    /// <param name="valueDepended2">
    /// The value depended 2.
    /// </param>
    /// <param name="valueout1">
    /// The valueout 1.
    /// </param>
    /// <param name="valueout2">
    /// The valueout 2.
    /// </param>
    private void GetMinValues(string value1, string value2, string valueDepended1, string valueDepended2, out string valueout1, out string valueout2)
    {
      valueout1 = valueDepended1;
      valueout2 = valueDepended2;
      int v1, vd1;
      if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(valueDepended1) && int.TryParse(value1, out v1) && int.TryParse(valueDepended1, out vd1) && (v1 < vd1))
      {
        valueout1 = value1;
        if (string.IsNullOrEmpty(value2) && this.allowstretch)
        {
          valueout2 = GetProportionalValue(value1, valueDepended1, valueDepended2);
        }
        else if (string.IsNullOrEmpty(valueDepended2))
        {
          valueout2 = valueDepended2;
        }
      }

      int v2, vd2;
      if (!string.IsNullOrEmpty(value2) && !string.IsNullOrEmpty(valueDepended2) && int.TryParse(value2, out v2) && int.TryParse(valueDepended2, out vd2) && (v2 < vd2))
      {
        valueout2 = value2;
        if (string.IsNullOrEmpty(value1) && this.allowstretch)
        {
          valueout1 = GetProportionalValue(value2, valueDepended2, valueDepended1);
        }
        else if (string.IsNullOrEmpty(valueDepended1))
        {
          valueout1 = valueDepended1;
        }
      }
    }

    #endregion Helpers

    /// <summary>
    /// The create media object.
    /// </summary>
    /// <param name="item">
    /// The current item.
    /// </param>
    /// <returns>
    /// Media Object class
    /// </returns>
    private MediaBaseObject CreateMediaObject(Item item)
    {
      MediaItem mediaItem = null;
      Data.Fields.ImageField currentImageField = null;

      if (this.RenderParameters != null)
      {
        this.ParseNode(this.RenderParameters);
      }

      if (item != null)
      {
        if (!string.IsNullOrEmpty(this.fieldName))
        {
          Field innerField = item.Fields[this.fieldName];
          Assert.IsNotNull(innerField, "Item {0} don't have field {1}", item.ID.ToString(), this.fieldName);
          if (innerField != null)
          {
            currentImageField = string.IsNullOrEmpty(this.fieldValue) ? new Data.Fields.ImageField(innerField) : new Data.Fields.ImageField(innerField, this.fieldValue);
            mediaItem = currentImageField.MediaItem;
          }

          this.ParseField(currentImageField);
          this.ParseMediaItem(mediaItem);
        }
        else if (item.Paths.IsMediaItem)
        {
          mediaItem = item;
          this.ParseMediaItem(mediaItem);
        }
      }

      if (string.IsNullOrEmpty(this.src))
      {
        SiteContext site = Sitecore.Context.Site;
        if (((site != null) && (site.DisplayMode == DisplayMode.Edit)) && !Sitecore.Context.PageMode.IsPageEditorEditing)
        {
          this.src = GetDefaultImage();
        }
        else
        {
          return null;
        }
      }

      string mediaObjectExtension = mediaItem != null ? mediaItem.Extension : Path.GetExtension(this.src).Replace(".", string.Empty);
      MediaBaseObject mediaObject = Singleton<MediaControlsFactory>.Instance.GetMediaObject(mediaObjectExtension);
      if (mediaObject != null)
      {
        this.SetAtributesToAshx();
        this.SetMediaObjectAtributes(mediaObject);
      }

      return mediaObject;
    }

    /// <summary>
    /// The parse field.
    /// </summary>
    /// <param name="currentImageField">
    /// The current image field.
    /// </param>
    private void ParseField(Data.Fields.ImageField currentImageField)
    {
      if (!string.IsNullOrEmpty(this.database))
      {
        currentImageField.MediaDatabase = Factory.GetDatabase(this.database);
      }

      if (!string.IsNullOrEmpty(this.language))
      {
        currentImageField.MediaLanguage = Language.Parse(this.language);
      }

      if (!string.IsNullOrEmpty(this.version))
      {
        currentImageField.MediaVersion = Data.Version.Parse(this.version);
      }

      this.src = StringUtil.GetString(new[]
      {
        this.src, currentImageField.Src
      });
      this.altText = StringUtil.GetString(new[]
      {
        this.altText, currentImageField.Alt
      });
      this.border = StringUtil.GetString(new[]
      {
        this.border, currentImageField.Border
      });
      this.height = StringUtil.GetString(new[]
      {
        this.height, currentImageField.Height
      });
      this.width = StringUtil.GetString(new[]
      {
        this.width, currentImageField.Width
      });
      this.hSpace = StringUtil.GetString(new[]
      {
        this.hSpace, currentImageField.HSpace
      });
      this.vSpace = StringUtil.GetString(new[]
      {
        this.vSpace, currentImageField.VSpace
      });
      this.CssClass = StringUtil.GetString(new[]
      {
        this.CssClass, currentImageField.Class
      });
    }

    /// <summary>
    /// The parse media item.
    /// </summary>
    /// <param name="mediaItem">
    /// The media item.
    /// </param>
    private void ParseMediaItem(MediaItem mediaItem)
    {
      if (mediaItem == null)
      {
        return;
      }

      SetIfStringIsNullOrEmpty(ref this.altText, mediaItem.Alt);
      SetIfStringIsNullOrEmpty(ref this.vSpace, mediaItem.InnerItem["vspace"]);
      SetIfStringIsNullOrEmpty(ref this.hSpace, mediaItem.InnerItem["hspace"]);
      SetIfStringIsNullOrEmpty(ref this.width, mediaItem.InnerItem["width"]);
      SetIfStringIsNullOrEmpty(ref this.height, mediaItem.InnerItem["height"]);
      SetIfStringIsNullOrEmpty(ref this.src, MediaManager.GetMediaUrl(mediaItem));
      if (string.IsNullOrEmpty(this.CssClass))
      {
        this.CssClass = mediaItem.InnerItem["class"];
      }
    }

    /// <summary>
    /// The parse node.
    /// </summary>
    /// <param name="attributes">
    /// The attributes.
    /// </param>
    private void ParseNode(SafeDictionary<string, string> attributes)
    {
      Assert.ArgumentNotNull(attributes, "attributes");
      string str = Extract(attributes, new[] { "outputMethod" });
      this.xhtml = (str == "xhtml") || (Settings.Rendering.ImagesAsXhtml && (str != "html"));
      this.src = Extract(attributes, new[] { "src" }) ?? this.src;
      this.border = Extract(attributes, new[] { "border" }) ?? this.border;
      this.altText = Extract(attributes, new[] { "alt", "AltText" }) ?? this.altText;
      this.hSpace = Extract(attributes, new[] { "hspace" }) ?? this.hSpace;
      this.vSpace = Extract(attributes, new[] { "vspace" }) ?? this.vSpace;
      this.CssClass = Extract(attributes, new[] { "class" }) ?? this.CssClass;
      this.width = Extract(attributes, new[] { "width", "w" }) ?? this.width;
      this.height = Extract(attributes, new[] { "height", "h" }) ?? this.height;
      this.scale = Extract(attributes, new[] { "scale", "sc" }) ?? this.scale;
      this.maxWidth = Extract(attributes, new[] { "maxWidth", "mw" }) ?? this.maxWidth;
      this.maxHeight = Extract(attributes, new[] { "maxHeight", "mh" }) ?? this.maxHeight;
      this.database = Extract(attributes, new[] { "database", "db" }) ?? this.database;
      this.language = Extract(attributes, new[] { "language", "la" }) ?? this.language;
      this.version = Extract(attributes, new[] { "version", "vs" }) ?? this.version;
      this.bgcolor = Extract(attributes, new[] { "backgroundColor", "bc" }) ?? this.bgcolor;
      this.allowstretch = MainUtil.GetBool(Extract(attributes, new[] { "allowStretch", "as", "autoscale" }), true);
      this.disablemediacache = MainUtil.GetBool(Extract(attributes, new[] { "disableMediaCache" }), false);
      this.thumbnail = MainUtil.GetBool(Extract(attributes, new[] { "thumbnail", "thn" }), true);

      if (string.IsNullOrEmpty(this.border) && !this.xhtml)
      {
        this.border = "0";
      }
    }

    /// <summary>
    /// The set atributes to ashx.
    /// </summary>
    private void SetAtributesToAshx()
    {
      string atributes = string.Empty;
      if (!string.IsNullOrEmpty(this.src))
      {
        string currentWidth;
        string currentHeight;
        this.GetMinValues(this.maxWidth, this.maxHeight, this.width, this.height, out currentWidth, out currentHeight);
        if (!string.IsNullOrEmpty(currentWidth))
        {
          atributes += string.Format("w={0}&", currentWidth);
        }

        if (!string.IsNullOrEmpty(currentHeight))
        {
          atributes += string.Format("h={0}&", currentHeight);
        }

        if (!string.IsNullOrEmpty(this.maxWidth))
        {
          atributes += string.Format("mw={0}&", this.maxWidth);
        }

        if (!string.IsNullOrEmpty(this.maxHeight))
        {
          atributes += string.Format("mh={0}&", this.maxHeight);
        }

        if (!string.IsNullOrEmpty(this.language))
        {
          atributes += string.Format("la={0}&", this.language);
        }

        if (!string.IsNullOrEmpty(this.version))
        {
          atributes += string.Format("vs={0}&", this.version);
        }

        if (!string.IsNullOrEmpty(this.database))
        {
          atributes += string.Format("db={0}&", this.database);
        }

        if (!string.IsNullOrEmpty(this.bgcolor))
        {
          atributes += string.Format("bc={0}&", this.bgcolor);
        }

        if (!string.IsNullOrEmpty(this.scale))
        {
          atributes += string.Format("sc={0}&", this.scale);
        }

        if (this.disablemediacache)
        {
          atributes += "dmc=1&";
        }

        if (this.allowstretch)
        {
          atributes += "as=1&";
        }

        if (this.thumbnail)
        {
          atributes += "thn=1&";
        }
      }

      if (!string.IsNullOrEmpty(atributes))
      {
        var sourceUrl = new UrlString(this.src);
        var parameters = new UrlString(atributes.Substring(0, atributes.Length - 1));
        sourceUrl.Append(parameters);
        this.src = System.Web.HttpUtility.HtmlEncode(sourceUrl.ToString());
      }
    }

    /// <summary>
    /// The set media object atributes.
    /// </summary>
    /// <param name="mediaObject">
    /// The media object.
    /// </param>
    private void SetMediaObjectAtributes(MediaBaseObject mediaObject)
    {
      mediaObject.AddObjectAttribute("src", this.src);
      mediaObject.AddObjectAttribute("border", this.border);
      mediaObject.AddObjectAttribute("alt", this.altText);
      mediaObject.AddObjectAttribute("vspace", this.vSpace);
      mediaObject.AddObjectAttribute("hspace", this.hSpace);
      mediaObject.CssClass = this.CssClass;

      string currentWidth;
      string currentHeight;
      this.GetMinValues(this.maxWidth, this.maxHeight, this.width, this.height, out currentWidth, out currentHeight);
      mediaObject.Width = new Unit(StringUtil.GetString(currentWidth));
      mediaObject.Height = new Unit(StringUtil.GetString(currentHeight));
    }

    #endregion Private member
  }
}