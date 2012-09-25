// <copyright file="MediaBaseObject.cs" company="Sitecore A/S">
//   Copyright (c) Sitecore A/S. All rights reserved.
// </copyright>
namespace Sitecore.Web.UI.WebControls
{
  using System.Web;
  using System.Web.UI;
  using System.Web.UI.WebControls;
  using Collections;
  using Resources.Media;
  using Sitecore.Text;
  using Web;

  /// <summary>
  /// The media base object.
  /// </summary>
  public class MediaBaseObject : WebControl
  {
    #region Fields

    /// <summary>
    /// The media object tag.
    /// </summary>
    private HtmlTextWriterTag mediaObjectTag = HtmlTextWriterTag.Object;

    /// <summary>
    /// The nest object writer.
    /// </summary>
    private string nestedObject = string.Empty;

    /// <summary>
    /// The object attributes.
    /// </summary>
    private readonly SafeDictionary<string, string> objectAttributes;

    /// <summary>
    /// The object parameters.
    /// </summary>
    private readonly SafeDictionary<string, string> objectParameters;

    /// <summary>
    /// The error message.
    /// </summary>
    private string errorMessage = string.Empty;

    #endregion Fields

    #region Constructor

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaBaseObject"/> class.
    /// </summary>
    public MediaBaseObject()
    {
      this.objectAttributes = new SafeDictionary<string, string>();
      this.objectParameters = new SafeDictionary<string, string>();
    }

    #endregion Constructor

    #region Properties

    /// <summary>
    /// Gets or sets ErrorMessage.
    /// </summary>
    public string ErrorMessage
    {
      get
      {
        return this.errorMessage;
      }

      set
      {
        if (!string.IsNullOrEmpty(value))
        {
          this.errorMessage = value;
        }
      }
    }

    /// <summary>
    /// Sets nested object body.
    /// </summary>
    public string NestedObject
    {
      set
      {
        if (!string.IsNullOrEmpty(value))
        {
          this.nestedObject = value;
        }
      }
    }

    /// <summary>
    /// Sets media object tag.
    /// </summary>
    public HtmlTextWriterTag MediaObjectTag
    {
      set
      {
          this.mediaObjectTag = value;
      }
    }

    /// <summary>
    /// Gets Source URL.
    /// </summary>
    public string Source
    {
      get
      {
        if (this.objectAttributes.ContainsKey("src") && !string.IsNullOrEmpty(this.objectAttributes["src"]))
        {
          return GetFullUrl(RemoveUrlParameters(this.objectAttributes["src"]));
        }

        return string.Empty;
      }
    }

    #endregion Properties

    #region Public methods

    /// <summary>
    /// The add object attribute.
    /// </summary>
    /// <param name="key">
    /// The key of the attribute.
    /// </param>
    /// <param name="value">
    /// The value  of the attribute.
    /// </param>
    public void AddObjectAttribute(string key, string value)
    {
      if (!string.IsNullOrEmpty(value))
      {
        if (this.objectAttributes.ContainsKey(key))
        {
          this.RemoveObjectAttribute(key);
        }

        this.objectAttributes.Add(key, value);
      }
    }

    /// <summary>
    /// The add object parameter.
    /// </summary>
    /// <param name="key">
    /// The key of the parameter.
    /// </param>
    /// <param name="value">
    /// The value of the parameter.
    /// </param>
    public void AddObjectParameter(string key, string value)
    {
      if (!string.IsNullOrEmpty(value))
      {
        if (this.objectParameters.ContainsKey(key))
        {
          this.objectParameters.Remove(key);
        }

        this.objectParameters.Add(key, value);
      }
    }

    /// <summary>
    /// The remove object attribute.
    /// </summary>
    /// <param name="key">
    /// The key of the attribute.
    /// </param>
    public void RemoveObjectAttribute(string key)
    {
      this.objectAttributes.Remove(key);
    }

    /// <summary>
    /// The remove object parameter.
    /// </summary>
    /// <param name="key">
    /// The key of the parameter.
    /// </param>
    public void RemoveObjectParameter(string key)
    {
      this.objectParameters.Remove(key);
    }

    #endregion

    #region Protected methods

    /// <summary>
    /// Gets full url.
    /// </summary>
    /// <param name="url">
    /// The url string.
    /// </param>
    /// <returns>
    /// The full url.
    /// </returns>
    protected static string GetFullUrl(string url)
    {
      if (MediaManager.IsMediaUrl(url) && (url.IndexOf("://") < 0) && !url.StartsWith("/"))
      {
        string absoluteUrl = HttpContext.Current.Request.Url.AbsoluteUri;
        int idx = absoluteUrl.LastIndexOf('/');
        return idx >= 0 ? string.Concat(absoluteUrl.Substring(0, idx + 1), url) : WebUtil.GetFullUrl(url);
      }

      return WebUtil.GetFullUrl(url);
    }

    /// <summary>
    /// Removes parameters from the source url (after "?")
    /// </summary>
    /// <param name="url">
    /// The url string.
    /// </param>
    /// <returns>
    /// The clean url 
    /// </returns>
    private static string RemoveUrlParameters(string url)
    {
      if (!string.IsNullOrEmpty(url))
      {
        UrlString source = new UrlString(url);
        return source.Path;
      }

      return string.Empty;
    }

    #region Overriden methods

    /// <summary>
    /// Renders MultiMedia object
    /// </summary>
    /// <param name="output">
    /// The output.
    /// </param>
    protected override void Render(HtmlTextWriter output)
    {
      output.Write(HtmlTextWriter.TagLeftChar);
      output.Write(this.mediaObjectTag.ToString().ToLower());

      this.AddStandardAttributes();
      this.WriteObjectAttributes(output);

      if (this.objectParameters.Count > 0)
      {
        output.Write(HtmlTextWriter.TagRightChar);
        output.Indent++;
        this.WriteObjectParametrs(output);

        if (!string.IsNullOrEmpty(this.nestedObject))
        {
          output.WriteLine(this.nestedObject);
        }

        output.Indent--;
        output.Write(HtmlTextWriter.EndTagLeftChars);
        output.Write(this.mediaObjectTag.ToString().ToLower());
        output.Write(HtmlTextWriter.TagRightChar);
      }
      else
      {
        output.Write(HtmlTextWriter.SelfClosingTagEnd);
      }
    }

    #endregion Overriden methods

    /// <summary>
    /// Writes standard attributes
    /// </summary>
    private void AddStandardAttributes()
    {
      if (this.Width.Value > 0)
      {
        this.AddObjectAttribute("width", this.Width.Value.ToString());
      }

      if (this.Height.Value > 0)
      {
        this.AddObjectAttribute("height", this.Height.Value.ToString());
      }

      if (!string.IsNullOrEmpty(this.CssClass))
      {
        this.AddObjectAttribute("class", this.CssClass);
      }

      if (this.mediaObjectTag == HtmlTextWriterTag.Img)
      {
        if (string.IsNullOrEmpty(this.Attributes["alt"]) && !this.objectAttributes.ContainsKey("alt"))
        {
          this.AddObjectAttribute("alt", "image");
        }
      }
      else
      {
        string alt = StringUtil.GetString(new[]
        {
          this.objectAttributes["alt"],
          this.Attributes["alt"]
        });
        if (!string.IsNullOrEmpty(alt))
        {
          this.AddObjectAttribute("title", alt);
        }
      }
    }

    /// <summary>
    /// The write object attributes.
    /// </summary>
    /// <param name="writer">
    /// The writer.
    /// </param>
    private void WriteObjectAttributes(HtmlTextWriter writer)
    {
      foreach (var attr in this.objectAttributes)
      {
        writer.WriteAttribute(attr.Key, attr.Value);
      }
    }

    /// <summary>
    /// The write object parametrs.
    /// </summary>
    /// <param name="writer">
    /// The writer.
    /// </param>
    private void WriteObjectParametrs(HtmlTextWriter writer)
    {
      foreach (var attr in this.objectParameters)
      {
        writer.WriteBeginTag("param");
        writer.WriteAttribute("name", attr.Key);
        writer.WriteAttribute("value", attr.Value);
        writer.Write(HtmlTextWriter.SelfClosingTagEnd);
        writer.WriteLine();
      }
    }

    #endregion Protected methods
  }
}